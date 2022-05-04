using foiPicadaDeEnfermeiro.DAL;
using foiPicadaDeEnfermeiro.Handlers;
using foiPicadaDeEnfermeiro.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace foiPicadaDeEnfermeiro
{
    public partial class frmInicial : Form
    {
        public frmInicial()
        {
            InitializeComponent();
        }

        private void ToolStripMenuItem_gerirEspecialidades_Click(object sender, EventArgs e)
        {
            foiPicadaDeEnfermeiro.formularios.frmEspecialidades frmEspecialidades = new foiPicadaDeEnfermeiro.formularios.frmEspecialidades();
            frmEspecialidades.ShowDialog();

        }

        private void ToolStripMenuItem_gerirMedicos_Click(object sender, EventArgs e)
        {
            foiPicadaDeEnfermeiro.formularios.frmMedico frmMedico = new foiPicadaDeEnfermeiro.formularios.frmMedico();
            frmMedico.ShowDialog();
        }

        private void ToolStripMenuItem_gerirClientes_Click(object sender, EventArgs e)
        {
            foiPicadaDeEnfermeiro.formularios.frmClientes frmClientes = new foiPicadaDeEnfermeiro.formularios.frmClientes();
            frmClientes.ShowDialog();
        }

        private void frmInicial_Load(object sender, EventArgs e)
        {
            carregarLista();
            textBox_hora.Text = DateTime.Now.Hour.ToString();
            textBox_Minutos.Text = DateTime.Now.Minute.ToString();
        }

        private void carregarLista()
        {

            EspecialidadeMedicaDAL EspecialidadeMedicasDAL = new EspecialidadeMedicaDAL();
            List<especialidadeMedica> especialidadeMedicas = EspecialidadeMedicasDAL.listarEspecialidadesMedica();
            comboBox_especialidademedica.DataSource = especialidadeMedicas;
            comboBox_especialidademedica.DisplayMember = "description";
            comboBox_especialidademedica.ValueMember = "numeroId";


            clientePacienteDAL clientePacientesDAL = new clientePacienteDAL();
            List<clientePaciente> clientePacientes = clientePacientesDAL.listarClientePaciente();
            comboBox_ClientePaciente.DataSource = clientePacientes;
            comboBox_ClientePaciente.DisplayMember = "nomeAplido";
            comboBox_ClientePaciente.ValueMember = "numeroNIF";


        }

        private void button_pesquisaMedicos_Click(object sender, EventArgs e)
        {
            LimparFormulario();
            pessoalMedicoDAL pessoalMedicosDAL = new pessoalMedicoDAL();
            pessoalMedicoHander pmh = new pessoalMedicoHander();
            (int codigo, pessoalMedico pessoalMedicos, string error) = pmh.ValidarPessoalMedicoPesquisaEspecialidade(comboBox_especialidademedica.SelectedValue.ToString());
            if (codigo == 1)
            {
                MessageBox.Show(error);
                comboBox_especialidademedica.Focus();
                return;
            }
            List<pessoalMedico> pessoalMedicoLista = pessoalMedicosDAL.listarPessoalMedicoByEspecialidade(pessoalMedicos);




            comboBox_MedicosEspecialistas.DataSource = pessoalMedicoLista;
            comboBox_MedicosEspecialistas.DisplayMember = "nomeAplido";
            comboBox_MedicosEspecialistas.ValueMember = "numeroCedulaProfissional";
        }

        gestaoConsultasDAL gestaoConsultaDAL = new gestaoConsultasDAL();

        private void button_Agendar_Click(object sender, EventArgs e)
        {

            if (comboBox_MedicosEspecialistas.Text.ToString().Length != 0)
            {
                if (comboBox_ClientePaciente.Text.ToString().Length != 0)
                {

                    string dataHora = dateTimePicker_data.Value.ToString("dd/MM/yyyy") + " " + textBox_hora.Text + ":" + textBox_Minutos.Text + ":00";
                    gestaoConsultaHander gch = new gestaoConsultaHander();
                    (int codigo, gestaoConsulta gestaoConsultas, string error) = gch.ValidarGestaoConsultaInsert(dataHora, comboBox_MedicosEspecialistas.SelectedValue.ToString(), comboBox_ClientePaciente.SelectedValue.ToString());
                    switch (codigo)
                    {
                        case 1:
                            MessageBox.Show(error);
                            return;
                        case 2:
                            MessageBox.Show(error);
                            comboBox_MedicosEspecialistas.DroppedDown = true;
                            return;
                        case 3:
                            MessageBox.Show(error);
                            comboBox_MedicosEspecialistas.DroppedDown = true;
                            return;
                        default:
                            (int registo, string erro) = gestaoConsultaDAL.inserirConsultaMedica(gestaoConsultas);
                            if (registo > 0)
                            {
                                MessageBox.Show("Registo guardado na base de dados com sucesso!");
                                comboBox_especialidademedica.SelectedIndex = -1;
                                LimparFormulario();
                            }
                            else
                            {
                                MessageBox.Show(erro);
                            }
                            return;

                    }
                }
                else
                {

                    MessageBox.Show("Seleccione uma cliente!");
                }

            }
            else
            {

                MessageBox.Show("Seleccione uma médica!");
            }
        }

        private void LimparFormulario()
        {

            comboBox_MedicosEspecialistas.SelectedIndex = -1;
            comboBox_ClientePaciente.SelectedIndex = -1;

            dateTimePicker_data.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
            textBox_hora.Text = DateTime.Now.Hour.ToString();
            textBox_Minutos.Text = DateTime.Now.Minute.ToString();


        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foiPicadaDeEnfermeiro.formularios.frmListasConsultas frmListasConsulta = new foiPicadaDeEnfermeiro.formularios.frmListasConsultas();
            frmListasConsulta.ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Close();


        }
    }
}
