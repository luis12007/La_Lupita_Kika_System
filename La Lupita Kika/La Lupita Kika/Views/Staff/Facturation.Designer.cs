namespace La_Lupita_Kika.Views
{
    partial class Facturation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Facturation));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Barcode_label = new Label();
            Barcode_textBox = new Components.RJTextBox();
            Add_button = new Components.RJButton();
            Process_button = new Components.RJButton();
            rjButton1 = new Components.RJButton();
            Products_dataGridView = new DataGridView();
            Total = new Label();
            ((System.ComponentModel.ISupportInitialize)Products_dataGridView).BeginInit();
            SuspendLayout();
            // 
            // Barcode_label
            // 
            Barcode_label.AutoSize = true;
            Barcode_label.Font = new Font("Bahnschrift", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            Barcode_label.Location = new Point(12, 19);
            Barcode_label.Name = "Barcode_label";
            Barcode_label.Size = new Size(312, 41);
            Barcode_label.TabIndex = 0;
            Barcode_label.Text = "Codigo de producto";
            // 
            // Barcode_textBox
            // 
            Barcode_textBox.BackColor = SystemColors.Window;
            Barcode_textBox.BorderColor = Color.FromArgb(224, 224, 224);
            Barcode_textBox.BorderFocusColor = Color.FromArgb(224, 224, 224);
            Barcode_textBox.BorderRadius = 10;
            Barcode_textBox.BorderSize = 2;
            Barcode_textBox.Font = new Font("Bahnschrift", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            Barcode_textBox.ForeColor = Color.FromArgb(64, 64, 64);
            Barcode_textBox.Location = new Point(13, 71);
            Barcode_textBox.Margin = new Padding(4);
            Barcode_textBox.Multiline = false;
            Barcode_textBox.Name = "Barcode_textBox";
            Barcode_textBox.Padding = new Padding(10, 7, 10, 7);
            Barcode_textBox.PasswordChar = false;
            Barcode_textBox.PlaceholderColor = Color.DarkGray;
            Barcode_textBox.PlaceholderText = "Barcode";
            Barcode_textBox.ReadOnly = false;
            Barcode_textBox.Size = new Size(351, 56);
            Barcode_textBox.TabIndex = 8;
            Barcode_textBox.TextAlign = ContentAlignment.MiddleLeft;
            Barcode_textBox.Texts = "";
            Barcode_textBox.UnderlinedStyle = true;
            Barcode_textBox.KeyPress += Barcode_textBox_KeyPress;
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
            Add_button.Location = new Point(13, 167);
            Add_button.Name = "Add_button";
            Add_button.Size = new Size(351, 152);
            Add_button.TabIndex = 10;
            Add_button.Text = "Agregar";
            Add_button.TextColor = Color.Black;
            Add_button.UseVisualStyleBackColor = false;
            Add_button.Click += Add_button_Click_1;
            // 
            // Process_button
            // 
            Process_button.BackColor = Color.White;
            Process_button.BackgroundColor = Color.White;
            Process_button.BorderColor = Color.FromArgb(255, 54, 112);
            Process_button.BorderRadius = 20;
            Process_button.BorderSize = 2;
            Process_button.FlatAppearance.BorderSize = 0;
            Process_button.FlatStyle = FlatStyle.Flat;
            Process_button.Font = new Font("Bahnschrift", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            Process_button.ForeColor = Color.Black;
            Process_button.Location = new Point(13, 408);
            Process_button.Name = "Process_button";
            Process_button.Size = new Size(351, 91);
            Process_button.TabIndex = 11;
            Process_button.Text = "Procesar";
            Process_button.TextColor = Color.Black;
            Process_button.UseVisualStyleBackColor = false;
            Process_button.Click += Process_button_Click;
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
            rjButton1.Font = new Font("Bahnschrift", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            rjButton1.ForeColor = Color.Black;
            rjButton1.Image = (Image)resources.GetObject("rjButton1.Image");
            rjButton1.Location = new Point(827, 480);
            rjButton1.Name = "rjButton1";
            rjButton1.Size = new Size(65, 44);
            rjButton1.TabIndex = 12;
            rjButton1.TextColor = Color.Black;
            rjButton1.UseVisualStyleBackColor = false;
            rjButton1.Click += rjButton1_Click;
            // 
            // Products_dataGridView
            // 
            Products_dataGridView.AllowUserToAddRows = false;
            Products_dataGridView.AllowUserToDeleteRows = false;
            Products_dataGridView.AllowUserToResizeColumns = false;
            Products_dataGridView.AllowUserToResizeRows = false;
            Products_dataGridView.BackgroundColor = Color.White;
            Products_dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Bahnschrift", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            Products_dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            Products_dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Bahnschrift SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 204, 204);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            Products_dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            Products_dataGridView.EnableHeadersVisualStyles = false;
            Products_dataGridView.GridColor = Color.Black;
            Products_dataGridView.Location = new Point(402, 19);
            Products_dataGridView.Name = "Products_dataGridView";
            Products_dataGridView.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(255, 98, 133);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            Products_dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            Products_dataGridView.RowHeadersVisible = false;
            Products_dataGridView.RowHeadersWidth = 51;
            Products_dataGridView.RowTemplate.Height = 29;
            Products_dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Products_dataGridView.Size = new Size(490, 455);
            Products_dataGridView.TabIndex = 13;
            Products_dataGridView.CellClick += Products_dataGridView_CellClick;
            Products_dataGridView.CellContentClick += Products_dataGridView_CellContentClick_1;
            Products_dataGridView.CellDoubleClick += Products_dataGridView_CellContentDoubleClick;
            Products_dataGridView.RowPostPaint += Products_dataGridView_RowPostPaint;
            // 
            // Total
            // 
            Total.AutoSize = true;
            Total.Font = new Font("Bahnschrift", 13F, FontStyle.Regular, GraphicsUnit.Point);
            Total.Location = new Point(144, 378);
            Total.Name = "Total";
            Total.Size = new Size(95, 27);
            Total.TabIndex = 14;
            Total.Text = "Total: 0$";
            // 
            // Facturation
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(904, 536);
            Controls.Add(Total);
            Controls.Add(Products_dataGridView);
            Controls.Add(rjButton1);
            Controls.Add(Process_button);
            Controls.Add(Add_button);
            Controls.Add(Barcode_textBox);
            Controls.Add(Barcode_label);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Facturation";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Productos";
            Load += Facturation_Load;
            Shown += Facturation_Shown;
            ((System.ComponentModel.ISupportInitialize)Products_dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Barcode_label;
        private Components.RJTextBox Barcode_textBox;
        private Components.RJButton Add_button;
        private Components.RJButton Process_button;
        private Components.RJButton rjButton1;
        private DataGridView Products_dataGridView;
        private Label Total;
    }
}