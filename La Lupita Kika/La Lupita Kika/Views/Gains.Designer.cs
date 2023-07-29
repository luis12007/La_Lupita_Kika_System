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
            Exit_button = new Button();
            total_button = new Button();
            Excel_button = new Button();
            dataGridView1 = new DataGridView();
            comboBox1 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // Exit_button
            // 
            Exit_button.Location = new Point(12, 12);
            Exit_button.Name = "Exit_button";
            Exit_button.Size = new Size(94, 29);
            Exit_button.TabIndex = 0;
            Exit_button.Text = "<-";
            Exit_button.UseVisualStyleBackColor = true;
            // 
            // total_button
            // 
            total_button.Location = new Point(344, 323);
            total_button.Name = "total_button";
            total_button.Size = new Size(140, 29);
            total_button.TabIndex = 1;
            total_button.Text = "Ganancias totales";
            total_button.UseVisualStyleBackColor = true;
            // 
            // Excel_button
            // 
            Excel_button.Location = new Point(176, 399);
            Excel_button.Name = "Excel_button";
            Excel_button.Size = new Size(94, 29);
            Excel_button.TabIndex = 2;
            Excel_button.Text = "Excel";
            Excel_button.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 91);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(472, 226);
            dataGridView1.TabIndex = 3;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(333, 57);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 4;
            // 
            // Gains
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(502, 435);
            Controls.Add(comboBox1);
            Controls.Add(dataGridView1);
            Controls.Add(Excel_button);
            Controls.Add(total_button);
            Controls.Add(Exit_button);
            Name = "Gains";
            Text = "Gains";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button Exit_button;
        private Button total_button;
        private Button Excel_button;
        private DataGridView dataGridView1;
        private ComboBox comboBox1;
    }
}