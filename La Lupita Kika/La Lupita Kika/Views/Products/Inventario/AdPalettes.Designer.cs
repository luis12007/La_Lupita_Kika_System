namespace La_Lupita_Kika.Views.Products.Palettes
{
    partial class AdPalettes
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
            Palette_label = new Label();
            Number_label = new Label();
            textBox2 = new TextBox();
            dataGridView1 = new DataGridView();
            Add_button = new Button();
            comboBox1 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // Palette_label
            // 
            Palette_label.AutoSize = true;
            Palette_label.Location = new Point(58, 21);
            Palette_label.Name = "Palette_label";
            Palette_label.Size = new Size(49, 20);
            Palette_label.TabIndex = 0;
            Palette_label.Text = "Paleta";
            // 
            // Number_label
            // 
            Number_label.AutoSize = true;
            Number_label.Location = new Point(289, 21);
            Number_label.Name = "Number_label";
            Number_label.Size = new Size(69, 20);
            Number_label.TabIndex = 1;
            Number_label.Text = "Cantidad";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(261, 53);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 3;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(23, 99);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(363, 188);
            dataGridView1.TabIndex = 4;
            // 
            // Add_button
            // 
            Add_button.Location = new Point(148, 306);
            Add_button.Name = "Add_button";
            Add_button.Size = new Size(115, 46);
            Add_button.TabIndex = 5;
            Add_button.Text = "Agregar";
            Add_button.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(23, 53);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(138, 28);
            comboBox1.TabIndex = 6;
            // 
            // AdPalettes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(409, 364);
            Controls.Add(comboBox1);
            Controls.Add(Add_button);
            Controls.Add(dataGridView1);
            Controls.Add(textBox2);
            Controls.Add(Number_label);
            Controls.Add(Palette_label);
            Name = "AdPalettes";
            Text = "AdPalettes";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Palette_label;
        private Label Number_label;
        private TextBox textBox2;
        private DataGridView dataGridView1;
        private Button Add_button;
        private ComboBox comboBox1;
    }
}