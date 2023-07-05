namespace Allqovet
{
    partial class frmCiereCaja
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
            this.dgvventas = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvTotalMediopagoVenta = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvTotalEgresos = new System.Windows.Forms.DataGridView();
            this.dgvEgresos = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtfinal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtinicial = new System.Windows.Forms.TextBox();
            this.txtcierre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtobservacion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvventas)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalMediopagoVenta)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalEgresos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEgresos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvventas
            // 
            this.dgvventas.AllowUserToAddRows = false;
            this.dgvventas.AllowUserToDeleteRows = false;
            this.dgvventas.BackgroundColor = System.Drawing.Color.White;
            this.dgvventas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvventas.Location = new System.Drawing.Point(6, 6);
            this.dgvventas.Name = "dgvventas";
            this.dgvventas.ReadOnly = true;
            this.dgvventas.Size = new System.Drawing.Size(513, 312);
            this.dgvventas.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(779, 350);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.dgvTotalMediopagoVenta);
            this.tabPage1.Controls.Add(this.dgvventas);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(771, 324);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "RESUMEN VENTAS";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvTotalMediopagoVenta
            // 
            this.dgvTotalMediopagoVenta.AllowUserToAddRows = false;
            this.dgvTotalMediopagoVenta.AllowUserToDeleteRows = false;
            this.dgvTotalMediopagoVenta.BackgroundColor = System.Drawing.Color.White;
            this.dgvTotalMediopagoVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTotalMediopagoVenta.Location = new System.Drawing.Point(525, 32);
            this.dgvTotalMediopagoVenta.Name = "dgvTotalMediopagoVenta";
            this.dgvTotalMediopagoVenta.ReadOnly = true;
            this.dgvTotalMediopagoVenta.Size = new System.Drawing.Size(240, 286);
            this.dgvTotalMediopagoVenta.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvTotalEgresos);
            this.tabPage2.Controls.Add(this.dgvEgresos);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(771, 324);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "INGRESOS-EGRESOS";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvTotalEgresos
            // 
            this.dgvTotalEgresos.AllowUserToAddRows = false;
            this.dgvTotalEgresos.AllowUserToDeleteRows = false;
            this.dgvTotalEgresos.BackgroundColor = System.Drawing.Color.White;
            this.dgvTotalEgresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTotalEgresos.Location = new System.Drawing.Point(525, 32);
            this.dgvTotalEgresos.Name = "dgvTotalEgresos";
            this.dgvTotalEgresos.ReadOnly = true;
            this.dgvTotalEgresos.Size = new System.Drawing.Size(240, 286);
            this.dgvTotalEgresos.TabIndex = 2;
            // 
            // dgvEgresos
            // 
            this.dgvEgresos.AllowUserToAddRows = false;
            this.dgvEgresos.AllowUserToDeleteRows = false;
            this.dgvEgresos.BackgroundColor = System.Drawing.Color.White;
            this.dgvEgresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEgresos.Location = new System.Drawing.Point(9, 6);
            this.dgvEgresos.Name = "dgvEgresos";
            this.dgvEgresos.ReadOnly = true;
            this.dgvEgresos.Size = new System.Drawing.Size(510, 312);
            this.dgvEgresos.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(49)))), ((int)(((byte)(96)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Image = global::Allqovet.Properties.Resources.eliminar;
            this.button3.Location = new System.Drawing.Point(694, 406);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 41);
            this.button3.TabIndex = 19;
            this.button3.Text = "Cancelar";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(49)))), ((int)(((byte)(96)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = global::Allqovet.Properties.Resources._352286_content_cut_icon__1_;
            this.button2.Location = new System.Drawing.Point(562, 406);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 41);
            this.button2.TabIndex = 18;
            this.button2.Text = "Realizar cierre";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtfinal);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtinicial);
            this.groupBox1.Controls.Add(this.txtcierre);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(16, 394);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(495, 53);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Total Efectivo";
            // 
            // txtfinal
            // 
            this.txtfinal.Location = new System.Drawing.Point(402, 23);
            this.txtfinal.Name = "txtfinal";
            this.txtfinal.ReadOnly = true;
            this.txtfinal.Size = new System.Drawing.Size(80, 22);
            this.txtfinal.TabIndex = 10;
            this.txtfinal.Text = "0.00";
            this.txtfinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "SALDO INICIAL";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(320, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "SALDO FINAL";
            // 
            // txtinicial
            // 
            this.txtinicial.Location = new System.Drawing.Point(106, 23);
            this.txtinicial.Name = "txtinicial";
            this.txtinicial.ReadOnly = true;
            this.txtinicial.Size = new System.Drawing.Size(69, 22);
            this.txtinicial.TabIndex = 8;
            this.txtinicial.Text = "0.00";
            this.txtinicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtcierre
            // 
            this.txtcierre.Location = new System.Drawing.Point(234, 23);
            this.txtcierre.Name = "txtcierre";
            this.txtcierre.ReadOnly = true;
            this.txtcierre.Size = new System.Drawing.Size(80, 22);
            this.txtcierre.TabIndex = 9;
            this.txtcierre.Text = "0.00";
            this.txtcierre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(181, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "CIERRE";
            // 
            // txtobservacion
            // 
            this.txtobservacion.Location = new System.Drawing.Point(98, 368);
            this.txtobservacion.Name = "txtobservacion";
            this.txtobservacion.Size = new System.Drawing.Size(693, 20);
            this.txtobservacion.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(13, 371);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "Observacion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(563, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "TOTALES POR MEDIO DE PAGO";
            // 
            // frmCiereCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(128)))), ((int)(((byte)(154)))));
            this.ClientSize = new System.Drawing.Size(805, 459);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtobservacion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmCiereCaja";
            this.Text = "frmCiereCaja";
            this.Load += new System.EventHandler(this.frmCiereCaja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvventas)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalMediopagoVenta)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalEgresos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEgresos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvventas;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtfinal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtinicial;
        private System.Windows.Forms.TextBox txtcierre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtobservacion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvEgresos;
        private System.Windows.Forms.DataGridView dgvTotalMediopagoVenta;
        private System.Windows.Forms.DataGridView dgvTotalEgresos;
        private System.Windows.Forms.Label label1;
    }
}