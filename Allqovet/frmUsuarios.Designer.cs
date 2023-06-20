namespace Allqovet
{
    partial class frmUsuarios
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
            this.label3 = new System.Windows.Forms.Label();
            this.dtgusuarios = new System.Windows.Forms.DataGridView();
            this.btnpermisos = new System.Windows.Forms.Button();
            this.btnsalir = new System.Windows.Forms.Button();
            this.btnmod = new System.Windows.Forms.Button();
            this.btnnuevo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgusuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(543, 23);
            this.label3.TabIndex = 36;
            this.label3.Text = "REGISTRO DE USUARIOS";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtgusuarios
            // 
            this.dtgusuarios.AllowUserToAddRows = false;
            this.dtgusuarios.AllowUserToDeleteRows = false;
            this.dtgusuarios.BackgroundColor = System.Drawing.Color.White;
            this.dtgusuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgusuarios.Location = new System.Drawing.Point(16, 35);
            this.dtgusuarios.Name = "dtgusuarios";
            this.dtgusuarios.ReadOnly = true;
            this.dtgusuarios.Size = new System.Drawing.Size(539, 311);
            this.dtgusuarios.TabIndex = 37;
            // 
            // btnpermisos
            // 
            this.btnpermisos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(49)))), ((int)(((byte)(96)))));
            this.btnpermisos.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnpermisos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnpermisos.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnpermisos.ForeColor = System.Drawing.Color.White;
            this.btnpermisos.Image = global::Allqovet.Properties.Resources.buscar;
            this.btnpermisos.Location = new System.Drawing.Point(220, 353);
            this.btnpermisos.Name = "btnpermisos";
            this.btnpermisos.Size = new System.Drawing.Size(112, 36);
            this.btnpermisos.TabIndex = 53;
            this.btnpermisos.Text = "Permisos";
            this.btnpermisos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnpermisos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnpermisos.UseVisualStyleBackColor = false;
            // 
            // btnsalir
            // 
            this.btnsalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(49)))), ((int)(((byte)(96)))));
            this.btnsalir.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnsalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsalir.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsalir.ForeColor = System.Drawing.Color.White;
            this.btnsalir.Image = global::Allqovet.Properties.Resources.salir;
            this.btnsalir.Location = new System.Drawing.Point(338, 353);
            this.btnsalir.Name = "btnsalir";
            this.btnsalir.Size = new System.Drawing.Size(99, 36);
            this.btnsalir.TabIndex = 52;
            this.btnsalir.Text = "Salir";
            this.btnsalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnsalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnsalir.UseVisualStyleBackColor = false;
            // 
            // btnmod
            // 
            this.btnmod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(49)))), ((int)(((byte)(96)))));
            this.btnmod.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnmod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnmod.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnmod.ForeColor = System.Drawing.Color.White;
            this.btnmod.Image = global::Allqovet.Properties.Resources.editar;
            this.btnmod.Location = new System.Drawing.Point(118, 353);
            this.btnmod.Name = "btnmod";
            this.btnmod.Size = new System.Drawing.Size(96, 36);
            this.btnmod.TabIndex = 51;
            this.btnmod.Text = "Modificar";
            this.btnmod.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnmod.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnmod.UseVisualStyleBackColor = false;
            this.btnmod.Click += new System.EventHandler(this.btnmod_Click_1);
            // 
            // btnnuevo
            // 
            this.btnnuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(49)))), ((int)(((byte)(96)))));
            this.btnnuevo.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnnuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnnuevo.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnnuevo.ForeColor = System.Drawing.Color.White;
            this.btnnuevo.Image = global::Allqovet.Properties.Resources.nuevo;
            this.btnnuevo.Location = new System.Drawing.Point(16, 353);
            this.btnnuevo.Name = "btnnuevo";
            this.btnnuevo.Size = new System.Drawing.Size(96, 36);
            this.btnnuevo.TabIndex = 50;
            this.btnnuevo.Text = "Nuevo";
            this.btnnuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnnuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnnuevo.UseVisualStyleBackColor = false;
            this.btnnuevo.Click += new System.EventHandler(this.btnnuevo_Click_1);
            // 
            // frmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(128)))), ((int)(((byte)(154)))));
            this.ClientSize = new System.Drawing.Size(572, 401);
            this.Controls.Add(this.btnpermisos);
            this.Controls.Add(this.btnsalir);
            this.Controls.Add(this.dtgusuarios);
            this.Controls.Add(this.btnmod);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnnuevo);
            this.Name = "frmUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUsuarios";
            this.Load += new System.EventHandler(this.frmUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgusuarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dtgusuarios;
        private System.Windows.Forms.Button btnpermisos;
        private System.Windows.Forms.Button btnsalir;
        private System.Windows.Forms.Button btnmod;
        private System.Windows.Forms.Button btnnuevo;
    }
}