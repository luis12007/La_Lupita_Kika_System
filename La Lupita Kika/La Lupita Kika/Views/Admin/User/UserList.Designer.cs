namespace La_Lupita_Kika.Views.Admin.User
{
    partial class UserList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserList));
            Exit_button = new Button();
            Userlist_dataGridView = new DataGridView();
            Add_button = new Components.RJButton();
            Delete_button = new Components.RJButton();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)Userlist_dataGridView).BeginInit();
            SuspendLayout();
            // 
            // Exit_button
            // 
            Exit_button.BackColor = Color.White;
            Exit_button.FlatAppearance.BorderColor = Color.White;
            Exit_button.FlatAppearance.MouseDownBackColor = Color.White;
            Exit_button.FlatAppearance.MouseOverBackColor = Color.White;
            Exit_button.FlatStyle = FlatStyle.Flat;
            Exit_button.Image = Properties.Resources.esquema_de_boton_circular_de_flecha_hacia_atras_izquierda__2_;
            Exit_button.Location = new Point(12, 12);
            Exit_button.Name = "Exit_button";
            Exit_button.Size = new Size(45, 40);
            Exit_button.TabIndex = 18;
            Exit_button.UseVisualStyleBackColor = false;
            Exit_button.Click += Exit_button_Click;
            // 
            // Userlist_dataGridView
            // 
            Userlist_dataGridView.AllowUserToAddRows = false;
            Userlist_dataGridView.AllowUserToDeleteRows = false;
            Userlist_dataGridView.AllowUserToResizeColumns = false;
            Userlist_dataGridView.AllowUserToResizeRows = false;
            Userlist_dataGridView.BackgroundColor = Color.White;
            Userlist_dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Bahnschrift", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            Userlist_dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            Userlist_dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Bahnschrift SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(192, 192, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            Userlist_dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            Userlist_dataGridView.EnableHeadersVisualStyles = false;
            Userlist_dataGridView.GridColor = Color.Black;
            Userlist_dataGridView.Location = new Point(10, 82);
            Userlist_dataGridView.Name = "Userlist_dataGridView";
            Userlist_dataGridView.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(255, 98, 133);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            Userlist_dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            Userlist_dataGridView.RowHeadersVisible = false;
            Userlist_dataGridView.RowHeadersWidth = 51;
            Userlist_dataGridView.RowTemplate.Height = 29;
            Userlist_dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Userlist_dataGridView.Size = new Size(960, 339);
            Userlist_dataGridView.TabIndex = 19;
            Userlist_dataGridView.CellClick += Userlist_dataGridView_CellClick;
            Userlist_dataGridView.CellDoubleClick += Userlist_dataGridView_CellDoubleClick;
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
            Add_button.Location = new Point(10, 427);
            Add_button.Name = "Add_button";
            Add_button.Size = new Size(250, 118);
            Add_button.TabIndex = 20;
            Add_button.Text = "Agregar";
            Add_button.TextColor = Color.Black;
            Add_button.UseVisualStyleBackColor = false;
            Add_button.Click += Add_button_Click;
            // 
            // Delete_button
            // 
            Delete_button.BackColor = Color.White;
            Delete_button.BackgroundColor = Color.White;
            Delete_button.BorderColor = Color.FromArgb(255, 54, 112);
            Delete_button.BorderRadius = 20;
            Delete_button.BorderSize = 2;
            Delete_button.FlatAppearance.BorderSize = 0;
            Delete_button.FlatStyle = FlatStyle.Flat;
            Delete_button.Font = new Font("Bahnschrift", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            Delete_button.ForeColor = Color.Black;
            Delete_button.Location = new Point(720, 427);
            Delete_button.Name = "Delete_button";
            Delete_button.Size = new Size(250, 118);
            Delete_button.TabIndex = 21;
            Delete_button.Text = "Eliminar";
            Delete_button.TextColor = Color.Black;
            Delete_button.UseVisualStyleBackColor = false;
            Delete_button.Click += Delete_button_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift", 22F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(390, 23);
            label1.Name = "label1";
            label1.Size = new Size(168, 45);
            label1.TabIndex = 22;
            label1.Text = "Usuarios";
            // 
            // UserList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(983, 557);
            Controls.Add(label1);
            Controls.Add(Delete_button);
            Controls.Add(Add_button);
            Controls.Add(Userlist_dataGridView);
            Controls.Add(Exit_button);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "UserList";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lista de usuarios";
            Load += UserList_Load;
            ((System.ComponentModel.ISupportInitialize)Userlist_dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button Exit_button;
        private DataGridView Userlist_dataGridView;
        private Components.RJButton Add_button;
        private Components.RJButton Delete_button;
        private Label label1;
    }
}