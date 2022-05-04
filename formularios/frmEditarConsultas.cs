using foiPicadaDeEnfermeiro.DAL;
using foiPicadaDeEnfermeiro.Handlers;
using foiPicadaDeEnfermeiro.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace foiPicadaDeEnfermeiro.formularios
{
    public partial class frmEditarConsultas : Form
    {
        public frmEditarConsultas()
        {
            InitializeComponent();

        }

        private void pesquisarMedicospoEspecialidade (string especialidade)
        {

            pessoalMedicoDAL pessoalMedicosDAL = new pessoalMedicoDAL();
            pessoalMedicoHander pmh = new pessoalMedicoHander();
            (int codigo, pessoalMedico pessoalMedicos, string error) = pmh.ValidarPessoalMedicoPesquisaEspecialidade(especialidade);
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

        private void button_pesquisaMedicos_Click(object sender, EventArgs e)
        {
            pesquisarMedicospoEspecialidade(comboBox_especialidademedica.SelectedValue.ToString());
        }

        private void frmEditarConsultas_Load(object sender, EventArgs e)
        {


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
        int idConsulta;

        public void setValores(gestaoConsultasPlus updateConsultasPlus)
        {
            carregarLista();
            string[] data = updateConsultasPlus.dataHora.ToString().Split(' ');
            string[] hora = data[1].Split(':');
            this.idConsulta = updateConsultasPlus.numeroIdConsulta;         
            pessoalMedicoDAL pessoalMedicosDAL = new pessoalMedicoDAL();
            string especilalidade = pessoalMedicosDAL.listarPessoalMedicoById(updateConsultasPlus.numeroIdMedico).ToString();
            comboBox_especialidademedica.SelectedValue = Convert.ToInt32(especilalidade);
            pesquisarMedicospoEspecialidade(especilalidade);
            comboBox_MedicosEspecialistas.SelectedValue =updateConsultasPlus.numeroIdMedico;
            comboBox_ClientePaciente.SelectedValue = updateConsultasPlus.numeroIdPaciente.ToString();
            dateTimePicker_data.Value = Convert.ToDateTime(data[0]);
            textBox_hora.Text = hora[0];
            textBox_Minutos.Text = hora[1];
        }

        private void button_Agendar_Click(object sender, EventArgs e)
        {
            gestaoConsultasDAL gestaoConsultaDAL = new gestaoConsultasDAL();
            string dataHora = dateTimePicker_data.Value.ToString("dd/MM/yyyy") + " " + textBox_hora.Text + ":" + textBox_Minutos.Text + ":00";
            gestaoConsultaHander gch = new gestaoConsultaHander();
            (int codigo, gestaoConsulta gestaoConsultas, string error) = gch.ValidarGestaoConsultaUpdate (idConsulta.ToString (),dataHora, comboBox_MedicosEspecialistas.SelectedValue.ToString(), comboBox_ClientePaciente.SelectedValue.ToString());
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
                case 4:
                    MessageBox.Show(error);
                            return;
                default:
                    (int registo, string erro) = gestaoConsultaDAL.atualizarConsultaMedica(gestaoConsultas);
                    if (registo > 0)
                    {
                        MessageBox.Show("Consulta re-agendada na base de dados com sucesso!");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(erro);
                    }
                    return;
            }





        }
    }
}
