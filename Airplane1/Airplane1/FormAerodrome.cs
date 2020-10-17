using System;
using System.Drawing;
using System.Windows.Forms;

namespace Airplane1
{
    public partial class FormAerodrome : Form
    {
        private readonly Aerodrome<Airplane> aerodrome;

        public FormAerodrome()
        {
            InitializeComponent();
            aerodrome = new Aerodrome<Airplane>(pictureBoxAerodrome.Width, pictureBoxAerodrome.Height);
            Draw();
        }
        public void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxAerodrome.Width, pictureBoxAerodrome.Height);
            Graphics gr = Graphics.FromImage(bmp);
            aerodrome.Draw(gr);
            pictureBoxAerodrome.Image = bmp;
        }

        private void buttonSetAirplane_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Airplane airplane = new Airplane(100, 1000, dialog.Color);
                if (aerodrome + airplane)
                {
                    Draw();
                }
                else
                {
                    MessageBox.Show("Парковка переполнена");
                }
            }
        }

        private void buttonSetAirbus_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ColorDialog dialogDop = new ColorDialog();
                if (dialogDop.ShowDialog() == DialogResult.OK)
                {
                    Airbus airbus = new Airbus(100, 1000, dialog.Color, dialogDop.Color, true, true, true, true, true, true);
                    if (aerodrome + airbus)
                    {
                        Draw();
                    }
                    else
                    {
                        MessageBox.Show("Парковка переполнена");
                    }
                }
            }
        }

        private void buttonTakeAirplane_Click(object sender, EventArgs e)
        {
            if (maskedTextBox.Text != "")
            {
                int index = Convert.ToInt32(maskedTextBox.Text);
                if (index >= 0 && index < 9)
                {
                    Airplane airplane = aerodrome - index;
                    if (airplane != null)
                    {
                        FormAirplane form = new FormAirplane();
                        form.setAirplane(airplane);
                        form.ShowDialog();
                    }
                    Draw();
                }
            }
        }
    }
}
