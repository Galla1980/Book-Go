using BE_327LG;
using DAL_327LG;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using Services_327LG;
using Services_327LG.Singleton_327LG;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_327LG
{
    public class BLLOrdenCompra_327LG
    {
        private readonly DALOrdenCompra_327LG dalOrdenCompra_327LG = new DALOrdenCompra_327LG();
        private readonly BLLEvento_327LG bllEvento_327LG = new BLLEvento_327LG();
        private readonly BLLDigitoVerificador_327LG bllDigitoVerificador_327LG = new BLLDigitoVerificador_327LG();


        public void ActualizarEstadoOrden(BEOrdenCompra_327LG orden)
        {
            dalOrdenCompra_327LG.ActualizarEstadoOrden(orden);
            bllDigitoVerificador_327LG.GuardarDigitoVerificador_327LG(new BEDigitoVerificador_327LG("OrdenCompra_327LG"));
        }

        public void GenerarOrdenCompra_327LG(BEOrdenCompra_327LG ordenCompra)
        {
            string nroOrden = string.Empty;
            int numero = 1;
            BEOrdenCompra_327LG ultimaSolicitud = ObtenerUltimaOrden_327LG();
            if (ultimaSolicitud != null)
            {
                var partes = ultimaSolicitud.nroOrden_327LG.ToString().Split('-');
                DateTime Fecha = DateTime.ParseExact(partes[0], "yyyyMMdd", null);
                if (Fecha.Date == DateTime.Now.Date) numero = int.Parse(partes[1]) + 1;
            }
            nroOrden = DateTime.Now.ToString("yyyyMMdd") + "-" + numero.ToString("D3");
            ordenCompra.nroOrden_327LG = nroOrden;
            dalOrdenCompra_327LG.GenerarOrdenCompra_327LG(ordenCompra);
            bllEvento_327LG.RegistrarEvento_327LG(SessionManager_327LG.Instancia.Usuario.dni_327LG, "Gestión de stock", "Generación de orden de compra", 3);
            bllDigitoVerificador_327LG.GuardarDigitoVerificador_327LG(new BEDigitoVerificador_327LG("OrdenCompra_327LG"));
            bllDigitoVerificador_327LG.GuardarDigitoVerificador_327LG(new BEDigitoVerificador_327LG("OrdenCompraDetalle_327LG"));
        }

        public void GenerarReporte_327LG(BEOrdenCompra_327LG ordenCompra)
        {
            string tempFolder = Path.Combine(Path.GetTempPath(), $"OrdenCompraTemp_{Guid.NewGuid()}");
            Directory.CreateDirectory(tempFolder);

            string rutaPdf = Path.Combine(tempFolder, $"OrdenCompra_{ordenCompra.nroOrden_327LG}.pdf");

            Document documento = new Document(PageSize.A4, 50, 50, 50, 50);
            PdfWriter.GetInstance(documento, new FileStream(rutaPdf, FileMode.Create));
            documento.Open();

            // Fuentes
            var fontTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20);
            var fontSubTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 13);
            var fontTexto = FontFactory.GetFont(FontFactory.HELVETICA, 11);
            var fontNegrita = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11);

            // --- Encabezado centrado ---
            Paragraph titulo = new Paragraph("ORDEN DE COMPRA", fontTitulo);
            titulo.Alignment = Element.ALIGN_CENTER;
            documento.Add(titulo);
            documento.Add(new Paragraph("\n"));

            // --- Línea con datos básicos ---
            string infoLinea = $"Número: {ordenCompra.nroOrden_327LG} | " +
                               $"Fecha: {ordenCompra.Fecha_327LG.ToShortDateString()} | " +
                               $"Estado: {ordenCompra.Estado_327LG}";

            Paragraph info = new Paragraph(infoLinea, fontTexto);
            info.Alignment = Element.ALIGN_CENTER;
            documento.Add(info);

            documento.Add(new Paragraph("\n"));


            // --- Línea divisoria ---
            var linea = new LineSeparator(1f, 100f, BaseColor.GRAY, Element.ALIGN_CENTER, -2);
            documento.Add(new Chunk(linea));
            documento.Add(new Paragraph("\n"));

            // --- Distribuidor ---
            documento.Add(new Paragraph("Datos del Distribuidor", fontSubTitulo));
            documento.Add(new Paragraph("\n"));
            documento.Add(new Paragraph($"CUIT: {ordenCompra.Distribuidor_327LG.CUIT_327LG}", fontTexto));
            documento.Add(new Paragraph($"Empresa: {ordenCompra.Distribuidor_327LG.Empresa_327LG}", fontTexto));
            documento.Add(new Paragraph($"Email: {ordenCompra.Distribuidor_327LG.Correo_327LG}", fontTexto));
            documento.Add(new Paragraph($"Teléfono: {ordenCompra.Distribuidor_327LG.Telefono_327LG}", fontTexto));
            documento.Add(new Paragraph("\n"));

            documento.Add(new Chunk(linea));
            documento.Add(new Paragraph("\n"));

            // --- Pago ---
            documento.Add(new Paragraph("Datos de Pago", fontSubTitulo));
            documento.Add(new Paragraph("\n"));
            documento.Add(new Paragraph($"Banco: {ordenCompra.Banco_327LG}", fontTexto));
            documento.Add(new Paragraph($"CBU: {ordenCompra.CBU_327LG}", fontTexto));
            documento.Add(new Paragraph($"Titular: {ordenCompra.NombreTitular_327LG}", fontTexto));
            documento.Add(new Paragraph($"N° Tarjeta: {ordenCompra.NroTarjeta_327LG}", fontTexto));
            documento.Add(new Paragraph("\n"));

            documento.Add(new Chunk(linea));
            documento.Add(new Paragraph("\n"));

            // --- Detalle de libros ---
            documento.Add(new Paragraph("Detalle de Libros Solicitados", fontSubTitulo));
            documento.Add(new Paragraph("\n"));

            PdfPTable tabla = new PdfPTable(4);
            tabla.WidthPercentage = 100;
            tabla.SetWidths(new float[] { 20, 45, 15, 20 });

            // Encabezados
            string[] headers = { "ISBN", "Título", "Cantidad", "Precio Unitario" };
            foreach (var h in headers)
            {
                PdfPCell cell = new PdfPCell(new Phrase(h, fontNegrita));
                cell.BackgroundColor = new BaseColor(230, 230, 230);
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.Padding = 5;
                tabla.AddCell(cell);
            }

            // Filas
            foreach (var detalle in ordenCompra.LibrosSolcitados_327LG)
            {
                tabla.AddCell(new Phrase(detalle.libro_327LG.ISBN_327LG, fontTexto));
                tabla.AddCell(new Phrase(detalle.libro_327LG.titulo_327LG, fontTexto));
                tabla.AddCell(new Phrase(detalle.Cantidad_327LG.ToString(), fontTexto));
                tabla.AddCell(new Phrase($"${detalle.PrecioUnitario_327LG:N2}", fontTexto));
            }

            documento.Add(tabla);

            documento.Add(new Paragraph("\n"));
            documento.Add(new Paragraph($"Total: ${ordenCompra.Total_327LG:N2}", fontSubTitulo));

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
                catch { }
            });
        }



        public List<BEOrdenCompraDetalle_327LG> ObtenerDetalles_327LG(string nroOrdenSeleccionada)
        {
            return dalOrdenCompra_327LG.ObtenerDetalles_327LG(nroOrdenSeleccionada);
        }

        public List<BEOrdenCompra_327LG> ObtenerOrdenesCompra_327LG()
        {
            return dalOrdenCompra_327LG.ObtenerOrdenesCompra_327LG();
        }

        private BEOrdenCompra_327LG ObtenerUltimaOrden_327LG()
        {
            return dalOrdenCompra_327LG.ObtenerUltimaOrden_327LG();
        }
    }
}
