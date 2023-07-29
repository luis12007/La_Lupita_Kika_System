namespace La_Lupita_Kika.Views.Ingredients
{
    partial class AddIngredients
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
            Name_label = new Label();
            Exit_button = new Button();
            label3 = new Label();
            Price_label = new Label();
            comboBox1 = new ComboBox();
            unit_label = new Label();
            number_label = new Label();
            Price_textBox = new TextBox();
            textBox1 = new TextBox();
            Number_textBox = new TextBox();
            Add_button = new Button();
            SuspendLayout();
            // 
            // Name_label
            // 
            Name_label.AutoSize = true;
            Name_label.Location = new Point(12, 71);
            Name_label.Name = "Name_label";
            Name_label.Size = new Size(85, 20);
            Name_label.TabIndex = 0;
            Name_label.Text = "Ingrediente";
            // 
            // Exit_button
            // 
            Exit_button.Location = new Point(12, 12);
            Exit_button.Name = "Exit_button";
            Exit_button.Size = new Size(62, 29);
            Exit_button.TabIndex = 1;
            Exit_button.Text = "<-";
            Exit_button.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(178, 97);
            label3.Name = "label3";
            label3.Size = new Size(110, 20);
            label3.TabIndex = 3;
            label3.Text = "Codigo: XXXXX";
            // 
            // Price_label
            // 
            Price_label.AutoSize = true;
            Price_label.Location = new Point(12, 144);
            Price_label.Name = "Price_label";
            Price_label.Size = new Size(50, 20);
            Price_label.TabIndex = 4;
            Price_label.Text = "Precio";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 94);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 5;
            // 
            // unit_label
            // 
            unit_label.AutoSize = true;
            unit_label.Location = new Point(179, 144);
            unit_label.Name = "unit_label";
            unit_label.Size = new Size(109, 20);
            unit_label.TabIndex = 6;
            unit_label.Text = "Cunidad en: KG";
            // 
            // number_label
            // 
            number_label.AutoSize = true;
            number_label.Location = new Point(12, 230);
            number_label.Name = "number_label";
            number_label.Size = new Size(152, 20);
            number_label.TabIndex = 7;
            number_label.Text = "numero de productos";
            // 
            // Price_textBox
            // 
            Price_textBox.Location = new Point(12, 167);
            Price_textBox.Name = "Price_textBox";
            Price_textBox.PlaceholderText = "$10";
            Price_textBox.Size = new Size(125, 27);
            Price_textBox.TabIndex = 8;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(179, 167);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "10";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 9;
            // 
            // Number_textBox
            // 
            Number_textBox.Location = new Point(12, 253);
            Number_textBox.Name = "Number_textBox";
            Number_textBox.PlaceholderText = "10";
            Number_textBox.Size = new Size(125, 27);
            Number_textBox.TabIndex = 10;
            // 
            // Add_button
            // 
            Add_button.FlatStyle = FlatStyle.Popup;
            Add_button.Location = new Point(100, 320);
            Add_button.Name = "Add_button";
            Add_button.Size = new Size(122, 54);
            Add_button.TabIndex = 11;
            Add_button.Text = "Agregar";
            Add_button.UseVisualStyleBackColor = true;
            // 
            // AddIngredients
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(330, 386);
            Controls.Add(Add_button);
            Controls.Add(Number_textBox);
            Controls.Add(textBox1);
            Controls.Add(Price_textBox);
            Controls.Add(number_label);
            Controls.Add(unit_label);
            Controls.Add(comboBox1);
            Controls.Add(Price_label);
            Controls.Add(label3);
            Controls.Add(Exit_button);
            Controls.Add(Name_label);
            Name = "AddIngredients";
            Text = "AddIngredients";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Name_label;
        private Button Exit_button;
        private Label label3;
        private Label Price_label;
        private ComboBox comboBox1;
        private Label unit_label;
        private Label number_label;
        private TextBox Price_textBox;
        private TextBox textBox1;
        private TextBox Number_textBox;
        private Button Add_button;
    }
}