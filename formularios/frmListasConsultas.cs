using foiPicadaDeEnfermeiro.DAL;
using foiPicadaDeEnfermeiro.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace foiPicadaDeEnfermeiro.formularios
{
    public partial class frmListasConsultas : Form
    {
        public frmListasConsultas()
        {
            InitializeComponent();
        }

        private void frmListasConsultas_Load(object sender, EventArgs e)
        {
            carregarLista();
        }

        private void carregarLista()
        {

            gestaoConsultasDAL gestaoConsultaDAL = new gestaoConsultasDAL();
            List<gestaoConsultasPlus> gestaoConsultas = gestaoConsultaDAL.listarGestaoConsultaPlus();
            dataGridView_listasConsultas.DataSource = gestaoConsultas;






        }
        private void button_actualizarConsulta_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView_listasConsultas.CurrentRow.DataBoundItem as gestaoConsultasPlus;
            frmEditarConsultas frmEditarConsulta = new frmEditarConsultas();
            frmEditarConsulta.setValores(selectedRow);
            DialogResult dr = frmEditarConsulta.ShowDialog();

            //frmEditarConsulta.setValores();
            if (dr == DialogResult.OK)
            {
                carregarLista();


            }
        }

        private void button_apagarConsulta_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Tem a certeza que quer eliminar este registo?", "Confirme", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                var selectedRow = dataGridView_listasConsultas.CurrentRow.DataBoundItem as gestaoConsultasPlus;

                gestaoConsultasDAL gestaoConsultaDAL = new gestaoConsultasDAL();

                (int registo, string erro) = gestaoConsultaDAL.eliminarConsultaMedicaPlus(selectedRow);

                if (registo > 0)
                {
                    MessageBox.Show("Eliminação feita com sucesso!");
                    carregarLista();
                }
                else
                {
                    MessageBox.Show(erro);
                }
            }
        }
    }
}
