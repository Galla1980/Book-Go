using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI_327LG
{
    public class MessageBoxPersonalizado
    {
        private MessageBoxPersonalizado() { }

        public static DialogResult Show(string mensaje, string titulo, string textoBotonAceptar, MessageBoxIcon icono)
        {
            return MostrarFormulario(mensaje, titulo, textoBotonAceptar, null, icono);
        }

        public static DialogResult Show(string mensaje, string titulo, string textoBotonAceptar, string textoBotonCancelar, MessageBoxIcon icono)
        {
            return MostrarFormulario(mensaje, titulo, textoBotonAceptar, textoBotonCancelar, icono);
        }

        private static DialogResult MostrarFormulario(string mensaje, string titulo, string textoAceptar, string textoCancelar, MessageBoxIcon icono)
        {
            using (Form form = new Form())
            {
                form.Text = titulo;
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterScreen;
                form.MinimizeBox = false;
                form.MaximizeBox = false;
                form.ShowInTaskbar = false;

                Font font = SystemFonts.MessageBoxFont;

                int maxTextWidth = 400;
                int padding = 20;
                int spacing = 12;
                int iconSize = 35;

                Size textoSize = TextRenderer.MeasureText(mensaje, font, new Size(maxTextWidth, 0), TextFormatFlags.WordBreak);

                PictureBox iconoBox = new PictureBox
                {
                    Size = new Size(iconSize, iconSize),
                    Location = new Point(padding, padding + 5),
                    Image = ObtenerIcono(icono),
                    SizeMode = PictureBoxSizeMode.StretchImage
                };

                Label label = new Label
                {
                    Text = mensaje,
                    Font = font,
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Location = new Point(padding + iconSize + spacing, padding+10),
                    Size = new Size(textoSize.Width, textoSize.Height)
                };

                int contentWidth = iconoBox.Right + spacing + textoSize.Width;
                int contentHeight = Math.Max(iconoBox.Bottom, label.Bottom) + padding;

                Button btnAceptar = new Button
                {
                    Text = textoAceptar,
                    DialogResult = textoCancelar == null ? DialogResult.OK : DialogResult.Yes,
                    Size = new Size(90, 30)
                };

                Button btnCancelar = null;
                if (textoCancelar != null)
                {
                    btnCancelar = new Button
                    {
                        Text = textoCancelar,
                        DialogResult = DialogResult.No,
                        Size = new Size(90, 30)
                    };
                }

                int botonesY = contentHeight + spacing;
                int botonesAncho = btnCancelar == null
                    ? btnAceptar.Width
                    : btnAceptar.Width + btnCancelar.Width + spacing;

                int totalWidth = Math.Max(label.Right + padding, botonesAncho + 2 * padding);

                btnAceptar.Location = new Point((totalWidth - botonesAncho) / 2, botonesY);
                if (btnCancelar != null)
                    btnCancelar.Location = new Point(btnAceptar.Right + spacing, botonesY);

                // Ajustes finales
                form.ClientSize = new Size(totalWidth, botonesY + btnAceptar.Height + padding);
                form.Controls.AddRange(new Control[] { iconoBox, label, btnAceptar });
                if (btnCancelar != null) form.Controls.Add(btnCancelar);

                form.AcceptButton = btnAceptar;
                form.CancelButton = btnCancelar;

                return form.ShowDialog();
            }
        }
        private static Image ObtenerIcono(MessageBoxIcon icono)
        {
            switch (icono)
            {
                case MessageBoxIcon.Error:
                    return SystemIcons.Error.ToBitmap();
                case MessageBoxIcon.Information:
                    return SystemIcons.Information.ToBitmap();
                case MessageBoxIcon.Question:
                    return SystemIcons.Question.ToBitmap();
                case MessageBoxIcon.Warning:
                    return SystemIcons.Warning.ToBitmap();
                default:
                    return null;
            }
        }
    }
}
