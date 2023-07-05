namespace Allqovet
{
    partial class frmMovCajas
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
            this.button1 = new System.Windows.Forms.Button();
            this.cmbtipooperacion = new System.Windows.Forms.ComboBox();
            this.chkoperacion = new System.Windows.Forms.CheckBox();
            this.cmbtipopago = new System.Windows.Forms.ComboBox();
            this.dtphasta = new System.Windows.Forms.DateTimePicker();
            this.chkforma = new System.Windows.Forms.CheckBox();
            this.dtpdesde = new System.Windows.Forms.DateTimePicker();
            this.lblhasta = new System.Windows.Forms.Label();
            this.rbfecfa = new System.Windows.Forms.RadioButton();
            this.lbldesde = new System.Windows.Forms.Label();
            this.rbactual = new System.Windows.Forms.RadioButton();
            this.dgvMovimientos = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cmbtipooperacion);
            this.groupBox1.Controls.Add(this.chkoperacion);
            this.groupBox1.Controls.Add(this.cmbtipopago);
            this.groupBox1.Controls.Add(this.dtphasta);
            this.groupBox1.Controls.Add(this.chkforma);
            this.groupBox1.Controls.Add(this.dtpdesde);
            this.groupBox1.Controls.Add(this.lblhasta);
            this.groupBox1.Controls.Add(this.rbfecfa);
            this.groupBox1.Controls.Add(this.lbldesde);
            this.groupBox1.Controls.Add(this.rbactual);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(16, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 98);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(49)))), ((int)(((byte)(96)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::Allqovet.Properties.Resources.buscar;
            this.button1.Location = new System.Drawing.Point(528, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 29);
            this.button1.TabIndex = 12;
            this.button1.Text = "Buscar";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbtipooperacion
            // 
            this.cmbtipooperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbtipooperacion.Enabled = false;
            this.cmbtipooperacion.FormattingEnabled = true;
            this.cmbtipooperacion.Location = new System.Drawing.Point(472, 58);
            this.cmbtipooperacion.Name = "cmbtipooperacion";
            this.cmbtipooperacion.Size = new System.Drawing.Size(298, 24);
            this.cmbtipooperacion.TabIndex = 8;
            // 
            // chkoperacion
            // 
            this.chkoperacion.AutoSize = true;
            this.chkoperacion.Location = new System.Drawing.Point(332, 61);
            this.chkoperacion.Name = "chkoperacion";
            this.chkoperacion.Size = new System.Drawing.Size(134, 20);
            this.chkoperacion.TabIndex = 7;
            this.chkoperacion.Text = "Filtrar por operacion";
            this.chkoperacion.UseVisualStyleBackColor = true;
            this.chkoperacion.CheckedChanged += new System.EventHandler(this.chkoperacion_CheckedChanged);
            // 
            // cmbtipopago
            // 
            this.cmbtipopago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbtipopago.Enabled = false;
            this.cmbtipopago.FormattingEnabled = true;
            this.cmbtipopago.Location = new System.Drawing.Point(182, 58);
            this.cmbtipopago.Name = "cmbtipopago";
            this.cmbtipopago.Size = new System.Drawing.Size(144, 24);
            this.cmbtipopago.TabIndex = 11;
            // 
            // dtphasta
            // 
            this.dtphasta.Enabled = false;
            this.dtphasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtphasta.Location = new System.Drawing.Point(396, 25);
            this.dtphasta.Name = "dtphasta";
            this.dtphasta.Size = new System.Drawing.Size(98, 21);
            this.dtphasta.TabIndex = 10;
            // 
            // chkforma
            // 
            this.chkforma.AutoSize = true;
            this.chkforma.Location = new System.Drawing.Point(16, 60);
            this.chkforma.Name = "chkforma";
            this.chkforma.Size = new System.Drawing.Size(160, 20);
            this.chkforma.TabIndex = 6;
            this.chkforma.Text = "Filtrar por forma de pago";
            this.chkforma.UseVisualStyleBackColor = true;
            this.chkforma.CheckedChanged += new System.EventHandler(this.chkforma_CheckedChanged);
            // 
            // dtpdesde
            // 
            this.dtpdesde.Enabled = false;
            this.dtpdesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpdesde.Location = new System.Drawing.Point(246, 25);
            this.dtpdesde.Name = "dtpdesde";
            this.dtpdesde.Size = new System.Drawing.Size(98, 21);
            this.dtpdesde.TabIndex = 9;
            // 
            // lblhasta
            // 
            this.lblhasta.AutoSize = true;
            this.lblhasta.Enabled = false;
            this.lblhasta.Location = new System.Drawing.Point(350, 29);
            this.lblhasta.Name = "lblhasta";
            this.lblhasta.Size = new System.Drawing.Size(40, 16);
            this.lblhasta.TabIndex = 3;
            this.lblhasta.Text = "Hasta";
            // 
            // rbfecfa
            // 
            this.rbfecfa.AutoSize = true;
            this.rbfecfa.Location = new System.Drawing.Point(114, 28);
            this.rbfecfa.Name = "rbfecfa";
            this.rbfecfa.Size = new System.Drawing.Size(78, 20);
            this.rbfecfa.TabIndex = 1;
            this.rbfecfa.Text = "Por fecha";
            this.rbfecfa.UseVisualStyleBackColor = true;
            this.rbfecfa.CheckedChanged += new System.EventHandler(this.rbfecfa_CheckedChanged);
            // 
            // lbldesde
            // 
            this.lbldesde.AutoSize = true;
            this.lbldesde.Enabled = false;
            this.lbldesde.Location = new System.Drawing.Point(198, 30);
            this.lbldesde.Name = "lbldesde";
            this.lbldesde.Size = new System.Drawing.Size(42, 16);
            this.lbldesde.TabIndex = 2;
            this.lbldesde.Text = "Desde";
            // 
            // rbactual
            // 
            this.rbactual.AutoSize = true;
            this.rbactual.Checked = true;
            this.rbactual.Location = new System.Drawing.Point(16, 28);
            this.rbactual.Name = "rbactual";
            this.rbactual.Size = new System.Drawing.Size(92, 20);
            this.rbactual.TabIndex = 0;
            this.rbactual.TabStop = true;
            this.rbactual.Text = "Caja actual";
            this.rbactual.UseVisualStyleBackColor = true;
            this.rbactual.CheckedChanged += new System.EventHandler(this.rbactual_CheckedChanged);
            // 
            // dgvMovimientos
            // 
            this.dgvMovimientos.AllowUserToAddRows = false;
            this.dgvMovimientos.AllowUserToDeleteRows = false;
            this.dgvMovimientos.BackgroundColor = System.Drawing.Color.White;
            this.dgvMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovimientos.Location = new System.Drawing.Point(16, 139);
            this.dgvMovimientos.Name = "dgvMovimientos";
            this.dgvMovimientos.ReadOnly = true;
            this.dgvMovimientos.Size = new System.Drawing.Size(776, 243);
            this.dgvMovimientos.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(12, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(776, 23);
            this.label8.TabIndex = 125;
            this.label8.Text = "MOVIMIENTOS DE CAJA";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(49)))), ((int)(((byte)(96)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Image = global::Allqovet.Properties.Resources._104853_excel_icon__1_;
            this.button3.Location = new System.Drawing.Point(390, 388);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(128, 36);
            this.button3.TabIndex = 129;
            this.button3.Text = "Exportar a excel";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(49)))), ((int)(((byte)(96)))));
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Image = global::Allqovet.Properties.Resources.eliminar;
            this.button5.Location = new System.Drawing.Point(281, 388);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(103, 36);
            this.button5.TabIndex = 128;
            this.button5.Text = "Anular";
            this.button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(49)))), ((int)(((byte)(96)))));
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Image = global::Allqovet.Properties.Resources.salir;
            this.button4.Location = new System.Drawing.Point(524, 388);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(109, 36);
            this.button4.TabIndex = 127;
            this.button4.Text = "Salir";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(49)))), ((int)(((byte)(96)))));
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = global::Allqovet.Properties.Resources.nuevo;
            this.button2.Location = new System.Drawing.Point(16, 388);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(147, 36);
            this.button2.TabIndex = 126;
            this.button2.Text = "Registrar nuevo";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(49)))), ((int)(((byte)(96)))));
            this.button6.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Image = global::Allqovet.Properties.Resources.editar;
            this.button6.Location = new System.Drawing.Point(169, 388);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(106, 36);
            this.button6.TabIndex = 130;
            this.button6.Text = "Modificar";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // frmMovCajas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(128)))), ((int)(((byte)(154)))));
            this.ClientSize = new System.Drawing.Size(800, 434);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgvMovimientos);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmMovCajas";
            this.Text = "frmMovCajas";
            this.Load += new System.EventHandler(this.frmMovCajas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbtipooperacion;
        private System.Windows.Forms.CheckBox chkoperacion;
        private System.Windows.Forms.CheckBox chkforma;
        private System.Windows.Forms.Label lblhasta;
        private System.Windows.Forms.Label lbldesde;
        private System.Windows.Forms.RadioButton rbfecfa;
        private System.Windows.Forms.RadioButton rbactual;
        private System.Windows.Forms.DateTimePicker dtpdesde;
        private System.Windows.Forms.DateTimePicker dtphasta;
        private System.Windows.Forms.ComboBox cmbtipopago;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvMovimientos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button6;
    }
}