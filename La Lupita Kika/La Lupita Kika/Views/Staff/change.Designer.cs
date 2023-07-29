namespace La_Lupita_Kika.Views.Staff
{
    partial class change
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(change));
            label1 = new Label();
            Change_texbox = new Components.RJTextBox();
            rjButton1 = new Components.RJButton();
            PictureBoxLogo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)PictureBoxLogo).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift SemiBold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(265, 24);
            label1.Name = "label1";
            label1.Size = new Size(116, 36);
            label1.TabIndex = 0;
            label1.Text = "Cambio";
            // 
            // Change_texbox
            // 
            Change_texbox.BackColor = SystemColors.Window;
            Change_texbox.BorderColor = Color.FromArgb(255, 54, 112);
            Change_texbox.BorderFocusColor = Color.HotPink;
            Change_texbox.BorderRadius = 10;
            Change_texbox.BorderSize = 2;
            Change_texbox.Font = new Font("Bahnschrift SemiBold", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            Change_texbox.ForeColor = Color.FromArgb(64, 64, 64);
            Change_texbox.Location = new Point(268, 77);
            Change_texbox.Margin = new Padding(7, 4, 4, 4);
            Change_texbox.Multiline = false;
            Change_texbox.Name = "Change_texbox";
            Change_texbox.Padding = new Padding(10, 7, 10, 7);
            Change_texbox.PasswordChar = false;
            Change_texbox.PlaceholderColor = Color.DarkGray;
            Change_texbox.PlaceholderText = "";
            Change_texbox.ReadOnly = true;
            Change_texbox.Size = new Size(107, 43);
            Change_texbox.TabIndex = 1;
            Change_texbox.TextAlign = ContentAlignment.MiddleCenter;
            Change_texbox.Texts = "";
            Change_texbox.UnderlinedStyle = true;
            // 
            // rjButton1
            // 
            rjButton1.BackColor = Color.White;
            rjButton1.BackgroundColor = Color.White;
            rjButton1.BorderColor = Color.FromArgb(255, 54, 112);
            rjButton1.BorderRadius = 20;
            rjButton1.BorderSize = 3;
            rjButton1.FlatAppearance.BorderSize = 0;
            rjButton1.FlatStyle = FlatStyle.Flat;
            rjButton1.Font = new Font("Bahnschrift SemiBold", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            rjButton1.ForeColor = Color.Black;
            rjButton1.Location = new Point(223, 228);
            rjButton1.Name = "rjButton1";
            rjButton1.Size = new Size(188, 50);
            rjButton1.TabIndex = 3;
            rjButton1.Text = "Finalizar";
            rjButton1.TextColor = Color.Black;
            rjButton1.UseVisualStyleBackColor = false;
            rjButton1.Click += rjButton1_Click;
            // 
            // PictureBoxLogo
            // 
            PictureBoxLogo.Image = Properties.Resources.LOGO_2_LA_LUPITAKIKA__1_;
            PictureBoxLogo.Location = new Point(12, 12);
            PictureBoxLogo.Name = "PictureBoxLogo";
            PictureBoxLogo.Size = new Size(84, 68);
            PictureBoxLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBoxLogo.TabIndex = 4;
            PictureBoxLogo.TabStop = false;
            PictureBoxLogo.Visible = false;
            // 
            // change
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(648, 290);
            Controls.Add(PictureBoxLogo);
            Controls.Add(rjButton1);
            Controls.Add(Change_texbox);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "change";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cambio";
            Load += change_Load;
            ((System.ComponentModel.ISupportInitialize)PictureBoxLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Components.RJTextBox Change_texbox;
        private Label label2;
        private Components.RJButton rjButton1;
        private PictureBox PictureBoxLogo;
    }
}