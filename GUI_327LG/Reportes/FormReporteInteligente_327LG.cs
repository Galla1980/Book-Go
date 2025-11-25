using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BLL_327LG;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing.Imaging;

namespace GUI_327LG.Reportes
{
    public partial class FormReporteInteligente_327LG : Form
    {
        BLLReporteInteligente_327LG bllReporteInteligente;

        public FormReporteInteligente_327LG()
        {
            InitializeComponent();
            bllReporteInteligente = new BLLReporteInteligente_327LG();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var rankingLibros = bllReporteInteligente.ObtenerRankingLibros_327LG();
            var rankingClientes = bllReporteInteligente.ObtenerRankingClientesSancionados_327LG();
            var serieMensual = bllReporteInteligente.ObtenerSeriePrestamosMensual_327LG();

            if (rankingLibros.Count == 0 && rankingClientes.Count == 0 && serieMensual.Count == 0)
            {
                MessageBox.Show("No hay datos disponibles para generar el reporte combinado.");
                return;
            }

            GenerarPDFCombinado(rankingLibros, rankingClientes, serieMensual);
        }

        private void GenerarPDFCombinado(
            List<(string Titulo, int Cantidad)> rankingLibros,
            List<(string NombreCompleto, int TotalSanciones)> rankingClientes,
            List<(string Periodo, int TotalPrestamos)> serieMensual)
        {
            string imgLibrosPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + "_Libros.png");
            string imgClientesPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + "_Clientes.png");
            string imgSeriePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + "_Serie.png");
            string pdfPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + "_ReporteCombinado.pdf");

            if (rankingLibros.Count > 0)
            {
                GenerarGrafico(rankingLibros, imgLibrosPath, "Ranking de Libros Más Prestados", "Cantidad de Préstamos");
            }

            if (rankingClientes.Count > 0)
            {
                GenerarGrafico(rankingClientes, imgClientesPath, "Ranking de Riesgo de Cliente", "Total de Sanciones");
            }

            if (serieMensual.Count > 0)
            {
                GenerarGraficoLineal(serieMensual, imgSeriePath);
            }

            Document doc = new Document(PageSize.A4);
            List<string> tempFiles = new List<string> { pdfPath };

            try
            {
                using (var fs = new FileStream(pdfPath, FileMode.Create))
                {
                    PdfWriter.GetInstance(doc, fs);
                    doc.Open();

                    var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 22, new BaseColor(50, 50, 50));
                    var subtitleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, new BaseColor(80, 80, 80));

                    Paragraph mainTitle = new Paragraph("Reporte de Desempeño y Riesgo de la Biblioteca", titleFont);
                    mainTitle.Alignment = Element.ALIGN_CENTER;
                    doc.Add(mainTitle);
                    doc.Add(new Paragraph("\n\n"));

                    // --- Sección 1: Ranking de Libros (Barras) ---
                    if (File.Exists(imgLibrosPath))
                    {
                        tempFiles.Add(imgLibrosPath);
                        Paragraph section1Title = new Paragraph("1. Análisis de Popularidad de Libros", subtitleFont);
                        section1Title.Alignment = Element.ALIGN_CENTER;
                        doc.Add(section1Title);
                        doc.Add(new Paragraph("\n"));

                        var img = iTextSharp.text.Image.GetInstance(imgLibrosPath);
                        img.ScaleToFit(500f, 400f);
                        img.Alignment = Element.ALIGN_CENTER;
                        doc.Add(img);
                        doc.Add(new Paragraph("\n\n"));
                        doc.NewPage();
                    }

                    // --- Sección 2: Ranking de Clientes (Barras) ---
                    if (File.Exists(imgClientesPath))
                    {
                        tempFiles.Add(imgClientesPath);
                        Paragraph section2Title = new Paragraph("2. Perfil de Riesgo de Clientes Sancionados", subtitleFont);
                        section2Title.Alignment = Element.ALIGN_CENTER;
                        doc.Add(section2Title);
                        doc.Add(new Paragraph("\n"));

                        var img = iTextSharp.text.Image.GetInstance(imgClientesPath);
                        img.ScaleToFit(500f, 400f);
                        img.Alignment = Element.ALIGN_CENTER;
                        doc.Add(img);
                        doc.Add(new Paragraph("\n\n"));
                        doc.NewPage();
                    }

                    // --- Sección 3: Serie Temporal (Línea) ---
                    if (File.Exists(imgSeriePath))
                    {
                        tempFiles.Add(imgSeriePath);
                        Paragraph section3Title = new Paragraph("3. Serie Histórica de Préstamos Mensuales", subtitleFont);
                        section3Title.Alignment = Element.ALIGN_CENTER;
                        doc.Add(section3Title);
                        doc.Add(new Paragraph("\n"));

                        var img = iTextSharp.text.Image.GetInstance(imgSeriePath);
                        img.ScaleToFit(500f, 400f);
                        img.Alignment = Element.ALIGN_CENTER;
                        doc.Add(img);
                    }

                    if (!File.Exists(imgLibrosPath) && !File.Exists(imgClientesPath) && !File.Exists(imgSeriePath))
                    {
                        doc.Add(new Paragraph("No hay datos suficientes para generar gráficos en este momento.", titleFont));
                    }

                    doc.Close();
                }

                var p = new System.Diagnostics.Process();
                p.StartInfo.FileName = pdfPath;
                p.StartInfo.UseShellExecute = true;
                p.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar o abrir el PDF: {ex.Message}");
            }
            finally
            {
                var timer = new System.Windows.Forms.Timer();
                timer.Interval = 10000;
                timer.Tick += (s2, e2) =>
                {
                    timer.Stop();
                    foreach (string file in tempFiles)
                    {
                        try { if (File.Exists(file)) File.Delete(file); } catch { }
                    }
                };
                timer.Start();
            }
        }

        // --- Generar Grafico de BARRAS ---
        private void GenerarGrafico(List<(string Nombre, int Cantidad)> datos, string outputPath, string chartTitle, string labelEjeY)
        {
            int width = 800;
            int height = 500;

            Bitmap bmp = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.Clear(Color.FromArgb(245, 245, 245));

            int marginLeft = 100;
            int marginRight = 50;
            int marginTop = 80;
            int marginBottom = 100;

            int chartWidth = width - marginLeft - marginRight;
            int chartHeight = height - marginBottom - marginTop;

            g.FillRectangle(Brushes.White, marginLeft, marginTop, chartWidth, chartHeight);
            g.DrawRectangle(new Pen(Color.LightGray, 1), marginLeft, marginTop, chartWidth, chartHeight);

            int max = datos.Max(x => x.Cantidad);
            int maxScale = (int)(Math.Ceiling(max / 5.0) * 5);
            if (maxScale == 0 && max > 0) maxScale = max;
            if (maxScale == 0) maxScale = 5;

            float barSpacing = 25;
            float totalBarWidths = chartWidth - (datos.Count - 1) * barSpacing;
            float barWidth = totalBarWidths / datos.Count;
            if (barWidth > 80) barWidth = 80;

            float totalContentWidth = datos.Count * barWidth + (datos.Count - 1) * barSpacing;
            float initialXOffset = marginLeft + (chartWidth - totalContentWidth) / 2;
            if (initialXOffset < marginLeft) initialXOffset = marginLeft;

            Pen axisPen = new Pen(Color.FromArgb(80, 80, 80), 2);
            System.Drawing.Font labelFont = new System.Drawing.Font("Arial", 9, FontStyle.Regular);
            System.Drawing.Font valueFont = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
            System.Drawing.Font chartTitleFont = new System.Drawing.Font("Arial", 14, FontStyle.Bold);

            SizeF chartTitleSize = g.MeasureString(chartTitle, chartTitleFont);
            g.DrawString(chartTitle, chartTitleFont, Brushes.Black,
                marginLeft + (chartWidth - chartTitleSize.Width) / 2,
                marginTop - 40);

            g.DrawLine(axisPen, marginLeft, marginTop + chartHeight, marginLeft + chartWidth, marginTop + chartHeight);
            g.DrawLine(axisPen, marginLeft, marginTop + chartHeight, marginLeft, marginTop);

            Color[] barColors = new Color[]
            {
                Color.FromArgb(100, 181, 246),
                Color.FromArgb(144, 202, 249),
                Color.FromArgb(66, 165, 245),
                Color.FromArgb(33, 150, 243),
                Color.FromArgb(21, 101, 192),
                Color.FromArgb(179, 157, 219),
                Color.FromArgb(121, 134, 203),
                Color.FromArgb(92, 107, 192),
                Color.FromArgb(255, 179, 0),
                Color.FromArgb(255, 159, 0)
            };

            int numTicks = 5;
            int tickValue = maxScale / numTicks;

            for (int i = 0; i <= numTicks; i++)
            {
                int value = i * tickValue;
                float yPos = marginTop + chartHeight - (value / (float)maxScale) * chartHeight;

                g.DrawLine(axisPen, marginLeft - 5, yPos, marginLeft, yPos);
                g.DrawString(value.ToString(), labelFont, Brushes.Black, marginLeft - 45, yPos - 8);

                if (i > 0 && i < numTicks)
                {
                    g.DrawLine(new Pen(Color.LightGray, 1), marginLeft + 1, yPos, marginLeft + chartWidth - 1, yPos);
                }
            }

            GraphicsState stateY = g.Save();
            float centerY = marginTop + chartHeight / 2;
            float centerX = marginLeft - 70;
            g.TranslateTransform(centerX, centerY);
            g.RotateTransform(270);
            StringFormat sfY = new StringFormat();
            sfY.Alignment = StringAlignment.Center;
            sfY.LineAlignment = StringAlignment.Center;
            g.DrawString(labelEjeY, valueFont, Brushes.Black, 0, 0, sfY);
            g.Restore(stateY);

            for (int i = 0; i < datos.Count; i++)
            {
                float barHeight = (datos[i].Cantidad / (float)maxScale) * chartHeight;
                float x = initialXOffset + i * (barWidth + barSpacing);
                float y = marginTop + chartHeight - barHeight;

                Brush barBrush = new SolidBrush(barColors[i % barColors.Length]);
                g.FillRectangle(barBrush, x, y, barWidth, barHeight);
                g.DrawRectangle(new Pen(Color.FromArgb(50, 50, 50), 1), x, y, barWidth, barHeight);

                SizeF valueLabelSize = g.MeasureString(datos[i].Cantidad.ToString(), valueFont);
                g.DrawString(datos[i].Cantidad.ToString(), valueFont, Brushes.Black,
                    x + (barWidth - valueLabelSize.Width) / 2,
                    y - valueLabelSize.Height - 5);

                StringFormat sfX = new StringFormat();
                sfX.Alignment = StringAlignment.Near;
                sfX.LineAlignment = StringAlignment.Near;

                GraphicsState state = g.Save();

                g.TranslateTransform(x + barWidth / 2, marginTop + chartHeight + 10);
                g.RotateTransform(45);

                g.DrawString(datos[i].Nombre, labelFont, Brushes.Black, new PointF(0, 0), sfX);

                g.Restore(state);
            }

            g.Save();
            bmp.Save(outputPath, ImageFormat.Png);
            g.Dispose();
            bmp.Dispose();
        }

        // --- Generar Grafico LINEAL ---
        private void GenerarGraficoLineal(List<(string Periodo, int TotalPrestamos)> datos, string outputPath)
        {
            int width = 800;
            int height = 500;

            Bitmap bmp = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.Clear(Color.FromArgb(245, 245, 245));

            int marginLeft = 80;
            int marginRight = 50;
            int marginTop = 80;
            int marginBottom = 100;

            int chartWidth = width - marginLeft - marginRight;
            int chartHeight = height - marginBottom - marginTop;

            g.FillRectangle(Brushes.White, marginLeft, marginTop, chartWidth, chartHeight);
            g.DrawRectangle(new Pen(Color.LightGray, 1), marginLeft, marginTop, chartWidth, chartHeight);

            int max = datos.Max(x => x.TotalPrestamos);
            int maxScale = (int)(Math.Ceiling(max / 5.0) * 5);
            if (maxScale == 0) maxScale = 5;

            Pen axisPen = new Pen(Color.FromArgb(80, 80, 80), 2);
            Pen linePen = new Pen(Color.FromArgb(255, 100, 0), 3);
            System.Drawing.Font labelFont = new System.Drawing.Font("Arial", 9);
            System.Drawing.Font valueFont = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
            System.Drawing.Font chartTitleFont = new System.Drawing.Font("Arial", 14, FontStyle.Bold);

            string chartTitle = "Serie Mensual de Préstamos";
            SizeF chartTitleSize = g.MeasureString(chartTitle, chartTitleFont);
            g.DrawString(chartTitle, chartTitleFont, Brushes.Black,
                marginLeft + (chartWidth - chartTitleSize.Width) / 2,
                marginTop - 40);

            g.DrawLine(axisPen, marginLeft, marginTop + chartHeight, marginLeft + chartWidth, marginTop + chartHeight);
            g.DrawLine(axisPen, marginLeft, marginTop + chartHeight, marginLeft, marginTop);

            int numTicks = 5;
            int tickValue = maxScale / numTicks;

            for (int i = 0; i <= numTicks; i++)
            {
                int value = i * tickValue;
                float yPos = marginTop + chartHeight - (value / (float)maxScale) * chartHeight;

                g.DrawLine(axisPen, marginLeft - 5, yPos, marginLeft, yPos);
                g.DrawString(value.ToString(), labelFont, Brushes.Black, marginLeft - 45, yPos - 8);

                if (i > 0 && i < numTicks)
                {
                    g.DrawLine(new Pen(Color.LightGray, 1), marginLeft + 1, yPos, marginLeft + chartWidth - 1, yPos);
                }
            }

            GraphicsState stateY = g.Save();
            g.TranslateTransform(marginLeft - 70, marginTop + chartHeight / 2);
            g.RotateTransform(270);
            StringFormat sfY = new StringFormat();
            sfY.Alignment = StringAlignment.Center;
            sfY.LineAlignment = StringAlignment.Center;
            g.DrawString("Total de Préstamos", valueFont, Brushes.Black, 0, 0, sfY);
            g.Restore(stateY);

            PointF[] points = new PointF[datos.Count];
            float xStep = (float)chartWidth / (datos.Count > 1 ? datos.Count - 1 : 1);

            for (int i = 0; i < datos.Count; i++)
            {
                float xPos = marginLeft + (datos.Count > 1 ? i * xStep : chartWidth / 2);
                float yPos = marginTop + chartHeight - (datos[i].TotalPrestamos / (float)maxScale) * chartHeight;

                points[i] = new PointF(xPos, yPos);

                g.FillEllipse(linePen.Brush, xPos - 5, yPos - 5, 10, 10);

                g.DrawString(datos[i].TotalPrestamos.ToString(), valueFont, Brushes.Black,
                    xPos, yPos - 25, new StringFormat { Alignment = StringAlignment.Center });

                GraphicsState stateX = g.Save();
                g.TranslateTransform(xPos, marginTop + chartHeight + 10);
                g.RotateTransform(45);

                StringFormat sfX = new StringFormat();
                sfX.Alignment = StringAlignment.Near;
                sfX.LineAlignment = StringAlignment.Near;
                g.DrawString(datos[i].Periodo, labelFont, Brushes.Black, 0, 0, sfX);

                g.Restore(stateX);
            }

            if (datos.Count > 1)
            {
                g.DrawLines(linePen, points);
            }

            g.Save();
            bmp.Save(outputPath, ImageFormat.Png);
            g.Dispose();
            bmp.Dispose();
        }

        private void FormReporteInteligente_327LG_Load(object sender, EventArgs e)
        {
        }
    }
}