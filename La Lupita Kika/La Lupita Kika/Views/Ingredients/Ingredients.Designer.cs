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
            Exit_button = new Button();
            Add_button = new Button();
            Excel_button = new Button();
            dataGridView1 = new DataGridView();
            pictureBox1 = new PictureBox();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // Exit_button
            // 
            Exit_button.Location = new Point(12, 12);
            Exit_button.Name = "Exit_button";
            Exit_button.Size = new Size(57, 29);
            Exit_button.TabIndex = 0;
            Exit_button.Text = "<-";
            Exit_button.UseVisualStyleBackColor = true;
            // 
            // Add_button
            // 
            Add_button.Location = new Point(12, 381);
            Add_button.Name = "Add_button";
            Add_button.Size = new Size(127, 57);
            Add_button.TabIndex = 1;
            Add_button.Text = "Agregar";
            Add_button.UseVisualStyleBackColor = true;
            // 
            // Excel_button
            // 
            Excel_button.Location = new Point(365, 381);
            Excel_button.Name = "Excel_button";
            Excel_button.Size = new Size(118, 57);
            Excel_button.TabIndex = 2;
            Excel_button.Text = "Excel";
            Excel_button.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 98);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(471, 277);
            dataGridView1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(409, 60);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(41, 32);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 60);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(391, 27);
            textBox1.TabIndex = 5;
            // 
            // Ingredients
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(497, 453);
            Controls.Add(textBox1);
            Controls.Add(pictureBox1);
            Controls.Add(dataGridView1);
            Controls.Add(Excel_button);
            Controls.Add(Add_button);
            Controls.Add(Exit_button);
            Name = "Ingredients";
            Text = "Ingredients";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Exit_button;
        private Button Add_button;
        private Button Excel_button;
        private DataGridView dataGridView1;
        private PictureBox pictureBox1;
        private TextBox textBox1;
    }
}