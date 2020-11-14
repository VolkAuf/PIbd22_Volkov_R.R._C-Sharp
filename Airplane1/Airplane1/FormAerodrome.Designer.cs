namespace Airplane1
{
    partial class FormAerodrome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxAerodrome = new System.Windows.Forms.PictureBox();
            this.groupBoxAerodrome = new System.Windows.Forms.GroupBox();
            this.buttonTakeAirplane = new System.Windows.Forms.Button();
            this.maskedTextBoxNumber = new System.Windows.Forms.MaskedTextBox();
            this.labelPlace = new System.Windows.Forms.Label();
            this.listBoxAerodrome = new System.Windows.Forms.ListBox();
            this.textBoxNewLevel = new System.Windows.Forms.TextBox();
            this.labelAerodromeStage = new System.Windows.Forms.Label();
            this.buttonAddAerodrome = new System.Windows.Forms.Button();
            this.buttonDeleteAerodrome = new System.Windows.Forms.Button();
            this.buttonAddAirTransport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAerodrome)).BeginInit();
            this.groupBoxAerodrome.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxAerodrome
            // 
            this.pictureBoxAerodrome.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBoxAerodrome.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pictureBoxAerodrome.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxAerodrome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxAerodrome.Name = "pictureBoxAerodrome";
            this.pictureBoxAerodrome.Size = new System.Drawing.Size(830, 540);
            this.pictureBoxAerodrome.TabIndex = 0;
            this.pictureBoxAerodrome.TabStop = false;
            // 
            // groupBoxAerodrome
            // 
            this.groupBoxAerodrome.Controls.Add(this.buttonTakeAirplane);
            this.groupBoxAerodrome.Controls.Add(this.maskedTextBoxNumber);
            this.groupBoxAerodrome.Controls.Add(this.labelPlace);
            this.groupBoxAerodrome.Location = new System.Drawing.Point(840, 420);
            this.groupBoxAerodrome.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxAerodrome.Name = "groupBoxAerodrome";
            this.groupBoxAerodrome.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxAerodrome.Size = new System.Drawing.Size(130, 120);
            this.groupBoxAerodrome.TabIndex = 3;
            this.groupBoxAerodrome.TabStop = false;
            this.groupBoxAerodrome.Text = "Забрать лётное средство";
            // 
            // buttonTakeAirplane
            // 
            this.buttonTakeAirplane.Location = new System.Drawing.Point(20, 86);
            this.buttonTakeAirplane.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTakeAirplane.Name = "buttonTakeAirplane";
            this.buttonTakeAirplane.Size = new System.Drawing.Size(107, 25);
            this.buttonTakeAirplane.TabIndex = 2;
            this.buttonTakeAirplane.Text = "Забрать";
            this.buttonTakeAirplane.UseVisualStyleBackColor = true;
            this.buttonTakeAirplane.Click += new System.EventHandler(this.buttonTakeAirplane_Click);
            // 
            // maskedTextBoxNumber
            // 
            this.maskedTextBoxNumber.Location = new System.Drawing.Point(65, 55);
            this.maskedTextBoxNumber.Margin = new System.Windows.Forms.Padding(4);
            this.maskedTextBoxNumber.Mask = "0";
            this.maskedTextBoxNumber.Name = "maskedTextBoxNumber";
            this.maskedTextBoxNumber.Size = new System.Drawing.Size(39, 22);
            this.maskedTextBoxNumber.TabIndex = 1;
            this.maskedTextBoxNumber.ValidatingType = typeof(int);
            // 
            // labelPlace
            // 
            this.labelPlace.AutoSize = true;
            this.labelPlace.Location = new System.Drawing.Point(10, 55);
            this.labelPlace.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPlace.Name = "labelPlace";
            this.labelPlace.Size = new System.Drawing.Size(49, 17);
            this.labelPlace.TabIndex = 0;
            this.labelPlace.Text = "Место";
            // 
            // listBoxAerodrome
            // 
            this.listBoxAerodrome.FormattingEnabled = true;
            this.listBoxAerodrome.ItemHeight = 16;
            this.listBoxAerodrome.Location = new System.Drawing.Point(840, 130);
            this.listBoxAerodrome.Name = "listBoxAerodrome";
            this.listBoxAerodrome.Size = new System.Drawing.Size(130, 116);
            this.listBoxAerodrome.TabIndex = 4;
            this.listBoxAerodrome.SelectedIndexChanged += new System.EventHandler(this.listBoxAerodrome_SelectedIndexChanged);
            // 
            // textBoxNewLevel
            // 
            this.textBoxNewLevel.Location = new System.Drawing.Point(840, 50);
            this.textBoxNewLevel.Name = "textBoxNewLevel";
            this.textBoxNewLevel.Size = new System.Drawing.Size(130, 22);
            this.textBoxNewLevel.TabIndex = 5;
            // 
            // labelAerodromeStage
            // 
            this.labelAerodromeStage.AutoSize = true;
            this.labelAerodromeStage.Location = new System.Drawing.Point(840, 25);
            this.labelAerodromeStage.Name = "labelAerodromeStage";
            this.labelAerodromeStage.Size = new System.Drawing.Size(117, 17);
            this.labelAerodromeStage.TabIndex = 6;
            this.labelAerodromeStage.Text = "Aerodrome stage";
            // 
            // buttonAddAerodrome
            // 
            this.buttonAddAerodrome.Location = new System.Drawing.Point(840, 80);
            this.buttonAddAerodrome.Name = "buttonAddAerodrome";
            this.buttonAddAerodrome.Size = new System.Drawing.Size(130, 45);
            this.buttonAddAerodrome.TabIndex = 7;
            this.buttonAddAerodrome.Text = "Add Aerodrome";
            this.buttonAddAerodrome.UseVisualStyleBackColor = true;
            this.buttonAddAerodrome.Click += new System.EventHandler(this.buttonAddAerodrome_Click);
            // 
            // buttonDeleteAerodrome
            // 
            this.buttonDeleteAerodrome.Location = new System.Drawing.Point(840, 250);
            this.buttonDeleteAerodrome.Name = "buttonDeleteAerodrome";
            this.buttonDeleteAerodrome.Size = new System.Drawing.Size(130, 45);
            this.buttonDeleteAerodrome.TabIndex = 8;
            this.buttonDeleteAerodrome.Text = "Delete Aerodrome";
            this.buttonDeleteAerodrome.UseVisualStyleBackColor = true;
            this.buttonDeleteAerodrome.Click += new System.EventHandler(this.buttonDeleteAerodrome_Click);
            // 
            // buttonAddAirTransport
            // 
            this.buttonAddAirTransport.Location = new System.Drawing.Point(840, 320);
            this.buttonAddAirTransport.Name = "buttonAddAirTransport";
            this.buttonAddAirTransport.Size = new System.Drawing.Size(130, 70);
            this.buttonAddAirTransport.TabIndex = 9;
            this.buttonAddAirTransport.Text = "Add AirTransport";
            this.buttonAddAirTransport.UseVisualStyleBackColor = true;
            this.buttonAddAirTransport.Click += new System.EventHandler(this.buttonAddAirTransport_Click);
            // 
            // FormAerodrome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.buttonAddAirTransport);
            this.Controls.Add(this.buttonDeleteAerodrome);
            this.Controls.Add(this.buttonAddAerodrome);
            this.Controls.Add(this.labelAerodromeStage);
            this.Controls.Add(this.textBoxNewLevel);
            this.Controls.Add(this.listBoxAerodrome);
            this.Controls.Add(this.groupBoxAerodrome);
            this.Controls.Add(this.pictureBoxAerodrome);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormAerodrome";
            this.Text = "Аэродром";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAerodrome)).EndInit();
            this.groupBoxAerodrome.ResumeLayout(false);
            this.groupBoxAerodrome.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxAerodrome;
        private System.Windows.Forms.GroupBox groupBoxAerodrome;
        private System.Windows.Forms.Button buttonTakeAirplane;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxNumber;
        private System.Windows.Forms.Label labelPlace;
        private System.Windows.Forms.ListBox listBoxAerodrome;
        private System.Windows.Forms.TextBox textBoxNewLevel;
        private System.Windows.Forms.Label labelAerodromeStage;
        private System.Windows.Forms.Button buttonAddAerodrome;
        private System.Windows.Forms.Button buttonDeleteAerodrome;
        private System.Windows.Forms.Button buttonAddAirTransport;
    }
}