using BE_327LG;
using DAL_327LG;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Services_327LG;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL_327LG
{
    public class BLLFactura_327LG
    {
        DALFactura_327LG dalFactura_327LG;
        public BLLFactura_327LG()
        {
            dalFactura_327LG = new DALFactura_327LG();
        }

        public void GenerarFactura_327LG(BECliente_327LG cliente, decimal monto,BELibro_327LG libro)
        {
            dalFactura_327LG.GuardarFactura_327LG(new BEFactura_327LG(DateTime.Now, cliente, monto, libro));
        }

        public void GenerarReporte(BEFactura_327LG factura)
        {
            string tempFolder = Path.Combine(Path.GetTempPath(), $"FacturaTemp_{Guid.NewGuid()}");
            Directory.CreateDirectory(tempFolder);

            string rutaPdf = Path.Combine(tempFolder, $"Factura_{factura.nroFactura_327LG}.pdf");

            Document documento = new Document();
            PdfWriter.GetInstance(documento, new FileStream(rutaPdf, FileMode.Create));
            documento.Open();

            var fontTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
            var fontSubTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14);
            var fontTexto = FontFactory.GetFont(FontFactory.HELVETICA, 12);

            documento.Add(new Paragraph("FACTURA", fontTitulo));
            documento.Add(new Paragraph($"Número: {factura.nroFactura_327LG}", fontTexto));
            documento.Add(new Paragraph($"Fecha: {factura.Fecha_327LG.ToShortDateString()}", fontTexto));
            documento.Add(new Paragraph($"Monto: ${factura.Monto_327LG}", fontTexto));
            documento.Add(new Paragraph("\n", fontTexto));
            documento.Add(new Paragraph("Datos del Cliente:", fontSubTitulo));
            documento.Add(new Paragraph($"DNI: {factura.Cliente_327LG.DNI_327LG}", fontTexto));
            documento.Add(new Paragraph($"Nombre: {factura.Cliente_327LG.Nombre_327LG} {factura.Cliente_327LG.Apellido_327LG}", fontTexto));
            documento.Add(new Paragraph($"Email: {Encriptador_327LG.DesencriptarReversible_327LG(factura.Cliente_327LG.Email_327LG)}", fontTexto));
            documento.Add(new Paragraph("\n", fontTexto));
            documento.Add(new Paragraph("Datos del Libro:", fontSubTitulo));
            documento.Add(new Paragraph($"ISBN: {factura.Libro_327LG.ISBN_327LG}", fontTexto));
            documento.Add(new Paragraph($"Título: {factura.Libro_327LG.titulo_327LG}", fontTexto));
            documento.Add(new Paragraph($"Autor: {factura.Libro_327LG.autor_327LG}", fontTexto));
            documento.Add(new Paragraph($"Edición: {factura.Libro_327LG.edicion_327LG}", fontTexto));
            documento.Add(new Paragraph($"Editorial: {factura.Libro_327LG.editorial_327LG}", fontTexto));
            documento.Close();

            Process.Start(new ProcessStartInfo
            {
                FileName = rutaPdf,
                UseShellExecute = true
            });
            Task.Run(async () =>
            {
                await Task.Delay(5000);
                try
                {
                    if (File.Exists(rutaPdf)) File.Delete(rutaPdf);
                    if (Directory.Exists(tempFolder)) Directory.Delete(tempFolder, true);
                }
                catch
                {
                }
            });
        }


        public List<BEFactura_327LG> ObtenerFacturas_327LG()
        {
           return dalFactura_327LG.ObtenerFacturas_327LG();
        }
    }
}
