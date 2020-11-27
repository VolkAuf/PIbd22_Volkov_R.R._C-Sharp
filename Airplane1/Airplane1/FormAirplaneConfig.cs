using System;
using System.Drawing;
using System.Windows.Forms;

namespace Airplane1
{
    public partial class FormAirplaneConfig : Form
    {
        private AirTransport airplane = null;
        private Action<AirTransport> eventAddAirplane;

        public FormAirplaneConfig()
        {
            InitializeComponent();
            panelBLACK.MouseDown += panelColor_MouseDown;
            panelBLUE.MouseDown += panelColor_MouseDown;
            panelGRAY.MouseDown += panelColor_MouseDown;
            panelGREEN.MouseDown += panelColor_MouseDown;
            panelORENGE.MouseDown += panelColor_MouseDown;
            panelREAD.MouseDown += panelColor_MouseDown;
            panelWHITE.MouseDown += panelColor_MouseDown;
            panelYELLOW.MouseDown += panelColor_MouseDown;
            buttonCancel.Click += (object sender, EventArgs e) => { Close(); };
        }

        private void panelColor_MouseDown(object sender, MouseEventArgs e)
        {
            Control panelColor = (Control)sender;
            panelColor.DoDragDrop(panelColor.BackColor, DragDropEffects.Move | DragDropEffects.Copy);
        }

        private void labelBaseColor_DragEnter(object sender, DragEventArgs e)
        {
            // Прописать логику проверки приходящего значения на тип Color
            if (e.Data.GetDataPresent(typeof(Color)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void labelBaseColor_DragDrop(object sender, DragEventArgs e)
        {
            if (airplane != null)
            {
                airplane.SetMainColor((Color)e.Data.GetData(typeof(Color)));
                DrawAirplane();
            }
        }

        private void labelDopColor_DragDrop(object sender, DragEventArgs e)
        {
            if (airplane is Airbus)
            {
                Airbus airbus = (Airbus)airplane;
                airbus.SetDopColor((Color)e.Data.GetData(typeof(Color)));
                DrawAirplane();
            }
        }

        private void DrawAirplane()
        {
            if (airplane != null)
            {
                Bitmap bmp = new Bitmap(pictureBoxModelTransport.Width, pictureBoxModelTransport.Height);
                Graphics gr = Graphics.FromImage(bmp);
                airplane.SetPosition(5, 50, pictureBoxModelTransport.Width, pictureBoxModelTransport.Height);
                airplane.DrawTransport(gr);
                pictureBoxModelTransport.Image = bmp;
            }
        }

        public void AddEvent(Action<AirTransport> ev)
        {
            if (eventAddAirplane == null)
            {
                eventAddAirplane = new Action<AirTransport>(ev);
            }
            else
            {
                eventAddAirplane += ev;
            }
        }

        private void labelAirplane_MouseDown(object sender, MouseEventArgs e)
        {
            labelAirplane.DoDragDrop(labelAirplane.Text, DragDropEffects.Move | DragDropEffects.Copy);
        }

        private void labelAirbus_MauseDown(object sender, MouseEventArgs e)
        {
            labelAirbus.DoDragDrop(labelAirbus.Text, DragDropEffects.Move | DragDropEffects.Copy);
        }

        private void panelModelTransport_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void panelModelTransport_DragDrop(object sender, DragEventArgs e)
        {
            switch (e.Data.GetData(DataFormats.Text).ToString())
            {
                case "Airplane":
                    airplane = new Airplane((int)numericUpDownMaxSpeed.Value, (int)numericUpDownWeight.Value, Color.Cyan);
                    break;
                case "Airbus":
                    airplane = new Airbus((int)numericUpDownMaxSpeed.Value, (int)numericUpDownWeight.Value, Color.Cyan, Color.Black,
                    checkBoxBackTurbin.Checked, checkBoxSideTurbin.Checked, checkBoxMarketLine.Checked, checkBoxRegulTail.Checked, checkBoxIlluminator.Checked, checkBoxSecondFloor.Checked);
                    break;
            }
            DrawAirplane();
        }

        private void buttonAddTransport_Click(object sender, EventArgs e)
        {
            eventAddAirplane(airplane);
            Close();
        }
    }
}