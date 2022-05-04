namespace foiPicadaDeEnfermeiro.formularios
{
    partial class frmListasConsultas
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
            this.dataGridView_listasConsultas = new System.Windows.Forms.DataGridView();
            this.button_apagarConsulta = new System.Windows.Forms.Button();
            this.button_actualizarConsulta = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_listasConsultas)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_listasConsultas
            // 
            this.dataGridView_listasConsultas.AllowUserToAddRows = false;
            this.dataGridView_listasConsultas.AllowUserToDeleteRows = false;
            this.dataGridView_listasConsultas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_listasConsultas.Location = new System.Drawing.Point(12, 12);
            this.dataGridView_listasConsultas.Name = "dataGridView_listasConsultas";
            this.dataGridView_listasConsultas.ReadOnly = true;
            this.dataGridView_listasConsultas.Size = new System.Drawing.Size(623, 169);
            this.dataGridView_listasConsultas.TabIndex = 0;
            // 
            // button_apagarConsulta
            // 
            this.button_apagarConsulta.Location = new System.Drawing.Point(515, 217);
            this.button_apagarConsulta.Name = "button_apagarConsulta";
            this.button_apagarConsulta.Size = new System.Drawing.Size(113, 23);
            this.button_apagarConsulta.TabIndex = 17;
            this.button_apagarConsulta.Text = "Eliminar Consultas";
            this.button_apagarConsulta.UseVisualStyleBackColor = true;
            this.button_apagarConsulta.Click += new System.EventHandler(this.button_apagarConsulta_Click);
            // 
            // button_actualizarConsulta
            // 
            this.button_actualizarConsulta.Location = new System.Drawing.Point(396, 217);
            this.button_actualizarConsulta.Name = "button_actualizarConsulta";
            this.button_actualizarConsulta.Size = new System.Drawing.Size(113, 23);
            this.button_actualizarConsulta.TabIndex = 18;
            this.button_actualizarConsulta.Text = "Actualizar Consulta";
            this.button_actualizarConsulta.UseVisualStyleBackColor = true;
            this.button_actualizarConsulta.Click += new System.EventHandler(this.button_actualizarConsulta_Click);
            // 
            // frmListasConsultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 262);
            this.Controls.Add(this.button_actualizarConsulta);
            this.Controls.Add(this.button_apagarConsulta);
            this.Controls.Add(this.dataGridView_listasConsultas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmListasConsultas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listas de Consultas";
            this.Load += new System.EventHandler(this.frmListasConsultas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_listasConsultas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_listasConsultas;
        private System.Windows.Forms.Button button_apagarConsulta;
        private System.Windows.Forms.Button button_actualizarConsulta;
    }
}