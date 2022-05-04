namespace foiPicadaDeEnfermeiro.formularios
{
    partial class frmEspecialidades
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
            this.button_LimparCampos = new System.Windows.Forms.Button();
            this.button_Delete = new System.Windows.Forms.Button();
            this.button_Actualizar = new System.Windows.Forms.Button();
            this.button_Adicionar = new System.Windows.Forms.Button();
            this.textBox_Descricao = new System.Windows.Forms.TextBox();
            this.textBox_Id = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView_Especialidades = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Especialidades)).BeginInit();
            this.SuspendLayout();
            // 
            // button_LimparCampos
            // 
            this.button_LimparCampos.Location = new System.Drawing.Point(349, 264);
            this.button_LimparCampos.Name = "button_LimparCampos";
            this.button_LimparCampos.Size = new System.Drawing.Size(88, 23);
            this.button_LimparCampos.TabIndex = 25;
            this.button_LimparCampos.Text = "Limpar Campos";
            this.button_LimparCampos.UseVisualStyleBackColor = true;
            this.button_LimparCampos.Click += new System.EventHandler(this.button_LimparCampos_Click);
            // 
            // button_Delete
            // 
            this.button_Delete.Location = new System.Drawing.Point(349, 236);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(88, 23);
            this.button_Delete.TabIndex = 24;
            this.button_Delete.Text = "Apagar";
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // button_Actualizar
            // 
            this.button_Actualizar.Location = new System.Drawing.Point(349, 210);
            this.button_Actualizar.Name = "button_Actualizar";
            this.button_Actualizar.Size = new System.Drawing.Size(88, 23);
            this.button_Actualizar.TabIndex = 23;
            this.button_Actualizar.Text = "Actualizar";
            this.button_Actualizar.UseVisualStyleBackColor = true;
            this.button_Actualizar.Click += new System.EventHandler(this.button_Actualizar_Click);
            // 
            // button_Adicionar
            // 
            this.button_Adicionar.Location = new System.Drawing.Point(349, 182);
            this.button_Adicionar.Name = "button_Adicionar";
            this.button_Adicionar.Size = new System.Drawing.Size(88, 23);
            this.button_Adicionar.TabIndex = 22;
            this.button_Adicionar.Text = "Adicionar";
            this.button_Adicionar.UseVisualStyleBackColor = true;
            this.button_Adicionar.Click += new System.EventHandler(this.button_Adicionar_Click);
            // 
            // textBox_Descricao
            // 
            this.textBox_Descricao.Location = new System.Drawing.Point(92, 210);
            this.textBox_Descricao.Name = "textBox_Descricao";
            this.textBox_Descricao.Size = new System.Drawing.Size(164, 20);
            this.textBox_Descricao.TabIndex = 19;
            // 
            // textBox_Id
            // 
            this.textBox_Id.Location = new System.Drawing.Point(92, 182);
            this.textBox_Id.Name = "textBox_Id";
            this.textBox_Id.ReadOnly = true;
            this.textBox_Id.Size = new System.Drawing.Size(164, 20);
            this.textBox_Id.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Descrição";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Número Id";
            // 
            // dataGridView_Especialidades
            // 
            this.dataGridView_Especialidades.AllowUserToAddRows = false;
            this.dataGridView_Especialidades.AllowUserToDeleteRows = false;
            this.dataGridView_Especialidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Especialidades.Location = new System.Drawing.Point(11, 15);
            this.dataGridView_Especialidades.Name = "dataGridView_Especialidades";
            this.dataGridView_Especialidades.ReadOnly = true;
            this.dataGridView_Especialidades.Size = new System.Drawing.Size(476, 154);
            this.dataGridView_Especialidades.TabIndex = 13;
            this.dataGridView_Especialidades.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Especialidades_CellContentClick);
            // 
            // frmEspecialidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 304);
            this.Controls.Add(this.button_LimparCampos);
            this.Controls.Add(this.button_Delete);
            this.Controls.Add(this.button_Actualizar);
            this.Controls.Add(this.button_Adicionar);
            this.Controls.Add(this.textBox_Descricao);
            this.Controls.Add(this.textBox_Id);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_Especialidades);
            this.MaximizeBox = false;
            this.Name = "frmEspecialidades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Especialidades";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmEspecialidades_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Especialidades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_LimparCampos;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.Button button_Actualizar;
        private System.Windows.Forms.Button button_Adicionar;
        private System.Windows.Forms.TextBox textBox_Descricao;
        private System.Windows.Forms.TextBox textBox_Id;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView_Especialidades;
    }
}