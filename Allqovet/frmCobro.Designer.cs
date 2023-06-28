namespace Allqovet
{
    partial class frmCobro
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
            this.cmbmedio = new System.Windows.Forms.ComboBox();
            this.txtrecibido = new System.Windows.Forms.TextBox();
            this.lbltotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelefectivo = new System.Windows.Forms.Panel();
            this.txtcambio = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.paneltarjeta = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtoperacion = new System.Windows.Forms.TextBox();
            this.txtdigitos = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtdni = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.lblidventa = new System.Windows.Forms.Label();
            this.lblnumeroventa = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panelefectivo.SuspendLayout();
            this.paneltarjeta.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbmedio
            // 
            this.cmbmedio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbmedio.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbmedio.FormattingEnabled = true;
            this.cmbmedio.Location = new System.Drawing.Point(157, 19);
            this.cmbmedio.Name = "cmbmedio";
            this.cmbmedio.Size = new System.Drawing.Size(176, 29);
            this.cmbmedio.TabIndex = 0;
            this.cmbmedio.SelectedIndexChanged += new System.EventHandler(this.cmbmedio_SelectedIndexChanged);
            this.cmbmedio.SelectionChangeCommitted += new System.EventHandler(this.cmbmedio_SelectionChangeCommitted);
            // 
            // txtrecibido
            // 
            this.txtrecibido.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtrecibido.Location = new System.Drawing.Point(127, 33);
            this.txtrecibido.Name = "txtrecibido";
            this.txtrecibido.Size = new System.Drawing.Size(170, 27);
            this.txtrecibido.TabIndex = 1;
            this.txtrecibido.Leave += new System.EventHandler(this.txtrecibido_Leave);
            // 
            // lbltotal
            // 
            this.lbltotal.Font = new System.Drawing.Font("Century Gothic", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotal.ForeColor = System.Drawing.Color.White;
            this.lbltotal.Location = new System.Drawing.Point(164, 26);
            this.lbltotal.Name = "lbltotal";
            this.lbltotal.Size = new System.Drawing.Size(141, 44);
            this.lbltotal.TabIndex = 128;
            this.lbltotal.Text = "0.00";
            this.lbltotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(17, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 44);
            this.label1.TabIndex = 129;
            this.label1.Text = "TOTAL";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbltotal);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(317, 90);
            this.groupBox1.TabIndex = 130;
            this.groupBox1.TabStop = false;
            // 
            // panelefectivo
            // 
            this.panelefectivo.Controls.Add(this.txtcambio);
            this.panelefectivo.Controls.Add(this.label3);
            this.panelefectivo.Controls.Add(this.label2);
            this.panelefectivo.Controls.Add(this.txtrecibido);
            this.panelefectivo.Location = new System.Drawing.Point(14, 146);
            this.panelefectivo.Name = "panelefectivo";
            this.panelefectivo.Size = new System.Drawing.Size(319, 130);
            this.panelefectivo.TabIndex = 131;
            // 
            // txtcambio
            // 
            this.txtcambio.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcambio.Location = new System.Drawing.Point(127, 65);
            this.txtcambio.Name = "txtcambio";
            this.txtcambio.Size = new System.Drawing.Size(170, 27);
            this.txtcambio.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(42, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "CAMBIO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(42, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "RECIBIDO";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(18, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 19);
            this.label4.TabIndex = 132;
            this.label4.Text = "MEDIO DE PAGO";
            // 
            // paneltarjeta
            // 
            this.paneltarjeta.Controls.Add(this.label7);
            this.paneltarjeta.Controls.Add(this.txtoperacion);
            this.paneltarjeta.Controls.Add(this.txtdigitos);
            this.paneltarjeta.Controls.Add(this.label5);
            this.paneltarjeta.Controls.Add(this.label6);
            this.paneltarjeta.Controls.Add(this.txtdni);
            this.paneltarjeta.Location = new System.Drawing.Point(14, 146);
            this.paneltarjeta.Name = "paneltarjeta";
            this.paneltarjeta.Size = new System.Drawing.Size(319, 130);
            this.paneltarjeta.TabIndex = 133;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(19, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 19);
            this.label7.TabIndex = 134;
            this.label7.Text = "N° DE OPERACION";
            // 
            // txtoperacion
            // 
            this.txtoperacion.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtoperacion.Location = new System.Drawing.Point(171, 86);
            this.txtoperacion.Name = "txtoperacion";
            this.txtoperacion.Size = new System.Drawing.Size(137, 27);
            this.txtoperacion.TabIndex = 7;
            // 
            // txtdigitos
            // 
            this.txtdigitos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdigitos.Location = new System.Drawing.Point(171, 45);
            this.txtdigitos.Name = "txtdigitos";
            this.txtdigitos.Size = new System.Drawing.Size(137, 27);
            this.txtdigitos.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(11, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "4 ULTIMOS DIGITOS";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(124, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 19);
            this.label6.TabIndex = 3;
            this.label6.Text = "DNI";
            // 
            // txtdni
            // 
            this.txtdni.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdni.Location = new System.Drawing.Point(171, 13);
            this.txtdni.Name = "txtdni";
            this.txtdni.Size = new System.Drawing.Size(137, 27);
            this.txtdni.TabIndex = 5;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(49)))), ((int)(((byte)(96)))));
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Image = global::Allqovet.Properties.Resources.eliminar;
            this.button5.Location = new System.Drawing.Point(165, 291);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(103, 36);
            this.button5.TabIndex = 135;
            this.button5.Text = "Cancelar";
            this.button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(49)))), ((int)(((byte)(96)))));
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Image = global::Allqovet.Properties.Resources.save;
            this.button3.Location = new System.Drawing.Point(53, 291);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(106, 36);
            this.button3.TabIndex = 134;
            this.button3.Text = "Guardar";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lblidventa
            // 
            this.lblidventa.AutoSize = true;
            this.lblidventa.Location = new System.Drawing.Point(287, 303);
            this.lblidventa.Name = "lblidventa";
            this.lblidventa.Size = new System.Drawing.Size(35, 13);
            this.lblidventa.TabIndex = 136;
            this.lblidventa.Text = "label8";
            // 
            // lblnumeroventa
            // 
            this.lblnumeroventa.AutoSize = true;
            this.lblnumeroventa.Location = new System.Drawing.Point(285, 286);
            this.lblnumeroventa.Name = "lblnumeroventa";
            this.lblnumeroventa.Size = new System.Drawing.Size(35, 13);
            this.lblnumeroventa.TabIndex = 137;
            this.lblnumeroventa.Text = "label8";
            // 
            // frmCobro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(128)))), ((int)(((byte)(154)))));
            this.ClientSize = new System.Drawing.Size(354, 337);
            this.Controls.Add(this.lblnumeroventa);
            this.Controls.Add(this.lblidventa);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.paneltarjeta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panelefectivo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbmedio);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCobro";
            this.Text = "frmCobro";
            this.Load += new System.EventHandler(this.frmCobro_Load);
            this.groupBox1.ResumeLayout(false);
            this.panelefectivo.ResumeLayout(false);
            this.panelefectivo.PerformLayout();
            this.paneltarjeta.ResumeLayout(false);
            this.paneltarjeta.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbmedio;
        private System.Windows.Forms.TextBox txtrecibido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panelefectivo;
        private System.Windows.Forms.TextBox txtcambio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel paneltarjeta;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtoperacion;
        private System.Windows.Forms.TextBox txtdigitos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtdni;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button3;
        public System.Windows.Forms.Label lbltotal;
        public System.Windows.Forms.Label lblidventa;
        public System.Windows.Forms.Label lblnumeroventa;
    }
}