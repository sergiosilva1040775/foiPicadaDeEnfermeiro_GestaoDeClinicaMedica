namespace foiPicadaDeEnfermeiro.formularios
{
    partial class frmEditarConsultas
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
            this.button_Agendar = new System.Windows.Forms.Button();
            this.button_pesquisaMedicos = new System.Windows.Forms.Button();
            this.textBox_Minutos = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_hora = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker_data = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_ClientePaciente = new System.Windows.Forms.ComboBox();
            this.comboBox_MedicosEspecialistas = new System.Windows.Forms.ComboBox();
            this.comboBox_especialidademedica = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button_Agendar
            // 
            this.button_Agendar.Location = new System.Drawing.Point(251, 137);
            this.button_Agendar.Name = "button_Agendar";
            this.button_Agendar.Size = new System.Drawing.Size(75, 23);
            this.button_Agendar.TabIndex = 30;
            this.button_Agendar.Text = "Re-Agendar";
            this.button_Agendar.UseVisualStyleBackColor = true;
            this.button_Agendar.Click += new System.EventHandler(this.button_Agendar_Click);
            // 
            // button_pesquisaMedicos
            // 
            this.button_pesquisaMedicos.Location = new System.Drawing.Point(332, 10);
            this.button_pesquisaMedicos.Name = "button_pesquisaMedicos";
            this.button_pesquisaMedicos.Size = new System.Drawing.Size(113, 23);
            this.button_pesquisaMedicos.TabIndex = 29;
            this.button_pesquisaMedicos.Text = "Pesquisar Médicos";
            this.button_pesquisaMedicos.UseVisualStyleBackColor = true;
            this.button_pesquisaMedicos.Click += new System.EventHandler(this.button_pesquisaMedicos_Click);
            // 
            // textBox_Minutos
            // 
            this.textBox_Minutos.Location = new System.Drawing.Point(166, 133);
            this.textBox_Minutos.MaxLength = 2;
            this.textBox_Minutos.Name = "textBox_Minutos";
            this.textBox_Minutos.Size = new System.Drawing.Size(26, 20);
            this.textBox_Minutos.TabIndex = 28;
            this.textBox_Minutos.Text = "00";
            this.textBox_Minutos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(154, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = ":";
            // 
            // textBox_hora
            // 
            this.textBox_hora.Location = new System.Drawing.Point(126, 133);
            this.textBox_hora.MaxLength = 2;
            this.textBox_hora.Name = "textBox_hora";
            this.textBox_hora.Size = new System.Drawing.Size(26, 20);
            this.textBox_hora.TabIndex = 26;
            this.textBox_hora.Text = "00";
            this.textBox_hora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(94, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Hora";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(94, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Data";
            // 
            // dateTimePicker_data
            // 
            this.dateTimePicker_data.Location = new System.Drawing.Point(126, 103);
            this.dateTimePicker_data.Name = "dateTimePicker_data";
            this.dateTimePicker_data.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_data.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Clientes/Paciente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Médicos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Especialidade Médica";
            // 
            // comboBox_ClientePaciente
            // 
            this.comboBox_ClientePaciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ClientePaciente.FormattingEnabled = true;
            this.comboBox_ClientePaciente.Location = new System.Drawing.Point(126, 66);
            this.comboBox_ClientePaciente.Name = "comboBox_ClientePaciente";
            this.comboBox_ClientePaciente.Size = new System.Drawing.Size(200, 21);
            this.comboBox_ClientePaciente.TabIndex = 19;
            // 
            // comboBox_MedicosEspecialistas
            // 
            this.comboBox_MedicosEspecialistas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_MedicosEspecialistas.FormattingEnabled = true;
            this.comboBox_MedicosEspecialistas.Location = new System.Drawing.Point(126, 39);
            this.comboBox_MedicosEspecialistas.Name = "comboBox_MedicosEspecialistas";
            this.comboBox_MedicosEspecialistas.Size = new System.Drawing.Size(200, 21);
            this.comboBox_MedicosEspecialistas.TabIndex = 18;
            // 
            // comboBox_especialidademedica
            // 
            this.comboBox_especialidademedica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_especialidademedica.FormattingEnabled = true;
            this.comboBox_especialidademedica.Location = new System.Drawing.Point(126, 12);
            this.comboBox_especialidademedica.Name = "comboBox_especialidademedica";
            this.comboBox_especialidademedica.Size = new System.Drawing.Size(200, 21);
            this.comboBox_especialidademedica.TabIndex = 17;
            // 
            // frmEditarConsultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 174);
            this.Controls.Add(this.button_Agendar);
            this.Controls.Add(this.button_pesquisaMedicos);
            this.Controls.Add(this.textBox_Minutos);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_hora);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePicker_data);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_ClientePaciente);
            this.Controls.Add(this.comboBox_MedicosEspecialistas);
            this.Controls.Add(this.comboBox_especialidademedica);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmEditarConsultas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Consultas";
            this.Load += new System.EventHandler(this.frmEditarConsultas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Agendar;
        private System.Windows.Forms.Button button_pesquisaMedicos;
        private System.Windows.Forms.TextBox textBox_Minutos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_hora;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker_data;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_ClientePaciente;
        private System.Windows.Forms.ComboBox comboBox_MedicosEspecialistas;
        private System.Windows.Forms.ComboBox comboBox_especialidademedica;
    }
}