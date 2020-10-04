using System;
using System.Drawing;
using System.Windows.Forms;

namespace Airplane1
{
    public partial class FormAirplane : Form
    {

        private ITransport airplan;

        public FormAirplane()
        {
            InitializeComponent();
        }

        public void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxAirplane.Width, pictureBoxAirplane.Height);
            Graphics gr = Graphics.FromImage(bmp);
            airplan.DrawTransport(gr);
            pictureBoxAirplane.Image = bmp;
        }

        private void buttonCreateAirbus_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            airplan = new Airbus(rnd.Next(150, 300), rnd.Next(1000, 2000), Color.LightSteelBlue, Color.Red, true, true, true, true, true, true);
            airplan.SetPosition(rnd.Next(120, 150), rnd.Next(70, 100), pictureBoxAirplane.Width,
            pictureBoxAirplane.Height);
            Draw();
        }

        private void buttonCreateAirplane_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            airplan = new Airplane(rnd.Next(150, 300), rnd.Next(1000, 2000), Color.LightSteelBlue);
            airplan.SetPosition(rnd.Next(120, 150), rnd.Next(70, 100), pictureBoxAirplane.Width,
            pictureBoxAirplane.Height);
            Draw();
        }

        private void buttonMove_Click(object sender, EventArgs e)
        {
            if (airplan != null)
            {
                //получаем имя кнопки
                string name = (sender as Button).Name;
                switch (name)
                {
                    case "buttonUp":
                        airplan.MoveTransport(Direction.Up);
                        break;
                    case "buttonDown":
                        airplan.MoveTransport(Direction.Down);
                        break;
                    case "buttonLeft":
                        airplan.MoveTransport(Direction.Left);
                        break;
                    case "buttonRight":
                        airplan.MoveTransport(Direction.Right);
                        break;
                }
                Draw();
            }
        }
    }
}
