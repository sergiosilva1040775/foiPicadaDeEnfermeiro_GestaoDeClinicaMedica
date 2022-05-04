using foiPicadaDeEnfermeiro.DAL;
using foiPicadaDeEnfermeiro.Handlers;
using foiPicadaDeEnfermeiro.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace foiPicadaDeEnfermeiro.formularios
{
    public partial class frmMedico : Form
    {
        public frmMedico()
        {
            InitializeComponent();
        }

        pessoalMedicoDAL PessoalMedicoDAL = new pessoalMedicoDAL();
        private void carregarLista()
        {

            EspecialidadeMedicaDAL especialidadeMedicasDal = new EspecialidadeMedicaDAL();
            List<especialidadeMedica> especialidadeMedicas = especialidadeMedicasDal.listarEspecialidadesMedica();
            comboBox_especialidademedica.DataSource = especialidadeMedicas;
            comboBox_especialidademedica.DisplayMember = "description";
            comboBox_especialidademedica.ValueMember = "numeroId";
           
            List<pessoalMedico> pessoalMedicos = PessoalMedicoDAL.listarPessoalMedico();
            dataGridView_Medicos.DataSource = pessoalMedicos;

        }
        private void frmMedico_Load(object sender, EventArgs e)
        {
            carregarLista();
        }

        private void button_Adicionar_Click(object sender, EventArgs e)
        {
            pessoalMedicoHander pmh = new pessoalMedicoHander();
            (int codigo, pessoalMedico pessoalMedicos, string error) = pmh.ValidarPessoalMedicoInsert(textBox_NCD.Text, textBox_NomeApelido.Text, textBox_Contacto.Text, comboBox_especialidademedica.SelectedValue.ToString());

            switch (codigo)
            {
                case 1:
                    MessageBox.Show(error);
                    textBox_NCD.Focus();
                    return;
                case 2:
                    MessageBox.Show(error);
                    textBox_NomeApelido.Focus();
                    return;
                case 3:
                    MessageBox.Show(error);
                    textBox_Contacto.Focus();
                    return;
                case 4:
                    MessageBox.Show(error);
                    comboBox_especialidademedica.Focus();
                    return;

                default:
                    (int registo, string erro) = PessoalMedicoDAL.inserirPessoalMedico(pessoalMedicos);
                    if (registo > 0)
                    {
                        MessageBox.Show("Registo guardado na base de dados com sucesso!");
                        // this.Close();
                        LimparFormulario();
                    }
                    else
                    {
                        MessageBox.Show(erro);
                    }
                    return;
            }



        }

        private void button_Actualizar_Click(object sender, EventArgs e)
        {
            pessoalMedicoHander pmh = new pessoalMedicoHander();
            (int codigo, pessoalMedico pessoalMedicos, string error) = pmh.ValidarPessoalMedicoUpdate(textBox_NCD.Text, textBox_NomeApelido.Text, textBox_Contacto.Text, comboBox_especialidademedica.SelectedValue.ToString());
            switch (codigo)
            {
                case 1:
                    MessageBox.Show(error);
                    textBox_NCD.Focus();
                    return;
                case 2:
                    MessageBox.Show(error);
                    textBox_NomeApelido.Focus();
                    return;
                case 3:
                    MessageBox.Show(error);
                    textBox_Contacto.Focus();
                    return;
                case 4:
                    MessageBox.Show(error);
                    comboBox_especialidademedica.Focus();
                    return;
                default:
                    (int registo, string erro) = PessoalMedicoDAL.atualizarPessoalMedico(pessoalMedicos);
                    if (registo > 0)
                    {
                        MessageBox.Show("Registo guardado na base de dados com sucesso!");
                        // this.Close();
                        LimparFormulario();
                    }
                    else
                    {

                        MessageBox.Show(erro);
                    }
                    return;
            }
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            pessoalMedicoHander pmh = new pessoalMedicoHander();
            (int codigo, pessoalMedico pessoalMedicos, string error) = pmh.ValidarPessoalMedicoDelete(textBox_NCD.Text);

            if (codigo == 1)
            {
                MessageBox.Show(error);
                textBox_NCD.Focus();
                return;
            }
            (int registo, string erro) = PessoalMedicoDAL.eliminarPessoalMedico(pessoalMedicos);
            if (registo == 1)
            {
                MessageBox.Show("Registo apagado na base de dados com sucesso!");
                // this.Close();
                LimparFormulario();
            }
            else
            {

                MessageBox.Show(erro);
            }
        }




        private void LimparFormulario()
        {
            textBox_NCD.Clear();
            textBox_NomeApelido.Clear();
            textBox_Contacto.Clear();
            comboBox_especialidademedica.SelectedIndex = -1;
            carregarLista();
        }

        private void textBox_NCD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_Contacto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button_LimparCampos_Click(object sender, EventArgs e)
        {
            LimparFormulario();
        }

        private void dataGridView_Medicos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView_Medicos_MouseClick(object sender, MouseEventArgs e)
        {
            textBox_NCD.Text = dataGridView_Medicos[0, dataGridView_Medicos.CurrentRow.Index].Value.ToString();
            textBox_NomeApelido.Text = dataGridView_Medicos[1, dataGridView_Medicos.CurrentRow.Index].Value.ToString();
            textBox_Contacto.Text = dataGridView_Medicos[2, dataGridView_Medicos.CurrentRow.Index].Value.ToString();
            string esp = dataGridView_Medicos[3, dataGridView_Medicos.CurrentRow.Index].Value.ToString();
            comboBox_especialidademedica.SelectedValue = Convert.ToInt32(esp);//dataGridView_Medicos[3, dataGridView_Medicos.CurrentRow.Index].Value.ToString();

        }


    }
}
