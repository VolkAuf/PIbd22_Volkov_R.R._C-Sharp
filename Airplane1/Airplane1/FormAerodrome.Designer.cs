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
            this.buttonSetAirplane = new System.Windows.Forms.Button();
            this.buttonSetAirbus = new System.Windows.Forms.Button();
            this.groupBoxAerodrome = new System.Windows.Forms.GroupBox();
            this.buttonTakeAirplane = new System.Windows.Forms.Button();
            this.maskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.labelPlace = new System.Windows.Forms.Label();
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
            this.pictureBoxAerodrome.Size = new System.Drawing.Size(700, 450);
            this.pictureBoxAerodrome.TabIndex = 0;
            this.pictureBoxAerodrome.TabStop = false;
            // 
            // buttonSetAirplane
            // 
            this.buttonSetAirplane.Location = new System.Drawing.Point(705, 21);
            this.buttonSetAirplane.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSetAirplane.Name = "buttonSetAirplane";
            this.buttonSetAirplane.Size = new System.Drawing.Size(120, 50);
            this.buttonSetAirplane.TabIndex = 1;
            this.buttonSetAirplane.Text = "Припарковать Самолёт";
            this.buttonSetAirplane.UseVisualStyleBackColor = true;
            this.buttonSetAirplane.Click += new System.EventHandler(this.buttonSetAirplane_Click);
            // 
            // buttonSetAirbus
            // 
            this.buttonSetAirbus.Location = new System.Drawing.Point(705, 90);
            this.buttonSetAirbus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSetAirbus.Name = "buttonSetAirbus";
            this.buttonSetAirbus.Size = new System.Drawing.Size(120, 50);
            this.buttonSetAirbus.TabIndex = 2;
            this.buttonSetAirbus.Text = "Припарковать Аэробус";
            this.buttonSetAirbus.UseVisualStyleBackColor = true;
            this.buttonSetAirbus.Click += new System.EventHandler(this.buttonSetAirbus_Click);
            // 
            // groupBoxAerodrome
            // 
            this.groupBoxAerodrome.Controls.Add(this.buttonTakeAirplane);
            this.groupBoxAerodrome.Controls.Add(this.maskedTextBox);
            this.groupBoxAerodrome.Controls.Add(this.labelPlace);
            this.groupBoxAerodrome.Location = new System.Drawing.Point(705, 205);
            this.groupBoxAerodrome.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxAerodrome.Name = "groupBoxAerodrome";
            this.groupBoxAerodrome.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxAerodrome.Size = new System.Drawing.Size(130, 118);
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
            // maskedTextBox
            // 
            this.maskedTextBox.Location = new System.Drawing.Point(65, 55);
            this.maskedTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.maskedTextBox.Mask = "0";
            this.maskedTextBox.Name = "maskedTextBox";
            this.maskedTextBox.Size = new System.Drawing.Size(39, 22);
            this.maskedTextBox.TabIndex = 1;
            this.maskedTextBox.ValidatingType = typeof(int);
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
            // FormAerodrome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 453);
            this.Controls.Add(this.groupBoxAerodrome);
            this.Controls.Add(this.buttonSetAirbus);
            this.Controls.Add(this.buttonSetAirplane);
            this.Controls.Add(this.pictureBoxAerodrome);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormAerodrome";
            this.Text = "Аэродром";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAerodrome)).EndInit();
            this.groupBoxAerodrome.ResumeLayout(false);
            this.groupBoxAerodrome.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxAerodrome;
        private System.Windows.Forms.Button buttonSetAirplane;
        private System.Windows.Forms.Button buttonSetAirbus;
        private System.Windows.Forms.GroupBox groupBoxAerodrome;
        private System.Windows.Forms.Button buttonTakeAirplane;
        private System.Windows.Forms.MaskedTextBox maskedTextBox;
        private System.Windows.Forms.Label labelPlace;
    }
}