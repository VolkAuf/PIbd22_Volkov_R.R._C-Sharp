using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airplane1
{
    public partial class FormAirplane : Form
    {

        private Airbus airplan;

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

        private void FormAirplane_Load(object sender, EventArgs e)
        {

        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            airplan = new Airbus(rnd.Next(150, 300), rnd.Next(1000, 2000), Color.LightSteelBlue, Color.Red, true, true, true, true,true,true);
            airplan.SetPosition(rnd.Next(120, 150), rnd.Next(70, 100), pictureBoxAirplane.Width,
            pictureBoxAirplane.Height);
            Draw();
            
        }

        private void buttonMove_Click(object sender, EventArgs e)
        {
            //получаем имя кнопки
            string name = (sender as Button).Name;
            switch (name)
            {
                case "buttonUp":
                    airplan.MoveAirTransport(Direction.Up);
                    break;
                case "buttonDown":
                    airplan.MoveAirTransport(Direction.Down);
                    break;
                case "buttonLeft":
                    airplan.MoveAirTransport(Direction.Left);
                    break;
                case "buttonRight":
                    airplan.MoveAirTransport(Direction.Right);
                    break;
            }
            Draw();
        }
    }
}
