namespace La_Lupita_Kika.Views.Staff
{
    partial class CashOutdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CashOutdit));
            label1 = new Label();
            label2 = new Label();
            caja_textbox = new Components.RJTextBox();
            day_textbox = new Components.RJTextBox();
            rjButton1 = new Components.RJButton();
            rjButton2 = new Components.RJButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift SemiBold", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(48, 13);
            label1.Name = "label1";
            label1.Size = new Size(183, 34);
            label1.TabIndex = 0;
            label1.Text = "Monto del dia";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bahnschrift SemiBold", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(46, 107);
            label2.Name = "label2";
            label2.Size = new Size(191, 34);
            label2.TabIndex = 1;
            label2.Text = "Monto en caja";
            // 
            // caja_textbox
            // 
            caja_textbox.BackColor = SystemColors.Window;
            caja_textbox.BorderColor = Color.FromArgb(224, 224, 224);
            caja_textbox.BorderFocusColor = Color.FromArgb(255, 54, 112);
            caja_textbox.BorderRadius = 10;
            caja_textbox.BorderSize = 2;
            caja_textbox.Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            caja_textbox.ForeColor = Color.FromArgb(64, 64, 64);
            caja_textbox.Location = new Point(46, 154);
            caja_textbox.Margin = new Padding(4);
            caja_textbox.Multiline = false;
            caja_textbox.Name = "caja_textbox";
            caja_textbox.Padding = new Padding(10, 7, 10, 7);
            caja_textbox.PasswordChar = false;
            caja_textbox.PlaceholderColor = Color.DarkGray;
            caja_textbox.PlaceholderText = "";
            caja_textbox.ReadOnly = false;
            caja_textbox.Size = new Size(185, 35);
            caja_textbox.TabIndex = 7;
            caja_textbox.TextAlign = ContentAlignment.MiddleCenter;
            caja_textbox.Texts = "";
            caja_textbox.UnderlinedStyle = false;
            // 
            // day_textbox
            // 
            day_textbox.BackColor = SystemColors.Window;
            day_textbox.BorderColor = Color.FromArgb(224, 224, 224);
            day_textbox.BorderFocusColor = Color.FromArgb(255, 54, 112);
            day_textbox.BorderRadius = 10;
            day_textbox.BorderSize = 2;
            day_textbox.Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            day_textbox.ForeColor = Color.FromArgb(64, 64, 64);
            day_textbox.Location = new Point(48, 56);
            day_textbox.Margin = new Padding(4);
            day_textbox.Multiline = false;
            day_textbox.Name = "day_textbox";
            day_textbox.Padding = new Padding(10, 7, 10, 7);
            day_textbox.PasswordChar = false;
            day_textbox.PlaceholderColor = Color.DarkGray;
            day_textbox.PlaceholderText = "";
            day_textbox.ReadOnly = true;
            day_textbox.Size = new Size(183, 35);
            day_textbox.TabIndex = 8;
            day_textbox.TextAlign = ContentAlignment.MiddleCenter;
            day_textbox.Texts = "";
            day_textbox.UnderlinedStyle = false;
            // 
            // rjButton1
            // 
            rjButton1.BackColor = Color.White;
            rjButton1.BackgroundColor = Color.White;
            rjButton1.BorderColor = Color.FromArgb(27, 186, 182);
            rjButton1.BorderRadius = 10;
            rjButton1.BorderSize = 3;
            rjButton1.FlatAppearance.BorderSize = 0;
            rjButton1.FlatStyle = FlatStyle.Flat;
            rjButton1.Font = new Font("Bahnschrift SemiBold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            rjButton1.ForeColor = Color.Black;
            rjButton1.Location = new Point(12, 234);
            rjButton1.Name = "rjButton1";
            rjButton1.Size = new Size(115, 50);
            rjButton1.TabIndex = 9;
            rjButton1.Text = "Aceptar";
            rjButton1.TextColor = Color.Black;
            rjButton1.UseVisualStyleBackColor = false;
            rjButton1.Click += rjButton1_Click;
            // 
            // rjButton2
            // 
            rjButton2.BackColor = Color.White;
            rjButton2.BackgroundColor = Color.White;
            rjButton2.BorderColor = Color.FromArgb(255, 54, 112);
            rjButton2.BorderRadius = 10;
            rjButton2.BorderSize = 3;
            rjButton2.FlatAppearance.BorderSize = 0;
            rjButton2.FlatStyle = FlatStyle.Flat;
            rjButton2.Font = new Font("Bahnschrift SemiBold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            rjButton2.ForeColor = Color.Black;
            rjButton2.Location = new Point(161, 234);
            rjButton2.Name = "rjButton2";
            rjButton2.Size = new Size(115, 50);
            rjButton2.TabIndex = 10;
            rjButton2.Text = "Reportar";
            rjButton2.TextColor = Color.Black;
            rjButton2.UseVisualStyleBackColor = false;
            rjButton2.Click += rjButton2_Click;
            // 
            // CashOutdit
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(288, 295);
            Controls.Add(rjButton2);
            Controls.Add(rjButton1);
            Controls.Add(day_textbox);
            Controls.Add(caja_textbox);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CashOutdit";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CashOutdit";
            Load += CashOutdit_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button Accept_button;
        private Button Report_button;
        private TextBox Cash_textBox;
        private Components.RJTextBox rjTextBox1;
        private Components.RJTextBox caja_textbox;
        private Components.RJTextBox day_textbox;
        private Components.RJButton rjButton1;
        private Components.RJButton rjButton2;
    }
}