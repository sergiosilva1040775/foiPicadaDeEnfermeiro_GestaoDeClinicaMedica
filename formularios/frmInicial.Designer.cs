namespace foiPicadaDeEnfermeiro
{
    partial class frmInicial
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.especialidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_gerirEspecialidades = new System.Windows.Forms.ToolStripMenuItem();
            this.médicosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_gerirMedicos = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_gerirClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox_especialidademedica = new System.Windows.Forms.ComboBox();
            this.comboBox_MedicosEspecialistas = new System.Windows.Forms.ComboBox();
            this.comboBox_ClientePaciente = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker_data = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_hora = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_Minutos = new System.Windows.Forms.TextBox();
            this.button_pesquisaMedicos = new System.Windows.Forms.Button();
            this.button_Agendar = new System.Windows.Forms.Button();
            this.buttonListarActualizarDelete = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.especialidadesToolStripMenuItem,
            this.médicosToolStripMenuItem,
            this.clientesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(449, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sairToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.sairToolStripMenuItem.Text = "&Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // especialidadesToolStripMenuItem
            // 
            this.especialidadesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_gerirEspecialidades});
            this.especialidadesToolStripMenuItem.Name = "especialidadesToolStripMenuItem";
            this.especialidadesToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.especialidadesToolStripMenuItem.Text = "Especialidades";
            // 
            // ToolStripMenuItem_gerirEspecialidades
            // 
            this.ToolStripMenuItem_gerirEspecialidades.Name = "ToolStripMenuItem_gerirEspecialidades";
            this.ToolStripMenuItem_gerirEspecialidades.Size = new System.Drawing.Size(99, 22);
            this.ToolStripMenuItem_gerirEspecialidades.Text = "Gerir";
            this.ToolStripMenuItem_gerirEspecialidades.Click += new System.EventHandler(this.ToolStripMenuItem_gerirEspecialidades_Click);
            // 
            // médicosToolStripMenuItem
            // 
            this.médicosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_gerirMedicos});
            this.médicosToolStripMenuItem.Name = "médicosToolStripMenuItem";
            this.médicosToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.médicosToolStripMenuItem.Text = "Médicos";
            // 
            // ToolStripMenuItem_gerirMedicos
            // 
            this.ToolStripMenuItem_gerirMedicos.Name = "ToolStripMenuItem_gerirMedicos";
            this.ToolStripMenuItem_gerirMedicos.Size = new System.Drawing.Size(99, 22);
            this.ToolStripMenuItem_gerirMedicos.Text = "Gerir";
            this.ToolStripMenuItem_gerirMedicos.Click += new System.EventHandler(this.ToolStripMenuItem_gerirMedicos_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_gerirClientes});
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.clientesToolStripMenuItem.Text = "Clientes";
            // 
            // ToolStripMenuItem_gerirClientes
            // 
            this.ToolStripMenuItem_gerirClientes.Name = "ToolStripMenuItem_gerirClientes";
            this.ToolStripMenuItem_gerirClientes.Size = new System.Drawing.Size(99, 22);
            this.ToolStripMenuItem_gerirClientes.Text = "Gerir";
            this.ToolStripMenuItem_gerirClientes.Click += new System.EventHandler(this.ToolStripMenuItem_gerirClientes_Click);
            // 
            // comboBox_especialidademedica
            // 
            this.comboBox_especialidademedica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_especialidademedica.FormattingEnabled = true;
            this.comboBox_especialidademedica.Location = new System.Drawing.Point(118, 25);
            this.comboBox_especialidademedica.Name = "comboBox_especialidademedica";
            this.comboBox_especialidademedica.Size = new System.Drawing.Size(200, 21);
            this.comboBox_especialidademedica.TabIndex = 1;
            // 
            // comboBox_MedicosEspecialistas
            // 
            this.comboBox_MedicosEspecialistas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_MedicosEspecialistas.FormattingEnabled = true;
            this.comboBox_MedicosEspecialistas.Location = new System.Drawing.Point(118, 52);
            this.comboBox_MedicosEspecialistas.Name = "comboBox_MedicosEspecialistas";
            this.comboBox_MedicosEspecialistas.Size = new System.Drawing.Size(200, 21);
            this.comboBox_MedicosEspecialistas.TabIndex = 2;
            // 
            // comboBox_ClientePaciente
            // 
            this.comboBox_ClientePaciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ClientePaciente.FormattingEnabled = true;
            this.comboBox_ClientePaciente.Location = new System.Drawing.Point(118, 79);
            this.comboBox_ClientePaciente.Name = "comboBox_ClientePaciente";
            this.comboBox_ClientePaciente.Size = new System.Drawing.Size(200, 21);
            this.comboBox_ClientePaciente.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Especialidade Médica";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Médicos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Clientes/Paciente";
            // 
            // dateTimePicker_data
            // 
            this.dateTimePicker_data.Location = new System.Drawing.Point(118, 116);
            this.dateTimePicker_data.Name = "dateTimePicker_data";
            this.dateTimePicker_data.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_data.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(86, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Data";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(86, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Hora";
            // 
            // textBox_hora
            // 
            this.textBox_hora.Location = new System.Drawing.Point(118, 146);
            this.textBox_hora.MaxLength = 2;
            this.textBox_hora.Name = "textBox_hora";
            this.textBox_hora.Size = new System.Drawing.Size(26, 20);
            this.textBox_hora.TabIndex = 10;
            this.textBox_hora.Text = "00";
            this.textBox_hora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_hora.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(146, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = ":";
            // 
            // textBox_Minutos
            // 
            this.textBox_Minutos.Location = new System.Drawing.Point(158, 146);
            this.textBox_Minutos.MaxLength = 2;
            this.textBox_Minutos.Name = "textBox_Minutos";
            this.textBox_Minutos.Size = new System.Drawing.Size(26, 20);
            this.textBox_Minutos.TabIndex = 13;
            this.textBox_Minutos.Text = "00";
            this.textBox_Minutos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Minutos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // button_pesquisaMedicos
            // 
            this.button_pesquisaMedicos.Location = new System.Drawing.Point(324, 23);
            this.button_pesquisaMedicos.Name = "button_pesquisaMedicos";
            this.button_pesquisaMedicos.Size = new System.Drawing.Size(113, 23);
            this.button_pesquisaMedicos.TabIndex = 14;
            this.button_pesquisaMedicos.Text = "Pesquisar Médicos";
            this.button_pesquisaMedicos.UseVisualStyleBackColor = true;
            this.button_pesquisaMedicos.Click += new System.EventHandler(this.button_pesquisaMedicos_Click);
            // 
            // button_Agendar
            // 
            this.button_Agendar.Location = new System.Drawing.Point(243, 150);
            this.button_Agendar.Name = "button_Agendar";
            this.button_Agendar.Size = new System.Drawing.Size(75, 23);
            this.button_Agendar.TabIndex = 15;
            this.button_Agendar.Text = "Agendar";
            this.button_Agendar.UseVisualStyleBackColor = true;
            this.button_Agendar.Click += new System.EventHandler(this.button_Agendar_Click);
            // 
            // buttonListarActualizarDelete
            // 
            this.buttonListarActualizarDelete.Location = new System.Drawing.Point(324, 150);
            this.buttonListarActualizarDelete.Name = "buttonListarActualizarDelete";
            this.buttonListarActualizarDelete.Size = new System.Drawing.Size(99, 23);
            this.buttonListarActualizarDelete.TabIndex = 16;
            this.buttonListarActualizarDelete.Text = "Listar Consultas";
            this.buttonListarActualizarDelete.UseVisualStyleBackColor = true;
            this.buttonListarActualizarDelete.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 215);
            this.Controls.Add(this.buttonListarActualizarDelete);
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
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmInicial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clinica Médica - Foi Picada de Enfermeiro";
            this.Load += new System.EventHandler(this.frmInicial_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem especialidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_gerirEspecialidades;
        private System.Windows.Forms.ToolStripMenuItem médicosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_gerirMedicos;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_gerirClientes;
        private System.Windows.Forms.ComboBox comboBox_especialidademedica;
        private System.Windows.Forms.ComboBox comboBox_MedicosEspecialistas;
        private System.Windows.Forms.ComboBox comboBox_ClientePaciente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker_data;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_hora;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_Minutos;
        private System.Windows.Forms.Button button_pesquisaMedicos;
        private System.Windows.Forms.Button button_Agendar;
        private System.Windows.Forms.Button buttonListarActualizarDelete;
    }
}

