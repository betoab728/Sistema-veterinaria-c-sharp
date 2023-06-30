namespace Allqovet
{
    partial class frmReporteStock
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbvitrina = new System.Windows.Forms.ComboBox();
            this.chkvitrina = new System.Windows.Forms.CheckBox();
            this.cmbcategoria = new System.Windows.Forms.ComboBox();
            this.chkcategoria = new System.Windows.Forms.CheckBox();
            this.cmbmarca = new System.Windows.Forms.ComboBox();
            this.chkmarca = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dgvproductos = new System.Windows.Forms.DataGridView();
            this.chkstock = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvproductos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkstock);
            this.groupBox1.Controls.Add(this.cmbvitrina);
            this.groupBox1.Controls.Add(this.chkvitrina);
            this.groupBox1.Controls.Add(this.cmbcategoria);
            this.groupBox1.Controls.Add(this.chkcategoria);
            this.groupBox1.Controls.Add(this.cmbmarca);
            this.groupBox1.Controls.Add(this.chkmarca);
            this.groupBox1.Location = new System.Drawing.Point(12, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(680, 83);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // cmbvitrina
            // 
            this.cmbvitrina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbvitrina.Enabled = false;
            this.cmbvitrina.FormattingEnabled = true;
            this.cmbvitrina.Location = new System.Drawing.Point(104, 50);
            this.cmbvitrina.Name = "cmbvitrina";
            this.cmbvitrina.Size = new System.Drawing.Size(170, 21);
            this.cmbvitrina.TabIndex = 5;
            // 
            // chkvitrina
            // 
            this.chkvitrina.AutoSize = true;
            this.chkvitrina.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkvitrina.ForeColor = System.Drawing.Color.White;
            this.chkvitrina.Location = new System.Drawing.Point(24, 48);
            this.chkvitrina.Name = "chkvitrina";
            this.chkvitrina.Size = new System.Drawing.Size(71, 23);
            this.chkvitrina.TabIndex = 4;
            this.chkvitrina.Text = "Vitrina";
            this.chkvitrina.UseVisualStyleBackColor = true;
            this.chkvitrina.CheckedChanged += new System.EventHandler(this.chkvitrina_CheckedChanged);
            // 
            // cmbcategoria
            // 
            this.cmbcategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbcategoria.Enabled = false;
            this.cmbcategoria.FormattingEnabled = true;
            this.cmbcategoria.Location = new System.Drawing.Point(405, 20);
            this.cmbcategoria.Name = "cmbcategoria";
            this.cmbcategoria.Size = new System.Drawing.Size(148, 21);
            this.cmbcategoria.TabIndex = 3;
            // 
            // chkcategoria
            // 
            this.chkcategoria.AutoSize = true;
            this.chkcategoria.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkcategoria.ForeColor = System.Drawing.Color.White;
            this.chkcategoria.Location = new System.Drawing.Point(301, 20);
            this.chkcategoria.Name = "chkcategoria";
            this.chkcategoria.Size = new System.Drawing.Size(98, 23);
            this.chkcategoria.TabIndex = 2;
            this.chkcategoria.Text = "Categoria";
            this.chkcategoria.UseVisualStyleBackColor = true;
            this.chkcategoria.CheckedChanged += new System.EventHandler(this.chkcategoria_CheckedChanged);
            // 
            // cmbmarca
            // 
            this.cmbmarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbmarca.Enabled = false;
            this.cmbmarca.FormattingEnabled = true;
            this.cmbmarca.Location = new System.Drawing.Point(104, 20);
            this.cmbmarca.Name = "cmbmarca";
            this.cmbmarca.Size = new System.Drawing.Size(170, 21);
            this.cmbmarca.TabIndex = 1;
            // 
            // chkmarca
            // 
            this.chkmarca.AutoSize = true;
            this.chkmarca.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkmarca.ForeColor = System.Drawing.Color.White;
            this.chkmarca.Location = new System.Drawing.Point(24, 19);
            this.chkmarca.Name = "chkmarca";
            this.chkmarca.Size = new System.Drawing.Size(74, 23);
            this.chkmarca.TabIndex = 0;
            this.chkmarca.Text = "Marca";
            this.chkmarca.UseVisualStyleBackColor = true;
            this.chkmarca.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(8, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(684, 23);
            this.label3.TabIndex = 29;
            this.label3.Text = "REPORTE DE PRODUCTOS";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(49)))), ((int)(((byte)(96)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Image = global::Allqovet.Properties.Resources._104853_excel_icon__1_;
            this.button3.Location = new System.Drawing.Point(449, 124);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(128, 36);
            this.button3.TabIndex = 131;
            this.button3.Text = "Exportar a excel";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(49)))), ((int)(((byte)(96)))));
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Image = global::Allqovet.Properties.Resources.salir;
            this.button4.Location = new System.Drawing.Point(583, 124);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(109, 36);
            this.button4.TabIndex = 130;
            this.button4.Text = "Salir";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(49)))), ((int)(((byte)(96)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::Allqovet.Properties.Resources._6579037_and_computers_hardware_print_printer_icon;
            this.button1.Location = new System.Drawing.Point(336, 124);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 36);
            this.button1.TabIndex = 132;
            this.button1.Text = "Imprimir";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(49)))), ((int)(((byte)(96)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = global::Allqovet.Properties.Resources.buscar;
            this.button2.Location = new System.Drawing.Point(241, 124);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 36);
            this.button2.TabIndex = 133;
            this.button2.Text = "Buscar";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dgvproductos
            // 
            this.dgvproductos.AllowUserToAddRows = false;
            this.dgvproductos.AllowUserToDeleteRows = false;
            this.dgvproductos.BackgroundColor = System.Drawing.Color.White;
            this.dgvproductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvproductos.Location = new System.Drawing.Point(12, 166);
            this.dgvproductos.Name = "dgvproductos";
            this.dgvproductos.ReadOnly = true;
            this.dgvproductos.Size = new System.Drawing.Size(680, 272);
            this.dgvproductos.TabIndex = 134;
            // 
            // chkstock
            // 
            this.chkstock.AutoSize = true;
            this.chkstock.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkstock.ForeColor = System.Drawing.Color.White;
            this.chkstock.Location = new System.Drawing.Point(301, 48);
            this.chkstock.Name = "chkstock";
            this.chkstock.Size = new System.Drawing.Size(126, 23);
            this.chkstock.TabIndex = 6;
            this.chkstock.Text = "Solo con stock";
            this.chkstock.UseVisualStyleBackColor = true;
            // 
            // frmReporteStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(128)))), ((int)(((byte)(154)))));
            this.ClientSize = new System.Drawing.Size(709, 450);
            this.Controls.Add(this.dgvproductos);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmReporteStock";
            this.Text = "frmReporteStock";
            this.Load += new System.EventHandler(this.frmReporteStock_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvproductos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbvitrina;
        private System.Windows.Forms.CheckBox chkvitrina;
        private System.Windows.Forms.ComboBox cmbcategoria;
        private System.Windows.Forms.CheckBox chkcategoria;
        private System.Windows.Forms.ComboBox cmbmarca;
        private System.Windows.Forms.CheckBox chkmarca;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dgvproductos;
        private System.Windows.Forms.CheckBox chkstock;
    }
}