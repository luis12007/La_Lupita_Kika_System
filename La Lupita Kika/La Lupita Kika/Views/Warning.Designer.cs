namespace La_Lupita_Kika.Views
{
    partial class Warning
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Warning));
            label = new Label();
            Products_dataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)Products_dataGridView).BeginInit();
            SuspendLayout();
            // 
            // label
            // 
            label.AutoSize = true;
            label.Font = new Font("Bahnschrift", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            label.Location = new Point(29, 9);
            label.Name = "label";
            label.Size = new Size(355, 41);
            label.TabIndex = 0;
            label.Text = "Pocos ingredientes de";
            label.Click += label_Click;
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
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(152, 153, 182);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            Products_dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            Products_dataGridView.EnableHeadersVisualStyles = false;
            Products_dataGridView.GridColor = Color.Black;
            Products_dataGridView.Location = new Point(12, 53);
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
            Products_dataGridView.Size = new Size(382, 326);
            Products_dataGridView.TabIndex = 20;
            // 
            // Warning
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(410, 388);
            Controls.Add(Products_dataGridView);
            Controls.Add(label);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Warning";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Warning";
            ((System.ComponentModel.ISupportInitialize)Products_dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label;
        private DataGridView Products_dataGridView;
    }
}