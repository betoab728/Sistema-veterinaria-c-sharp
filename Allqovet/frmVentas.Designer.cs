namespace Allqovet
{
    partial class frmVentas
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
            this.lblutilidad = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbltotal = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblarticulos = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblutilidad_item = new System.Windows.Forms.Label();
            this.lblcosto = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblidproducto = new System.Windows.Forms.Label();
            this.txtstock = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.txttotalitem = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtcodigo = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtprecio = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtcan = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtproducto = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblidcliente = new System.Windows.Forms.Label();
            this.txtfecha = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbvendedor = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtcliente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblnumero = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblserie = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvproductos = new System.Windows.Forms.DataGridView();
            this.IDPRODUCTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CODIGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCRIPCION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CANTIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRECIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMPORTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COSTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UTILIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvproductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblutilidad
            // 
            this.lblutilidad.AutoSize = true;
            this.lblutilidad.Location = new System.Drawing.Point(111, 527);
            this.lblutilidad.Name = "lblutilidad";
            this.lblutilidad.Size = new System.Drawing.Size(13, 13);
            this.lblutilidad.TabIndex = 132;
            this.lblutilidad.Text = "0";
            this.lblutilidad.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 527);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 131;
            this.label1.Text = "UTILIDAD";
            this.label1.Visible = false;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Century Gothic", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(128, 28);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(265, 44);
            this.label14.TabIndex = 127;
            this.label14.Text = "ALLQOVET";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lbltotal);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lblarticulos);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(12, 458);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(614, 52);
            this.panel1.TabIndex = 126;
            // 
            // lbltotal
            // 
            this.lbltotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(128)))), ((int)(((byte)(154)))));
            this.lbltotal.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotal.ForeColor = System.Drawing.Color.White;
            this.lbltotal.Location = new System.Drawing.Point(423, 9);
            this.lbltotal.Name = "lbltotal";
            this.lbltotal.Size = new System.Drawing.Size(120, 32);
            this.lbltotal.TabIndex = 111;
            this.lbltotal.Text = "0.00";
            this.lbltotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(337, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 25);
            this.label8.TabIndex = 110;
            this.label8.Text = "TOTAL";
            // 
            // lblarticulos
            // 
            this.lblarticulos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(128)))), ((int)(((byte)(154)))));
            this.lblarticulos.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblarticulos.ForeColor = System.Drawing.Color.White;
            this.lblarticulos.Location = new System.Drawing.Point(199, 9);
            this.lblarticulos.Name = "lblarticulos";
            this.lblarticulos.Size = new System.Drawing.Size(132, 32);
            this.lblarticulos.TabIndex = 110;
            this.lblarticulos.Text = "0";
            this.lblarticulos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(61, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 25);
            this.label7.TabIndex = 109;
            this.label7.Text = "ARTÍCULOS";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblutilidad_item);
            this.groupBox3.Controls.Add(this.lblcosto);
            this.groupBox3.Controls.Add(this.lblCodigo);
            this.groupBox3.Controls.Add(this.lblidproducto);
            this.groupBox3.Controls.Add(this.txtstock);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.txttotalitem);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.txtcodigo);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtprecio);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.txtcan);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtproducto);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Location = new System.Drawing.Point(12, 173);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(614, 104);
            this.groupBox3.TabIndex = 125;
            this.groupBox3.TabStop = false;
            // 
            // lblutilidad_item
            // 
            this.lblutilidad_item.AutoSize = true;
            this.lblutilidad_item.Location = new System.Drawing.Point(449, 18);
            this.lblutilidad_item.Name = "lblutilidad_item";
            this.lblutilidad_item.Size = new System.Drawing.Size(40, 13);
            this.lblutilidad_item.TabIndex = 130;
            this.lblutilidad_item.Text = "utilidad";
            this.lblutilidad_item.Visible = false;
            // 
            // lblcosto
            // 
            this.lblcosto.AutoSize = true;
            this.lblcosto.Location = new System.Drawing.Point(415, 18);
            this.lblcosto.Name = "lblcosto";
            this.lblcosto.Size = new System.Drawing.Size(33, 13);
            this.lblcosto.TabIndex = 129;
            this.lblcosto.Text = "costo";
            this.lblcosto.Visible = false;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(370, 18);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(39, 13);
            this.lblCodigo.TabIndex = 128;
            this.lblCodigo.Text = "codigo";
            this.lblCodigo.Visible = false;
            // 
            // lblidproducto
            // 
            this.lblidproducto.AutoSize = true;
            this.lblidproducto.Location = new System.Drawing.Point(308, 18);
            this.lblidproducto.Name = "lblidproducto";
            this.lblidproducto.Size = new System.Drawing.Size(57, 13);
            this.lblidproducto.TabIndex = 127;
            this.lblidproducto.Text = "idproducto";
            this.lblidproducto.Visible = false;
            // 
            // txtstock
            // 
            this.txtstock.Location = new System.Drawing.Point(90, 70);
            this.txtstock.Name = "txtstock";
            this.txtstock.ReadOnly = true;
            this.txtstock.Size = new System.Drawing.Size(34, 20);
            this.txtstock.TabIndex = 120;
            this.txtstock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label12.Location = new System.Drawing.Point(21, 71);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 17);
            this.label12.TabIndex = 117;
            this.label12.Text = "Stock";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(49)))), ((int)(((byte)(96)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Image = global::Allqovet.Properties.Resources._103181_close_remove_delete_cross_icon;
            this.button4.Location = new System.Drawing.Point(495, 56);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(102, 34);
            this.button4.TabIndex = 114;
            this.button4.Text = "Quitar";
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txttotalitem
            // 
            this.txttotalitem.Location = new System.Drawing.Point(406, 68);
            this.txttotalitem.Name = "txttotalitem";
            this.txttotalitem.ReadOnly = true;
            this.txttotalitem.Size = new System.Drawing.Size(77, 20);
            this.txttotalitem.TabIndex = 126;
            this.txttotalitem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txttotalitem.TextChanged += new System.EventHandler(this.txttotalitem_TextChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(49)))), ((int)(((byte)(96)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::Allqovet.Properties.Resources.buscar;
            this.button2.Location = new System.Drawing.Point(265, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(32, 23);
            this.button2.TabIndex = 110;
            this.button2.Text = "..";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtcodigo
            // 
            this.txtcodigo.Location = new System.Drawing.Point(90, 16);
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.Size = new System.Drawing.Size(169, 20);
            this.txtcodigo.TabIndex = 109;
            this.txtcodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtcodigo.TextChanged += new System.EventHandler(this.txtcodigo_TextChanged);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(49)))), ((int)(((byte)(96)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Image = global::Allqovet.Properties.Resources._8541639_cart_plus_shopping_icon__1_;
            this.button3.Location = new System.Drawing.Point(495, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(102, 34);
            this.button3.TabIndex = 113;
            this.button3.Text = "Agregar";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label11.Location = new System.Drawing.Point(366, 71);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 17);
            this.label11.TabIndex = 125;
            this.label11.Text = "Total";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(21, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 17);
            this.label5.TabIndex = 108;
            this.label5.Text = "Codigo";
            // 
            // txtprecio
            // 
            this.txtprecio.Location = new System.Drawing.Point(301, 68);
            this.txtprecio.Name = "txtprecio";
            this.txtprecio.Size = new System.Drawing.Size(59, 20);
            this.txtprecio.TabIndex = 124;
            this.txtprecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtprecio.TextChanged += new System.EventHandler(this.txtprecio_TextChanged);
            this.txtprecio.Leave += new System.EventHandler(this.txtprecio_Leave);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label15.Location = new System.Drawing.Point(21, 45);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(63, 17);
            this.label15.TabIndex = 121;
            this.label15.Text = "Producto";
            // 
            // txtcan
            // 
            this.txtcan.Location = new System.Drawing.Point(206, 68);
            this.txtcan.Name = "txtcan";
            this.txtcan.Size = new System.Drawing.Size(34, 20);
            this.txtcan.TabIndex = 112;
            this.txtcan.Text = "1";
            this.txtcan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtcan.Leave += new System.EventHandler(this.txtcan_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(136, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 17);
            this.label6.TabIndex = 111;
            this.label6.Text = "Cantidad";
            // 
            // txtproducto
            // 
            this.txtproducto.Location = new System.Drawing.Point(90, 42);
            this.txtproducto.Name = "txtproducto";
            this.txtproducto.Size = new System.Drawing.Size(393, 20);
            this.txtproducto.TabIndex = 122;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label16.Location = new System.Drawing.Point(251, 71);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(46, 17);
            this.label16.TabIndex = 123;
            this.label16.Text = "Precio";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblidcliente);
            this.groupBox1.Controls.Add(this.txtfecha);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cmbvendedor);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtcliente);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(614, 77);
            this.groupBox1.TabIndex = 124;
            this.groupBox1.TabStop = false;
            // 
            // lblidcliente
            // 
            this.lblidcliente.AutoSize = true;
            this.lblidcliente.Location = new System.Drawing.Point(492, 24);
            this.lblidcliente.Name = "lblidcliente";
            this.lblidcliente.Size = new System.Drawing.Size(13, 13);
            this.lblidcliente.TabIndex = 113;
            this.lblidcliente.Text = "0";
            this.lblidcliente.Visible = false;
            // 
            // txtfecha
            // 
            this.txtfecha.Location = new System.Drawing.Point(489, 46);
            this.txtfecha.Name = "txtfecha";
            this.txtfecha.ReadOnly = true;
            this.txtfecha.Size = new System.Drawing.Size(108, 20);
            this.txtfecha.TabIndex = 112;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label13.Location = new System.Drawing.Point(438, 47);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 17);
            this.label13.TabIndex = 111;
            this.label13.Text = "Fecha";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(49)))), ((int)(((byte)(96)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::Allqovet.Properties.Resources.buscar;
            this.button1.Location = new System.Drawing.Point(391, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 23);
            this.button1.TabIndex = 54;
            this.button1.Text = "..";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbvendedor
            // 
            this.cmbvendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbvendedor.FormattingEnabled = true;
            this.cmbvendedor.Location = new System.Drawing.Point(102, 45);
            this.cmbvendedor.Name = "cmbvendedor";
            this.cmbvendedor.Size = new System.Drawing.Size(321, 21);
            this.cmbvendedor.TabIndex = 110;
            this.cmbvendedor.SelectedIndexChanged += new System.EventHandler(this.cmbvendedor_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(28, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 109;
            this.label4.Text = "Vendedor";
            // 
            // txtcliente
            // 
            this.txtcliente.Location = new System.Drawing.Point(102, 19);
            this.txtcliente.Name = "txtcliente";
            this.txtcliente.Size = new System.Drawing.Size(279, 20);
            this.txtcliente.TabIndex = 108;
            this.txtcliente.TextChanged += new System.EventHandler(this.txtcliente_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(28, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 17);
            this.label3.TabIndex = 107;
            this.label3.Text = "Cliente";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblnumero);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.lblserie);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(455, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(171, 72);
            this.groupBox2.TabIndex = 123;
            this.groupBox2.TabStop = false;
            // 
            // lblnumero
            // 
            this.lblnumero.AutoSize = true;
            this.lblnumero.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnumero.ForeColor = System.Drawing.Color.White;
            this.lblnumero.Location = new System.Drawing.Point(81, 45);
            this.lblnumero.Name = "lblnumero";
            this.lblnumero.Size = new System.Drawing.Size(64, 17);
            this.lblnumero.TabIndex = 45;
            this.lblnumero.Text = "00000000";
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(6, 16);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(159, 20);
            this.label18.TabIndex = 44;
            this.label18.Text = "NOTA DE VENTA";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblserie
            // 
            this.lblserie.AutoSize = true;
            this.lblserie.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblserie.ForeColor = System.Drawing.Color.White;
            this.lblserie.Location = new System.Drawing.Point(28, 45);
            this.lblserie.Name = "lblserie";
            this.lblserie.Size = new System.Drawing.Size(29, 17);
            this.lblserie.TabIndex = 53;
            this.lblserie.Text = "000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(63, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 17);
            this.label2.TabIndex = 53;
            this.label2.Text = "-";
            // 
            // dgvproductos
            // 
            this.dgvproductos.AllowUserToAddRows = false;
            this.dgvproductos.AllowUserToDeleteRows = false;
            this.dgvproductos.BackgroundColor = System.Drawing.Color.White;
            this.dgvproductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvproductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDPRODUCTO,
            this.CODIGO,
            this.DESCRIPCION,
            this.CANTIDAD,
            this.PRECIO,
            this.IMPORTE,
            this.COSTO,
            this.UTILIDAD});
            this.dgvproductos.Location = new System.Drawing.Point(12, 283);
            this.dgvproductos.Name = "dgvproductos";
            this.dgvproductos.ReadOnly = true;
            this.dgvproductos.Size = new System.Drawing.Size(614, 169);
            this.dgvproductos.TabIndex = 122;
            // 
            // IDPRODUCTO
            // 
            this.IDPRODUCTO.HeaderText = "IDPRODUCTO";
            this.IDPRODUCTO.Name = "IDPRODUCTO";
            this.IDPRODUCTO.ReadOnly = true;
            this.IDPRODUCTO.Visible = false;
            // 
            // CODIGO
            // 
            this.CODIGO.HeaderText = "CODIGO";
            this.CODIGO.Name = "CODIGO";
            this.CODIGO.ReadOnly = true;
            // 
            // DESCRIPCION
            // 
            this.DESCRIPCION.HeaderText = "DESCRIPCION";
            this.DESCRIPCION.Name = "DESCRIPCION";
            this.DESCRIPCION.ReadOnly = true;
            this.DESCRIPCION.Width = 200;
            // 
            // CANTIDAD
            // 
            this.CANTIDAD.HeaderText = "CANTIDAD";
            this.CANTIDAD.Name = "CANTIDAD";
            this.CANTIDAD.ReadOnly = true;
            this.CANTIDAD.Width = 70;
            // 
            // PRECIO
            // 
            this.PRECIO.HeaderText = "PRECIO";
            this.PRECIO.Name = "PRECIO";
            this.PRECIO.ReadOnly = true;
            this.PRECIO.Width = 70;
            // 
            // IMPORTE
            // 
            this.IMPORTE.HeaderText = "IMPORTE";
            this.IMPORTE.Name = "IMPORTE";
            this.IMPORTE.ReadOnly = true;
            // 
            // COSTO
            // 
            this.COSTO.HeaderText = "COSTO";
            this.COSTO.Name = "COSTO";
            this.COSTO.ReadOnly = true;
            this.COSTO.Visible = false;
            // 
            // UTILIDAD
            // 
            this.UTILIDAD.HeaderText = "UTILIDAD";
            this.UTILIDAD.Name = "UTILIDAD";
            this.UTILIDAD.ReadOnly = true;
            this.UTILIDAD.Visible = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(49)))), ((int)(((byte)(96)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button5.Image = global::Allqovet.Properties.Resources.delete;
            this.button5.Location = new System.Drawing.Point(315, 516);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(103, 36);
            this.button5.TabIndex = 130;
            this.button5.Text = "CANCELAR";
            this.button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(49)))), ((int)(((byte)(96)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button6.Image = global::Allqovet.Properties.Resources.save;
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(216, 516);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(93, 36);
            this.button6.TabIndex = 129;
            this.button6.Text = "GUARDAR";
            this.button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(424, 521);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(102, 31);
            this.pictureBox1.TabIndex = 128;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // frmVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(128)))), ((int)(((byte)(154)))));
            this.ClientSize = new System.Drawing.Size(644, 553);
            this.Controls.Add(this.lblutilidad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvproductos);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmVentas";
            this.Text = "frmVentas";
            this.Load += new System.EventHandler(this.frmVentas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvproductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblutilidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbltotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblarticulos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblutilidad_item;
        private System.Windows.Forms.Label lblcosto;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblidproducto;
        private System.Windows.Forms.TextBox txtstock;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txttotalitem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtcodigo;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtprecio;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtcan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtproducto;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label lblidcliente;
        private System.Windows.Forms.TextBox txtfecha;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbvendedor;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtcliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblnumero;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblserie;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvproductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDPRODUCTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODIGO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCRIPCION;
        private System.Windows.Forms.DataGridViewTextBoxColumn CANTIDAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRECIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMPORTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn COSTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn UTILIDAD;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}