using NLog;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Airplane1
{
    public partial class FormAerodrome : Form
    {
        private readonly AerodromeCollection aerodromeCollection;

        /// <summary>
        /// Логгер
        /// </summary>
        private readonly Logger logger;

        public FormAerodrome()
        {
            InitializeComponent();
            aerodromeCollection = new AerodromeCollection(pictureBoxAerodrome.Width, pictureBoxAerodrome.Height);
            logger = LogManager.GetCurrentClassLogger();
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
            Bitmap bmp = new Bitmap(pictureBoxAerodrome.Width, pictureBoxAerodrome.Height);
            Graphics gr = Graphics.FromImage(bmp);
            if (listBoxAerodrome.SelectedIndex > -1)
            {
                aerodromeCollection[listBoxAerodrome.SelectedItem.ToString()].Draw(gr);
            }
            pictureBoxAerodrome.Image = bmp;
        }

        private void buttonAddAerodrome_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNewLevel.Text))
            {
                MessageBox.Show("Get Aerodrome Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            logger.Info($"Set aerodrome {textBoxNewLevel.Text}");
            aerodromeCollection.AddAerodrome(textBoxNewLevel.Text);
            ReloadLevels();
        }

        private void buttonDeleteAerodrome_Click(object sender, EventArgs e)
        {
            if (listBoxAerodrome.SelectedIndex > -1)
            {
                if (MessageBox.Show($"Delete aerodrome {listBoxAerodrome.SelectedItem.ToString()}?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    logger.Info($"Delete aerodrome {listBoxAerodrome.SelectedItem.ToString()}");
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
                try
                {
                    AirTransport airplane = aerodromeCollection[listBoxAerodrome.SelectedItem.ToString()] - Convert.ToInt32(maskedTextBoxNumber.Text);

                    if (airplane != null)
                    {
                        FormAirplane form = new FormAirplane();
                        form.setAirplane(airplane);
                        form.ShowDialog();

                        logger.Info($"Take airplane {airplane} in place {maskedTextBoxNumber.Text}");

                        Draw();
                    }
                }
                catch (AerodromeNotFoundException ex)
                {
                    MessageBox.Show(ex.Message, "Not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Warn("Not found");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Unknown Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Warn("Unknown Error");
                }
            }
        }

        private void listBoxAerodrome_SelectedIndexChanged(object sender, EventArgs e)
        {
            logger.Info($"Moved to the aerodrome {listBoxAerodrome.SelectedItem.ToString()}");
            Draw();
        }

        private void buttonAddAirTransport_Click(object sender, EventArgs e)
        {
            FormAirplaneConfig formAirplaneConfig = new FormAirplaneConfig();
            formAirplaneConfig.AddEvent(AddAirplane);
            formAirplaneConfig.Show();
        }

        private void AddAirplane(AirTransport airTransport)
        {
            if (airTransport != null && listBoxAerodrome.SelectedIndex > -1)
            {
                try
                {
                    if ((aerodromeCollection[listBoxAerodrome.SelectedItem.ToString()]) + airTransport)
                    {
                        Draw();
                        logger.Info($"Set airplane {airTransport}");
                    }
                    else
                    {
                        MessageBox.Show("The airplane failed to deliver");
                    }
                    Draw();
                }
                catch (AerodromeOverflowException ex)
                {
                    MessageBox.Show(ex.Message, "Overflow", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Warn("Overflow");
                }
                catch (AerodromeAlreadyHaveException ex)
                {
                    MessageBox.Show(ex.Message, "Duplication", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Warn("Duplication");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Unknow Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Warn("unknow Error");
                }
            }
        }

        /// <summary>
        /// Обработка нажатия пункта меню "Save"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    aerodromeCollection.SaveData(saveFileDialog.FileName);
                    MessageBox.Show("Saved successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    logger.Info("Saved file " + saveFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Uncnown Error saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Warn("Uncnown Error saved");
                }
            }
        }

        /// <summary>
        /// Обработка нажатия пункта меню "Download"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    aerodromeCollection.LoadData(openFileDialog.FileName);
                    MessageBox.Show("Download", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    logger.Info("Loaded from file " + openFileDialog.FileName);
                    ReloadLevels();
                    Draw();
                }
                catch (AerodromeOccupiedPlaceException ex)
                {
                    MessageBox.Show(ex.Message, "Occupied places", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Warn("Occupied places");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Unknown Error download", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Warn("Unknown Error download");
                }
            }
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            if (listBoxAerodrome.SelectedIndex > -1)
            {
                aerodromeCollection[listBoxAerodrome.SelectedItem.ToString()].Sort();
                Draw();
                logger.Info("Sort level");
            }
        }
    }
}
