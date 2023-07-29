namespace La_Lupita_Kika
{
    public partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            sqlCommandBuilder1 = new Microsoft.Data.SqlClient.SqlCommandBuilder();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            sqlCommandBuilder2 = new Microsoft.Data.SqlClient.SqlCommandBuilder();
            pictureBox1 = new PictureBox();
            Username_textBox = new Views.Components.RJTextBox();
            Pass_textBox = new Views.Components.RJTextBox();
            Login_button = new Views.Components.RJButton();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.LOGO_LETRAS;
            pictureBox1.Location = new Point(89, 54);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(164, 99);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // Username_textBox
            // 
            Username_textBox.BackColor = SystemColors.Window;
            Username_textBox.BorderColor = Color.Silver;
            Username_textBox.BorderFocusColor = Color.FromArgb(224, 224, 224);
            Username_textBox.BorderRadius = 10;
            Username_textBox.BorderSize = 2;
            Username_textBox.Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            Username_textBox.ForeColor = Color.FromArgb(64, 64, 64);
            Username_textBox.Location = new Point(26, 169);
            Username_textBox.Margin = new Padding(4);
            Username_textBox.Multiline = false;
            Username_textBox.Name = "Username_textBox";
            Username_textBox.Padding = new Padding(10, 7, 10, 7);
            Username_textBox.PasswordChar = false;
            Username_textBox.PlaceholderColor = Color.DarkGray;
            Username_textBox.PlaceholderText = "Usuario";
            Username_textBox.ReadOnly = false;
            Username_textBox.Size = new Size(312, 35);
            Username_textBox.TabIndex = 5;
            Username_textBox.Texts = "";
            Username_textBox.UnderlinedStyle = true;
            // 
            // Pass_textBox
            // 
            Pass_textBox.BackColor = SystemColors.Window;
            Pass_textBox.BorderColor = Color.Silver;
            Pass_textBox.BorderFocusColor = Color.FromArgb(224, 224, 224);
            Pass_textBox.BorderRadius = 10;
            Pass_textBox.BorderSize = 2;
            Pass_textBox.Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            Pass_textBox.ForeColor = Color.FromArgb(64, 64, 64);
            Pass_textBox.Location = new Point(26, 225);
            Pass_textBox.Margin = new Padding(4);
            Pass_textBox.Multiline = false;
            Pass_textBox.Name = "Pass_textBox";
            Pass_textBox.Padding = new Padding(10, 7, 10, 7);
            Pass_textBox.PasswordChar = true;
            Pass_textBox.PlaceholderColor = Color.DarkGray;
            Pass_textBox.PlaceholderText = "Contraseña";
            Pass_textBox.ReadOnly = false;
            Pass_textBox.Size = new Size(312, 35);
            Pass_textBox.TabIndex = 6;
            Pass_textBox.Texts = "";
            Pass_textBox.UnderlinedStyle = true;
            Pass_textBox._TextChanged += Pass_textBox__TextChanged;
            Pass_textBox.KeyPress += Pass_textBox_KeyPress;
            // 
            // Login_button
            // 
            Login_button.BackColor = Color.White;
            Login_button.BackgroundColor = Color.White;
            Login_button.BorderColor = Color.FromArgb(255, 54, 112);
            Login_button.BorderRadius = 10;
            Login_button.BorderSize = 2;
            Login_button.FlatAppearance.BorderSize = 0;
            Login_button.FlatStyle = FlatStyle.Flat;
            Login_button.Font = new Font("Bahnschrift SemiBold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            Login_button.ForeColor = Color.Black;
            Login_button.Location = new Point(89, 310);
            Login_button.Name = "Login_button";
            Login_button.Size = new Size(188, 50);
            Login_button.TabIndex = 7;
            Login_button.Text = "Ingresar";
            Login_button.TextColor = Color.Black;
            Login_button.UseVisualStyleBackColor = false;
            Login_button.Click += Login_button_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(360, 421);
            Controls.Add(Login_button);
            Controls.Add(Pass_textBox);
            Controls.Add(Username_textBox);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ingresar";
            Load += Form1_Load;
            ResizeEnd += Login_ResizeEnd;
            Paint += Login_Paint;
            MouseDown += Login_MouseDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Data.SqlClient.SqlCommandBuilder sqlCommandBuilder1;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private Microsoft.Data.SqlClient.SqlCommandBuilder sqlCommandBuilder2;
        private PictureBox pictureBox1;
        private Views.Components.RJTextBox Username_textBox;
        private Views.Components.RJTextBox Pass_textBox;
        private Views.Components.RJButton Login_button;
    }
}