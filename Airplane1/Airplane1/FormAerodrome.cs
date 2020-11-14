using System;
using System.Drawing;
using System.Windows.Forms;

namespace Airplane1
{
    public partial class FormAerodrome : Form
    {
        private readonly AerodromeCollection aerodromeCollection;

        public FormAerodrome()
        {
            InitializeComponent();
            aerodromeCollection = new AerodromeCollection(pictureBoxAerodrome.Width, pictureBoxAerodrome.Height);
        }

        /// <summary>
        /// Заполнение listBoxLevels
        /// </summary>
        private void ReloadLevels()
        {
            int index = listBoxAerodrome.SelectedIndex;
            listBoxAerodrome.Items.Clear();
            for (int i = 0; i < aerodromeCollection.Keys.Count; i++)
            {
                listBoxAerodrome.Items.Add(aerodromeCollection.Keys[i]);
            }
            if (listBoxAerodrome.Items.Count > 0 && (index == -1 || index >= listBoxAerodrome.Items.Count))
            {
                listBoxAerodrome.SelectedIndex = 0;
            }
            else if (listBoxAerodrome.Items.Count > 0 && index > -1 && index < listBoxAerodrome.Items.Count)
            {
                listBoxAerodrome.SelectedIndex = index;
            }
        }

        public void Draw()
        {
            if (listBoxAerodrome.SelectedIndex > -1)
            {
                Bitmap bmp = new Bitmap(pictureBoxAerodrome.Width, pictureBoxAerodrome.Height);
                Graphics gr = Graphics.FromImage(bmp);
                aerodromeCollection[listBoxAerodrome.SelectedItem.ToString()].Draw(gr);
                pictureBoxAerodrome.Image = bmp;
            }
        }

        private void buttonAddAerodrome_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNewLevel.Text))
            {
                MessageBox.Show("Get Aerodrome Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            aerodromeCollection.AddAerodrome(textBoxNewLevel.Text);
            ReloadLevels();
        }

        private void buttonDeleteAerodrome_Click(object sender, EventArgs e)
        {
            if (listBoxAerodrome.SelectedIndex > -1)
            {
                if (MessageBox.Show($"Delete aerodrome {listBoxAerodrome.SelectedItem.ToString()}?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    aerodromeCollection.DeleteAerodrome(listBoxAerodrome.SelectedItem.ToString());
                    ReloadLevels();
                }
                Draw();
            }
        }


        private void buttonSetAirplane_Click(object sender, EventArgs e)
        {
            if (listBoxAerodrome.SelectedIndex > -1)
            {
                ColorDialog dialog = new ColorDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Airplane airplane = new Airplane(100, 1000, dialog.Color);
                    if (aerodromeCollection[listBoxAerodrome.SelectedItem.ToString()] + airplane)
                    {
                        Draw();
                    }
                    else
                    {
                        MessageBox.Show("Aerodrome is full");
                    }
                }
            }
        }

        private void buttonSetAirbus_Click(object sender, EventArgs e)
        {
            if (listBoxAerodrome.SelectedIndex > -1)
            {
                ColorDialog dialog = new ColorDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ColorDialog dialogDop = new ColorDialog();

                    if (dialogDop.ShowDialog() == DialogResult.OK)
                    {
                        Airbus airplane = new Airbus(100, 1000, dialog.Color, dialogDop.Color, true, true, true, true, true, true);

                        if (aerodromeCollection[listBoxAerodrome.SelectedItem.ToString()] + airplane)
                        {
                            Draw();
                        }
                        else
                        {
                            MessageBox.Show("Aerodrome is full");
                        }
                    }
                }
            }
        }

        private void buttonTakeAirplane_Click(object sender, EventArgs e)
        {
            if (listBoxAerodrome.SelectedIndex > -1 && maskedTextBoxNumber.Text != "")
            {
                var airplane = aerodromeCollection[listBoxAerodrome.SelectedItem.ToString()] - Convert.ToInt32(maskedTextBoxNumber.Text);

                if (airplane != null)
                {
                    FormAirplane form = new FormAirplane();
                    form.setAirplane(airplane);
                    form.ShowDialog();
                }
                Draw();
            }
        }

        private void listBoxAerodrome_SelectedIndexChanged(object sender, EventArgs e)
        {
            Draw();
        }

        private void buttonAddAirTransport_Click(object sender, EventArgs e)
        {
            var formAirplaneConfig = new FormAirplaneConfig();
            formAirplaneConfig.AddEvent(AddAirplane);
            formAirplaneConfig.Show();
        }

        private void AddAirplane(AirTransport airTransport)
        {
            if (airTransport != null && listBoxAerodrome.SelectedIndex > -1)
            {
                if ((aerodromeCollection[listBoxAerodrome.SelectedItem.ToString()]) + airTransport)
                {
                    Draw();
                }
                else
                {
                    MessageBox.Show("The airplane failed to deliver");
                }
            }
        }
    }
}
