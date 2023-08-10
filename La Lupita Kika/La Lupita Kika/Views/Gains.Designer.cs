namespace La_Lupita_Kika.Views
{
    partial class Gains
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gains));
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            Subsidiary_cbb = new Components.RJComboBox();
            Total_label = new Label();
            button1 = new Button();
            Excel_Button = new Components.RJButton();
            label1 = new Label();
            label2 = new Label();
            rjButton1 = new Components.RJButton();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarTitleForeColor = Color.Silver;
            dateTimePicker1.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(473, 78);
            dateTimePicker1.MaxDate = new DateTime(2030, 11, 18, 0, 0, 0, 0);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(121, 32);
            dateTimePicker1.TabIndex = 5;
            dateTimePicker1.Value = new DateTime(2023, 8, 8, 0, 0, 0, 0);
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.CalendarTitleForeColor = Color.Silver;
            dateTimePicker2.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePicker2.Format = DateTimePickerFormat.Short;
            dateTimePicker2.Location = new Point(726, 77);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(127, 32);
            dateTimePicker2.TabIndex = 6;
            // 
            // Subsidiary_cbb
            // 
            Subsidiary_cbb.BackColor = Color.White;
            Subsidiary_cbb.BorderColor = Color.Silver;
            Subsidiary_cbb.BorderSize = 1;
            Subsidiary_cbb.DropDownStyle = ComboBoxStyle.DropDown;
            Subsidiary_cbb.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Subsidiary_cbb.ForeColor = Color.Black;
            Subsidiary_cbb.IconColor = Color.FromArgb(255, 54, 112);
            Subsidiary_cbb.ListBackColor = Color.FromArgb(230, 228, 245);
            Subsidiary_cbb.ListTextColor = Color.DimGray;
            Subsidiary_cbb.Location = new Point(12, 64);
            Subsidiary_cbb.MinimumSize = new Size(200, 30);
            Subsidiary_cbb.Name = "Subsidiary_cbb";
            Subsidiary_cbb.Padding = new Padding(1);
            Subsidiary_cbb.Size = new Size(200, 38);
            Subsidiary_cbb.TabIndex = 7;
            Subsidiary_cbb.Texts = "";
            // 
            // Total_label
            // 
            Total_label.AutoSize = true;
            Total_label.Font = new Font("Bahnschrift", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            Total_label.Location = new Point(12, 509);
            Total_label.Name = "Total_label";
            Total_label.Size = new Size(145, 41);
            Total_label.TabIndex = 8;
            Total_label.Text = "Total: 0$";
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.FlatAppearance.BorderColor = Color.White;
            button1.FlatAppearance.MouseDownBackColor = Color.White;
            button1.FlatAppearance.MouseOverBackColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = Properties.Resources.esquema_de_boton_circular_de_flecha_hacia_atras_izquierda__2_;
            button1.Location = new Point(12, 11);
            button1.Name = "button1";
            button1.Size = new Size(45, 40);
            button1.TabIndex = 22;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // Excel_Button
            // 
            Excel_Button.BackColor = Color.White;
            Excel_Button.BackgroundColor = Color.White;
            Excel_Button.BorderColor = Color.Green;
            Excel_Button.BorderRadius = 20;
            Excel_Button.BorderSize = 2;
            Excel_Button.FlatAppearance.BorderSize = 0;
            Excel_Button.FlatStyle = FlatStyle.Flat;
            Excel_Button.Font = new Font("Bahnschrift", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            Excel_Button.ForeColor = Color.Black;
            Excel_Button.Location = new Point(13, 564);
            Excel_Button.Name = "Excel_Button";
            Excel_Button.Size = new Size(144, 64);
            Excel_Button.TabIndex = 26;
            Excel_Button.Text = "Excel";
            Excel_Button.TextColor = Color.Black;
            Excel_Button.UseVisualStyleBackColor = false;
            Excel_Button.Click += Excel_Button_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(361, 73);
            label1.Name = "label1";
            label1.Size = new Size(112, 41);
            label1.TabIndex = 27;
            label1.Text = "Desde";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bahnschrift", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(614, 70);
            label2.Name = "label2";
            label2.Size = new Size(106, 41);
            label2.TabIndex = 28;
            label2.Text = "Hasta";
            label2.Click += label2_Click;
            // 
            // rjButton1
            // 
            rjButton1.BackColor = Color.White;
            rjButton1.BackgroundColor = Color.White;
            rjButton1.BorderColor = Color.FromArgb(255, 54, 112);
            rjButton1.BorderRadius = 20;
            rjButton1.BorderSize = 2;
            rjButton1.FlatAppearance.BorderSize = 0;
            rjButton1.FlatStyle = FlatStyle.Flat;
            rjButton1.Font = new Font("Bahnschrift", 36F, FontStyle.Regular, GraphicsUnit.Point);
            rjButton1.ForeColor = Color.Black;
            rjButton1.Location = new Point(259, 512);
            rjButton1.Name = "rjButton1";
            rjButton1.Size = new Size(594, 116);
            rjButton1.TabIndex = 29;
            rjButton1.Text = "Buscar";
            rjButton1.TextColor = Color.Black;
            rjButton1.UseVisualStyleBackColor = false;
            rjButton1.Click += rjButton1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Bahnschrift", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Bahnschrift SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(152, 153, 182);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.Black;
            dataGridView1.Location = new Point(12, 119);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(255, 98, 133);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(841, 387);
            dataGridView1.TabIndex = 30;
            // 
            // Gains
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(863, 640);
            Controls.Add(dataGridView1);
            Controls.Add(rjButton1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Excel_Button);
            Controls.Add(button1);
            Controls.Add(Total_label);
            Controls.Add(Subsidiary_cbb);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Gains";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gains";
            Load += Gains_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Components.RJComboBox Subsidiary_cbb;
        private Label Total_label;
        private Button button1;
        private Components.RJButton Excel_Button;
        private Label label1;
        private Label label2;
        private Components.RJButton rjButton1;
        private DataGridView dataGridView1;
    }
}