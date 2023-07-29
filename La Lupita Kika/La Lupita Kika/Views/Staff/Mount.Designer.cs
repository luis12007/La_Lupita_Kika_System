namespace La_Lupita_Kika.Views.Staff
{
    partial class Mount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mount));
            label = new Label();
            textBox = new Components.RJTextBox();
            button = new Components.RJButton();
            SuspendLayout();
            // 
            // label
            // 
            label.AutoSize = true;
            label.Font = new Font("Bahnschrift SemiBold", 14F, FontStyle.Bold, GraphicsUnit.Point);
            label.Location = new Point(64, 24);
            label.Name = "label";
            label.Size = new Size(257, 29);
            label.TabIndex = 0;
            label.Text = "Monto con que cancela";
            label.Click += label_Click;
            // 
            // textBox
            // 
            textBox.BackColor = SystemColors.Window;
            textBox.BorderColor = Color.FromArgb(224, 224, 224);
            textBox.BorderFocusColor = Color.HotPink;
            textBox.BorderRadius = 20;
            textBox.BorderSize = 2;
            textBox.Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            textBox.ForeColor = Color.FromArgb(64, 64, 64);
            textBox.Location = new Point(64, 70);
            textBox.Margin = new Padding(4);
            textBox.Multiline = false;
            textBox.Name = "textBox";
            textBox.Padding = new Padding(10, 7, 10, 7);
            textBox.PasswordChar = false;
            textBox.PlaceholderColor = Color.DarkGray;
            textBox.PlaceholderText = "";
            textBox.ReadOnly = false;
            textBox.Size = new Size(262, 35);
            textBox.TabIndex = 3;
            textBox.TextAlign = ContentAlignment.MiddleCenter;
            textBox.Texts = "";
            textBox.UnderlinedStyle = false;
            textBox._TextChanged += textBox__TextChanged;
            textBox.KeyPress += textBox_KeyPress;
            // 
            // button
            // 
            button.BackColor = Color.White;
            button.BackgroundColor = Color.White;
            button.BorderColor = Color.FromArgb(255, 54, 112);
            button.BorderRadius = 20;
            button.BorderSize = 2;
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font("Bahnschrift SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button.ForeColor = Color.Black;
            button.Location = new Point(103, 127);
            button.Name = "button";
            button.Size = new Size(188, 50);
            button.TabIndex = 4;
            button.Text = "Aceptar";
            button.TextColor = Color.Black;
            button.UseVisualStyleBackColor = false;
            button.Click += button_Click;
            // 
            // Mount
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(395, 210);
            Controls.Add(button);
            Controls.Add(textBox);
            Controls.Add(label);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Mount";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pago";
            Load += Mount_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label;
        private Components.RJTextBox textBox;
        private Components.RJButton button;
    }
}