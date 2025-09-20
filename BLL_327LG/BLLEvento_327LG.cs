using DAL_327LG;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Services_327LG;
using Services_327LG.Observer_327LG;
using System.Diagnostics;

namespace BLL_327LG
{
    public class BLLEvento_327LG
    {
        DALEvento_327LG dalEvento = new DALEvento_327LG();
        LanguageManager_327LG LM_327;

        public BLLEvento_327LG()
        {
            LM_327 = LanguageManager_327LG.Instance_327LG;
        }
        public List<Evento_327LG> ObtenerEventos_327LG(string? login, DateTime? fechaInicio, DateTime? fechaFin, string? modulo, string? evento, int? criticidad)
        {
            LM_327.CargarFormulario_327LG("FormBitacoraEventos_327LG");
            List<Evento_327LG> eventos = new List<Evento_327LG>();
            if (fechaInicio > fechaFin) throw new Exception(LM_327.ObtenerString("exception.fechasInvalidas"));
            eventos = dalEvento.ObtenerEventos_327LG(login, fechaInicio, fechaFin, modulo, evento, criticidad);
            return eventos;
        }

        public void RegistrarEvento_327LG(string dni, string modulo, string evento, int criticidad)
        {
            string id = string.Empty;
            int numero = 1;

            //Generar ID del evento con codigo de fecha y numero de evento del dia
            Evento_327LG ultimoEvento = ObtenerUltimoEvento_327LG();
            if (ultimoEvento != null)
            {
                var partes = ultimoEvento.IdEvento_327LG.ToString().Split('-');
                DateTime Fecha = DateTime.ParseExact(partes[0], "yyyyMMdd", null);
                if (Fecha.Date == DateTime.Now.Date) numero = int.Parse(partes[1]) + 1;
            }
            id = DateTime.Now.ToString("yyyyMMdd") + "-" + numero.ToString("D3");

            //Registrar evento
            Evento_327LG evento_327LG = new Evento_327LG(id, dni, DateTime.Now, modulo, evento, criticidad);
            dalEvento.RegistrarEvento_327LG(evento_327LG);
        }

        public Evento_327LG ObtenerUltimoEvento_327LG()
        {
            return dalEvento.ObtenerUltimoEvento_327LG();
        }

        public void ImprimirEventos_327LG(List<Evento_327LG> listaEventos, string rutaArchivo)
        {
            Document doc = new Document(PageSize.A4, 10, 10, 10, 10);
            try
            {
                PdfWriter.GetInstance(doc, new FileStream(rutaArchivo, FileMode.Create));
                doc.Open();

                var fuenteTitulo = new iTextSharp.text.Font(Font.FontFamily.HELVETICA, 16, iTextSharp.text.Font.BOLD);
                var fuenteEncabezado = new iTextSharp.text.Font(Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD, BaseColor.WHITE);
                var fuenteTexto = new iTextSharp.text.Font(Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.NORMAL);

                Paragraph titulo = new Paragraph(LM_327.ObtenerString("label.lblTitulo"), fuenteTitulo);
                titulo.Alignment = Element.ALIGN_CENTER;
                titulo.SpacingAfter = 20;
                doc.Add(titulo);

                PdfPTable tabla = new PdfPTable(7);
                tabla.WidthPercentage = 100;
                tabla.SetWidths(new float[] { 10, 12, 12, 10, 15, 31, 12 }); 

                string[] encabezados = {
                    LM_327.ObtenerString("datagridview.column.idEvento"),
                    "Login",
                    LM_327.ObtenerString("datagridview.column.fecha"),
                    LM_327.ObtenerString("datagridview.column.hora"),
                    LM_327.ObtenerString("datagridview.column.modulo"),
                    LM_327.ObtenerString("datagridview.column.evento"),
                    LM_327.ObtenerString("datagridview.column.criticidad")
                };

                foreach (var enc in encabezados)
                {
                    PdfPCell celda = new PdfPCell(new Phrase(enc, fuenteEncabezado));
                    celda.BackgroundColor = new BaseColor(64, 64, 64); 
                    celda.HorizontalAlignment = Element.ALIGN_CENTER;
                    celda.VerticalAlignment = Element.ALIGN_MIDDLE;
                    celda.Padding = 6f;
                    tabla.AddCell(celda);
                }

                bool alternar = false;
                foreach (var ev in listaEventos)
                {
                    BaseColor fondo = alternar ? new BaseColor(240, 240, 240) : BaseColor.WHITE;

                    tabla.AddCell(CrearCelda(ev.IdEvento_327LG.ToString(), fuenteTexto, fondo));
                    tabla.AddCell(CrearCelda(ev.Login_327LG, fuenteTexto, fondo));
                    tabla.AddCell(CrearCelda(ev.Fecha_327LG.ToShortDateString(), fuenteTexto, fondo));
                    tabla.AddCell(CrearCelda(ev.Hora_327LG.ToString(@"hh\:mm"), fuenteTexto, fondo));
                    tabla.AddCell(CrearCelda(ev.Modulo_327LG, fuenteTexto, fondo));
                    tabla.AddCell(CrearCelda(ev.evento_327LG, fuenteTexto, fondo));
                    tabla.AddCell(CrearCelda(ev.Criticidad_327LG.ToString(), fuenteTexto, fondo));

                    alternar = !alternar;
                }

                doc.Add(tabla);
            }
            finally
            {
                doc.Close();
            }

            Process.Start(new ProcessStartInfo(rutaArchivo) { UseShellExecute = true });
        }

        private PdfPCell CrearCelda(string texto, iTextSharp.text.Font fuente, BaseColor fondo)
        {
            PdfPCell celda = new PdfPCell(new Phrase(texto, fuente));
            celda.HorizontalAlignment = Element.ALIGN_CENTER;
            celda.VerticalAlignment = Element.ALIGN_MIDDLE;
            celda.Padding = 5f;
            celda.BackgroundColor = fondo;
            return celda;
        }


    }
}

