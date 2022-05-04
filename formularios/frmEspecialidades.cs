using foiPicadaDeEnfermeiro.DAL;
using foiPicadaDeEnfermeiro.Handlers;
using foiPicadaDeEnfermeiro.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace foiPicadaDeEnfermeiro.formularios
{
    public partial class frmEspecialidades : Form
    {
        public frmEspecialidades()
        {
            InitializeComponent();
        }

        private void frmEspecialidades_Load(object sender, EventArgs e)
        {
            carregarLista();
        }

        private void carregarLista()
        {

            EspecialidadeMedicaDAL dal = new EspecialidadeMedicaDAL();

            List<especialidadeMedica> especialidadeMedicas = dal.listarEspecialidadesMedica();

            dataGridView_Especialidades.DataSource = especialidadeMedicas;

            dataGridView_Especialidades.Columns["numeroId"].Visible = false;


        }

        private void button_Adicionar_Click(object sender, EventArgs e)
        {
            especialidadeMedicaHander emh = new especialidadeMedicaHander();
            (int codigo, especialidadeMedica especialidadeMedicas, string error) = emh.ValidarEspecialidadeMedicaInsert(textBox_Descricao.Text);

            if (codigo == 1)
            {
                MessageBox.Show(error);
                textBox_Descricao.Focus();
                return;
            }


            EspecialidadeMedicaDAL dal = new EspecialidadeMedicaDAL();

            (int registo, string erro) = dal.inserirEspecialidadeMedica(especialidadeMedicas);

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

        }

        private void dataGridView_Especialidades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //var selectedRow = dataGridView_Especialidades.SelectedRows[0].DataBoundItem as especialidadeMedica;
            //textBox_Id.Text = selectedRow.numeroId.ToString();
            //textBox_Descricao.Text = selectedRow.description .ToString();
            textBox_Id.Text = dataGridView_Especialidades[0, dataGridView_Especialidades.CurrentRow.Index].Value.ToString();
            textBox_Descricao.Text = dataGridView_Especialidades[1, dataGridView_Especialidades.CurrentRow.Index].Value.ToString();

        }



        private void button_Actualizar_Click(object sender, EventArgs e)
        {
            especialidadeMedicaHander emh = new especialidadeMedicaHander();
            (int codigo, especialidadeMedica especialidadeMedicas, string error) = emh.ValidarEspecialidadeMedicaUpdate(textBox_Id.Text, textBox_Descricao.Text);

            if (codigo == 1)
            {
                MessageBox.Show(error);
                textBox_Descricao.Focus();
                return;
            }


            EspecialidadeMedicaDAL dal = new EspecialidadeMedicaDAL();

            (int registo, string erro) = dal.atualizarEspecialidadeMedica(especialidadeMedicas);

            if (registo > 0)
            {
                MessageBox.Show("Registo actualizado na base de dados com sucesso!");
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

            textBox_Id.Clear();
            textBox_Descricao.Clear();
            carregarLista();

        }

        private void button_LimparCampos_Click(object sender, EventArgs e)
        {
            LimparFormulario();

        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            especialidadeMedicaHander emh = new especialidadeMedicaHander();
            (int codigo, especialidadeMedica especialidadeMedicas, string error) = emh.ValidarEspecialidadeMedicaDelete(textBox_Id.Text);

            if (codigo == 1)
            {
                MessageBox.Show(error);
                textBox_Descricao.Focus();
                return;
            }


            EspecialidadeMedicaDAL dal = new EspecialidadeMedicaDAL();

            (int registo, string erro) = dal.eliminarEspecialidadeMedica(especialidadeMedicas);

            if (registo > 0)
            {
                MessageBox.Show("Registo deletado na base de dados com sucesso!");
                // this.Close();
                LimparFormulario();
            }
            else
            {
                MessageBox.Show(erro);
            }
        }

  
    }
}
