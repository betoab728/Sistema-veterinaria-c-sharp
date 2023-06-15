namespace Allqovet
{
    partial class frmDashboard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.panelClientes = new System.Windows.Forms.Panel();
            this.lblNumClientes = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.panelProd = new System.Windows.Forms.Panel();
            this.lblNumProductos = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelProveedores = new System.Windows.Forms.Panel();
            this.lblNumlProveedores = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dtgvBajoStock = new System.Windows.Forms.DataGridView();
            this.panelBajoStock = new System.Windows.Forms.Panel();
            this.lblStock = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.panelClientes.SuspendLayout();
            this.panelProd.SuspendLayout();
            this.panelProveedores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvBajoStock)).BeginInit();
            this.panelBajoStock.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.CustomFormat = "MMMdd, yyyy";
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaInicio.Location = new System.Drawing.Point(806, 55);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(101, 20);
            this.dtpFechaInicio.TabIndex = 0;
            this.dtpFechaInicio.ValueChanged += new System.EventHandler(this.dtpFechaInicio_ValueChanged);
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.CustomFormat = "MMMdd, yyyy";
            this.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaFinal.Location = new System.Drawing.Point(971, 55);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(101, 20);
            this.dtpFechaFinal.TabIndex = 1;
            // 
            // panelClientes
            // 
            this.panelClientes.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelClientes.Controls.Add(this.lblNumClientes);
            this.panelClientes.Controls.Add(this.lbl2);
            this.panelClientes.Location = new System.Drawing.Point(23, 39);
            this.panelClientes.Name = "panelClientes";
            this.panelClientes.Size = new System.Drawing.Size(158, 46);
            this.panelClientes.TabIndex = 2;
            // 
            // lblNumClientes
            // 
            this.lblNumClientes.AutoSize = true;
            this.lblNumClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumClientes.Location = new System.Drawing.Point(26, 16);
            this.lblNumClientes.Name = "lblNumClientes";
            this.lblNumClientes.Size = new System.Drawing.Size(56, 25);
            this.lblNumClientes.TabIndex = 1;
            this.lblNumClientes.Text = "1000";
            this.lblNumClientes.Click += new System.EventHandler(this.label2_Click);
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.Location = new System.Drawing.Point(16, 0);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(56, 16);
            this.lbl2.TabIndex = 0;
            this.lbl2.Text = "Clientes";
            this.lbl2.Click += new System.EventHandler(this.label1_Click);
            // 
            // panelProd
            // 
            this.panelProd.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelProd.Controls.Add(this.lblNumProductos);
            this.panelProd.Controls.Add(this.label2);
            this.panelProd.Location = new System.Drawing.Point(187, 39);
            this.panelProd.Name = "panelProd";
            this.panelProd.Size = new System.Drawing.Size(214, 46);
            this.panelProd.TabIndex = 3;
            // 
            // lblNumProductos
            // 
            this.lblNumProductos.AutoSize = true;
            this.lblNumProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumProductos.Location = new System.Drawing.Point(26, 16);
            this.lblNumProductos.Name = "lblNumProductos";
            this.lblNumProductos.Size = new System.Drawing.Size(56, 25);
            this.lblNumProductos.TabIndex = 1;
            this.lblNumProductos.Text = "1000";
            this.lblNumProductos.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Productos";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // panelProveedores
            // 
            this.panelProveedores.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelProveedores.Controls.Add(this.lblNumlProveedores);
            this.panelProveedores.Controls.Add(this.label3);
            this.panelProveedores.Location = new System.Drawing.Point(407, 39);
            this.panelProveedores.Name = "panelProveedores";
            this.panelProveedores.Size = new System.Drawing.Size(381, 46);
            this.panelProveedores.TabIndex = 4;
            // 
            // lblNumlProveedores
            // 
            this.lblNumlProveedores.AutoSize = true;
            this.lblNumlProveedores.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumlProveedores.Location = new System.Drawing.Point(26, 16);
            this.lblNumlProveedores.Name = "lblNumlProveedores";
            this.lblNumlProveedores.Size = new System.Drawing.Size(56, 25);
            this.lblNumlProveedores.TabIndex = 1;
            this.lblNumlProveedores.Text = "1000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Proveedores";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(794, 86);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            series1.IsValueShownAsLabel = true;
            series1.LabelForeColor = System.Drawing.Color.White;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(290, 229);
            this.chart1.TabIndex = 5;
            this.chart1.Text = "chartTopProd";
            title1.Alignment = System.Drawing.ContentAlignment.TopLeft;
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            title1.Name = "Title1";
            title1.Text = "Top 5 Productos";
            this.chart1.Titles.Add(title1);
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // dtgvBajoStock
            // 
            this.dtgvBajoStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvBajoStock.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgvBajoStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvBajoStock.Location = new System.Drawing.Point(12, 28);
            this.dtgvBajoStock.Name = "dtgvBajoStock";
            this.dtgvBajoStock.Size = new System.Drawing.Size(266, 212);
            this.dtgvBajoStock.TabIndex = 6;
            this.dtgvBajoStock.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // panelBajoStock
            // 
            this.panelBajoStock.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelBajoStock.Controls.Add(this.dtgvBajoStock);
            this.panelBajoStock.Controls.Add(this.lblStock);
            this.panelBajoStock.Location = new System.Drawing.Point(794, 321);
            this.panelBajoStock.Name = "panelBajoStock";
            this.panelBajoStock.Size = new System.Drawing.Size(290, 243);
            this.panelBajoStock.TabIndex = 5;
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStock.Location = new System.Drawing.Point(16, 0);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(106, 25);
            this.lblStock.TabIndex = 0;
            this.lblStock.Text = "Bajo Stock";
            this.lblStock.Click += new System.EventHandler(this.label4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(812, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fecha Inicio";
            this.label1.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(983, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Fecha Final";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(83, 143);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 144);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(247, 143);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(153, 144);
            this.button2.TabIndex = 8;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(406, 143);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(153, 144);
            this.button3.TabIndex = 9;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(565, 143);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(153, 144);
            this.button4.TabIndex = 10;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(565, 304);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(153, 144);
            this.button5.TabIndex = 14;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(406, 304);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(153, 144);
            this.button6.TabIndex = 13;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(247, 304);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(153, 144);
            this.button7.TabIndex = 12;
            this.button7.Text = "button7";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(83, 304);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(153, 144);
            this.button8.TabIndex = 11;
            this.button8.Text = "button8";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 576);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelBajoStock);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.panelProveedores);
            this.Controls.Add(this.panelProd);
            this.Controls.Add(this.panelClientes);
            this.Controls.Add(this.dtpFechaFinal);
            this.Controls.Add(this.dtpFechaInicio);
            this.Name = "frmDashboard";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmDashboard_Load);
            this.panelClientes.ResumeLayout(false);
            this.panelClientes.PerformLayout();
            this.panelProd.ResumeLayout(false);
            this.panelProd.PerformLayout();
            this.panelProveedores.ResumeLayout(false);
            this.panelProveedores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvBajoStock)).EndInit();
            this.panelBajoStock.ResumeLayout(false);
            this.panelBajoStock.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private System.Windows.Forms.Panel panelClientes;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lblNumClientes;
        private System.Windows.Forms.Panel panelProd;
        private System.Windows.Forms.Label lblNumProductos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelProveedores;
        private System.Windows.Forms.Label lblNumlProveedores;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataGridView dtgvBajoStock;
        private System.Windows.Forms.Panel panelBajoStock;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
    }
}