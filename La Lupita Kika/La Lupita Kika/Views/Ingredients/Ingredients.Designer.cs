namespace La_Lupita_Kika.Views.Ingredients
{
    partial class Ingredients
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ingredients));
            Ingredients_dataGridView = new DataGridView();
            button1 = new Button();
            rjButton1 = new Components.RJButton();
            Add_button = new Components.RJButton();
            button2 = new Button();
            rjTextBox1 = new Components.RJTextBox();
            rjComboBox2 = new Components.RJComboBox();
            rjComboBox1 = new Components.RJComboBox();
            ((System.ComponentModel.ISupportInitialize)Ingredients_dataGridView).BeginInit();
            SuspendLayout();
            // 
            // Ingredients_dataGridView
            // 
            Ingredients_dataGridView.AllowUserToAddRows = false;
            Ingredients_dataGridView.AllowUserToDeleteRows = false;
            Ingredients_dataGridView.AllowUserToResizeColumns = false;
            Ingredients_dataGridView.AllowUserToResizeRows = false;
            Ingredients_dataGridView.BackgroundColor = Color.White;
            Ingredients_dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Bahnschrift", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            Ingredients_dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            Ingredients_dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Bahnschrift SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(152, 153, 182);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            Ingredients_dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            Ingredients_dataGridView.EnableHeadersVisualStyles = false;
            Ingredients_dataGridView.GridColor = Color.Black;
            Ingredients_dataGridView.Location = new Point(12, 98);
            Ingredients_dataGridView.Name = "Ingredients_dataGridView";
            Ingredients_dataGridView.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(255, 98, 133);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            Ingredients_dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            Ingredients_dataGridView.RowHeadersVisible = false;
            Ingredients_dataGridView.RowHeadersWidth = 51;
            Ingredients_dataGridView.RowTemplate.Height = 29;
            Ingredients_dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Ingredients_dataGridView.Size = new Size(1010, 387);
            Ingredients_dataGridView.TabIndex = 20;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.FlatAppearance.BorderColor = Color.White;
            button1.FlatAppearance.MouseDownBackColor = Color.White;
            button1.FlatAppearance.MouseOverBackColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = Properties.Resources.esquema_de_boton_circular_de_flecha_hacia_atras_izquierda__2_;
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(45, 40);
            button1.TabIndex = 21;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // rjButton1
            // 
            rjButton1.BackColor = Color.White;
            rjButton1.BackgroundColor = Color.White;
            rjButton1.BorderColor = Color.Green;
            rjButton1.BorderRadius = 20;
            rjButton1.BorderSize = 2;
            rjButton1.FlatAppearance.BorderSize = 0;
            rjButton1.FlatStyle = FlatStyle.Flat;
            rjButton1.Font = new Font("Bahnschrift", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            rjButton1.ForeColor = Color.Black;
            rjButton1.Location = new Point(782, 491);
            rjButton1.Name = "rjButton1";
            rjButton1.Size = new Size(240, 68);
            rjButton1.TabIndex = 23;
            rjButton1.Text = "Excel";
            rjButton1.TextColor = Color.Black;
            rjButton1.UseVisualStyleBackColor = false;
            // 
            // Add_button
            // 
            Add_button.BackColor = Color.White;
            Add_button.BackgroundColor = Color.White;
            Add_button.BorderColor = Color.FromArgb(255, 54, 112);
            Add_button.BorderRadius = 20;
            Add_button.BorderSize = 2;
            Add_button.FlatAppearance.BorderSize = 0;
            Add_button.FlatStyle = FlatStyle.Flat;
            Add_button.Font = new Font("Bahnschrift", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            Add_button.ForeColor = Color.Black;
            Add_button.Location = new Point(12, 491);
            Add_button.Name = "Add_button";
            Add_button.Size = new Size(240, 68);
            Add_button.TabIndex = 22;
            Add_button.Text = "Agregar";
            Add_button.TextColor = Color.Black;
            Add_button.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.Location = new Point(844, 54);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 33;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // rjTextBox1
            // 
            rjTextBox1.BackColor = SystemColors.Window;
            rjTextBox1.BorderColor = Color.MediumSlateBlue;
            rjTextBox1.BorderFocusColor = Color.HotPink;
            rjTextBox1.BorderRadius = 0;
            rjTextBox1.BorderSize = 2;
            rjTextBox1.Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            rjTextBox1.ForeColor = Color.FromArgb(64, 64, 64);
            rjTextBox1.Location = new Point(525, 54);
            rjTextBox1.Margin = new Padding(4);
            rjTextBox1.Multiline = false;
            rjTextBox1.Name = "rjTextBox1";
            rjTextBox1.Padding = new Padding(10, 7, 10, 7);
            rjTextBox1.PasswordChar = false;
            rjTextBox1.PlaceholderColor = Color.DarkGray;
            rjTextBox1.PlaceholderText = "";
            rjTextBox1.ReadOnly = false;
            rjTextBox1.Size = new Size(312, 35);
            rjTextBox1.TabIndex = 32;
            rjTextBox1.TextAlign = ContentAlignment.MiddleLeft;
            rjTextBox1.Texts = "";
            rjTextBox1.UnderlinedStyle = false;
            // 
            // rjComboBox2
            // 
            rjComboBox2.BackColor = Color.WhiteSmoke;
            rjComboBox2.BorderColor = Color.MediumSlateBlue;
            rjComboBox2.BorderSize = 1;
            rjComboBox2.DropDownStyle = ComboBoxStyle.DropDown;
            rjComboBox2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            rjComboBox2.ForeColor = Color.DimGray;
            rjComboBox2.IconColor = Color.MediumSlateBlue;
            rjComboBox2.ListBackColor = Color.FromArgb(230, 228, 245);
            rjComboBox2.ListTextColor = Color.DimGray;
            rjComboBox2.Location = new Point(268, 54);
            rjComboBox2.MinimumSize = new Size(200, 30);
            rjComboBox2.Name = "rjComboBox2";
            rjComboBox2.Padding = new Padding(1);
            rjComboBox2.Size = new Size(250, 38);
            rjComboBox2.TabIndex = 31;
            rjComboBox2.Texts = "";
            // 
            // rjComboBox1
            // 
            rjComboBox1.BackColor = Color.WhiteSmoke;
            rjComboBox1.BorderColor = Color.MediumSlateBlue;
            rjComboBox1.BorderSize = 1;
            rjComboBox1.DropDownStyle = ComboBoxStyle.DropDown;
            rjComboBox1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            rjComboBox1.ForeColor = Color.DimGray;
            rjComboBox1.IconColor = Color.MediumSlateBlue;
            rjComboBox1.ListBackColor = Color.FromArgb(230, 228, 245);
            rjComboBox1.ListTextColor = Color.DimGray;
            rjComboBox1.Location = new Point(12, 54);
            rjComboBox1.MinimumSize = new Size(200, 30);
            rjComboBox1.Name = "rjComboBox1";
            rjComboBox1.Padding = new Padding(1);
            rjComboBox1.Size = new Size(250, 38);
            rjComboBox1.TabIndex = 30;
            rjComboBox1.Texts = "";
            // 
            // Ingredients
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1036, 575);
            Controls.Add(button2);
            Controls.Add(rjTextBox1);
            Controls.Add(rjComboBox2);
            Controls.Add(rjComboBox1);
            Controls.Add(rjButton1);
            Controls.Add(Add_button);
            Controls.Add(button1);
            Controls.Add(Ingredients_dataGridView);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Ingredients";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ingredients";
            Load += Ingredients_Load;
            ((System.ComponentModel.ISupportInitialize)Ingredients_dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView Ingredients_dataGridView;
        private Button button1;
        private Components.RJButton rjButton1;
        private Components.RJButton Add_button;
        private Button button2;
        private Components.RJTextBox rjTextBox1;
        private Components.RJComboBox rjComboBox2;
        private Components.RJComboBox rjComboBox1;
    }
}