namespace foiPicadaDeEnfermeiro.formularios
{
    partial class frmMedico
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
            this.textBox_Contacto = new System.Windows.Forms.TextBox();
            this.textBox_NomeApelido = new System.Windows.Forms.TextBox();
            this.textBox_NCD = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView_Medicos = new System.Windows.Forms.DataGridView();
            this.comboBox_especialidademedica = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Medicos)).BeginInit();
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
            // textBox_Contacto
            // 
            this.textBox_Contacto.Location = new System.Drawing.Point(153, 238);
            this.textBox_Contacto.MaxLength = 9;
            this.textBox_Contacto.Name = "textBox_Contacto";
            this.textBox_Contacto.Size = new System.Drawing.Size(164, 20);
            this.textBox_Contacto.TabIndex = 21;
            this.textBox_Contacto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Contacto_KeyPress);
            // 
            // textBox_NomeApelido
            // 
            this.textBox_NomeApelido.Location = new System.Drawing.Point(153, 210);
            this.textBox_NomeApelido.Name = "textBox_NomeApelido";
            this.textBox_NomeApelido.Size = new System.Drawing.Size(164, 20);
            this.textBox_NomeApelido.TabIndex = 20;
            // 
            // textBox_NCD
            // 
            this.textBox_NCD.Location = new System.Drawing.Point(153, 182);
            this.textBox_NCD.MaxLength = 9;
            this.textBox_NCD.Name = "textBox_NCD";
            this.textBox_NCD.Size = new System.Drawing.Size(164, 20);
            this.textBox_NCD.TabIndex = 18;
            this.textBox_NCD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_NCD_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 236);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Contacto";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Nome Apelido";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 264);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Especialidade";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Número Cédula Profissional";
            // 
            // dataGridView_Medicos
            // 
            this.dataGridView_Medicos.AllowUserToAddRows = false;
            this.dataGridView_Medicos.AllowUserToDeleteRows = false;
            this.dataGridView_Medicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Medicos.Location = new System.Drawing.Point(11, 15);
            this.dataGridView_Medicos.Name = "dataGridView_Medicos";
            this.dataGridView_Medicos.ReadOnly = true;
            this.dataGridView_Medicos.Size = new System.Drawing.Size(476, 154);
            this.dataGridView_Medicos.TabIndex = 13;
            this.dataGridView_Medicos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Medicos_CellContentClick);
            this.dataGridView_Medicos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView_Medicos_MouseClick);
            // 
            // comboBox_especialidademedica
            // 
            this.comboBox_especialidademedica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_especialidademedica.FormattingEnabled = true;
            this.comboBox_especialidademedica.Location = new System.Drawing.Point(153, 266);
            this.comboBox_especialidademedica.Name = "comboBox_especialidademedica";
            this.comboBox_especialidademedica.Size = new System.Drawing.Size(164, 21);
            this.comboBox_especialidademedica.TabIndex = 26;
            
            // 
            // frmMedico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 304);
            this.Controls.Add(this.comboBox_especialidademedica);
            this.Controls.Add(this.button_LimparCampos);
            this.Controls.Add(this.button_Delete);
            this.Controls.Add(this.button_Actualizar);
            this.Controls.Add(this.button_Adicionar);
            this.Controls.Add(this.textBox_Contacto);
            this.Controls.Add(this.textBox_NomeApelido);
            this.Controls.Add(this.textBox_NCD);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_Medicos);
            this.MaximizeBox = false;
            this.Name = "frmMedico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Médico";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmMedico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Medicos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_LimparCampos;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.Button button_Actualizar;
        private System.Windows.Forms.Button button_Adicionar;
        private System.Windows.Forms.TextBox textBox_Contacto;
        private System.Windows.Forms.TextBox textBox_NomeApelido;
        private System.Windows.Forms.TextBox textBox_NCD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView_Medicos;
        private System.Windows.Forms.ComboBox comboBox_especialidademedica;
    }
}