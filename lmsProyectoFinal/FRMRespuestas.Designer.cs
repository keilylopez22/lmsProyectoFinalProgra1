namespace lmsProyectoFinal
{
    partial class FRMRespuestas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMRespuestas));
            this.label3 = new System.Windows.Forms.Label();
            this.dtpckFechaCreacion = new System.Windows.Forms.DateTimePicker();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.Descripcion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.dgvRespuestas = new System.Windows.Forms.DataGridView();
            this.txtContenido = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnResponder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRespuestas)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(517, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 26);
            this.label3.TabIndex = 31;
            this.label3.Text = "Fecha Entrega";
            // 
            // dtpckFechaCreacion
            // 
            this.dtpckFechaCreacion.CalendarFont = new System.Drawing.Font("MV Boli", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpckFechaCreacion.Enabled = false;
            this.dtpckFechaCreacion.Font = new System.Drawing.Font("MV Boli", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpckFechaCreacion.Location = new System.Drawing.Point(522, 51);
            this.dtpckFechaCreacion.Name = "dtpckFechaCreacion";
            this.dtpckFechaCreacion.Size = new System.Drawing.Size(378, 28);
            this.dtpckFechaCreacion.TabIndex = 30;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BackColor = System.Drawing.Color.Plum;
            this.txtDescripcion.Enabled = false;
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(44, 113);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ReadOnly = true;
            this.txtDescripcion.Size = new System.Drawing.Size(868, 117);
            this.txtDescripcion.TabIndex = 29;
            // 
            // Descripcion
            // 
            this.Descripcion.AutoSize = true;
            this.Descripcion.Font = new System.Drawing.Font("MV Boli", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Descripcion.Location = new System.Drawing.Point(49, 81);
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Size = new System.Drawing.Size(141, 29);
            this.Descripcion.TabIndex = 28;
            this.Descripcion.Text = "Descripcion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(64, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 26);
            this.label2.TabIndex = 27;
            this.label2.Text = "Titulo";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Enabled = false;
            this.txtTitulo.Font = new System.Drawing.Font("MV Boli", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitulo.Location = new System.Drawing.Point(54, 38);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.ReadOnly = true;
            this.txtTitulo.Size = new System.Drawing.Size(366, 35);
            this.txtTitulo.TabIndex = 26;
            // 
            // dgvRespuestas
            // 
            this.dgvRespuestas.AllowUserToAddRows = false;
            this.dgvRespuestas.AllowUserToDeleteRows = false;
            this.dgvRespuestas.AllowUserToOrderColumns = true;
            this.dgvRespuestas.BackgroundColor = System.Drawing.Color.HotPink;
            this.dgvRespuestas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRespuestas.Location = new System.Drawing.Point(44, 406);
            this.dgvRespuestas.Name = "dgvRespuestas";
            this.dgvRespuestas.ReadOnly = true;
            this.dgvRespuestas.RowHeadersWidth = 51;
            this.dgvRespuestas.RowTemplate.Height = 24;
            this.dgvRespuestas.Size = new System.Drawing.Size(868, 150);
            this.dgvRespuestas.TabIndex = 32;
            // 
            // txtContenido
            // 
            this.txtContenido.BackColor = System.Drawing.Color.Plum;
            this.txtContenido.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContenido.Location = new System.Drawing.Point(44, 265);
            this.txtContenido.Multiline = true;
            this.txtContenido.Name = "txtContenido";
            this.txtContenido.Size = new System.Drawing.Size(868, 79);
            this.txtContenido.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MV Boli", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 29);
            this.label1.TabIndex = 33;
            this.label1.Text = "Respuesta";
            // 
            // btnResponder
            // 
            this.btnResponder.FlatAppearance.BorderSize = 0;
            this.btnResponder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResponder.Font = new System.Drawing.Font("MV Boli", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResponder.Location = new System.Drawing.Point(12, 350);
            this.btnResponder.Name = "btnResponder";
            this.btnResponder.Size = new System.Drawing.Size(196, 37);
            this.btnResponder.TabIndex = 35;
            this.btnResponder.Text = "Responder";
            this.btnResponder.UseVisualStyleBackColor = true;
            this.btnResponder.Click += new System.EventHandler(this.btnResponder_Click);
            // 
            // FRMRespuestas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepPink;
            this.ClientSize = new System.Drawing.Size(997, 568);
            this.Controls.Add(this.btnResponder);
            this.Controls.Add(this.txtContenido);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvRespuestas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpckFechaCreacion);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.Descripcion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTitulo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRMRespuestas";
            this.Text = "FRMRespuestas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRespuestas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpckFechaCreacion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label Descripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.DataGridView dgvRespuestas;
        private System.Windows.Forms.TextBox txtContenido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnResponder;
    }
}