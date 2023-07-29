namespace La_Lupita_Kika.Views.Products.Palettes
{
    partial class Inventario
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
            Add_button = new Button();
            Excel_button = new Button();
            dataGridView1 = new DataGridView();
            textBox1 = new TextBox();
            Search_button = new Button();
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
            // Add_button
            // 
            Add_button.Location = new Point(12, 409);
            Add_button.Name = "Add_button";
            Add_button.Size = new Size(94, 29);
            Add_button.TabIndex = 1;
            Add_button.Text = "Agregar";
            Add_button.UseVisualStyleBackColor = true;
            // 
            // Excel_button
            // 
            Excel_button.Location = new Point(694, 409);
            Excel_button.Name = "Excel_button";
            Excel_button.Size = new Size(94, 29);
            Excel_button.TabIndex = 2;
            Excel_button.Text = "Excel";
            Excel_button.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 116);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(776, 273);
            dataGridView1.TabIndex = 3;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 83);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(490, 27);
            textBox1.TabIndex = 4;
            // 
            // Search_button
            // 
            Search_button.Location = new Point(520, 81);
            Search_button.Name = "Search_button";
            Search_button.Size = new Size(94, 29);
            Search_button.TabIndex = 5;
            Search_button.UseVisualStyleBackColor = true;
            // 
            // Palettes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Search_button);
            Controls.Add(textBox1);
            Controls.Add(dataGridView1);
            Controls.Add(Excel_button);
            Controls.Add(Add_button);
            Controls.Add(Exit_button);
            Name = "Palettes";
            Text = "Palettes";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Exit_button;
        private Button Add_button;
        private Button Excel_button;
        private DataGridView dataGridView1;
        private TextBox textBox1;
        private Button Search_button;
    }
}