using foiPicadaDeEnfermeiro.DAL;
using foiPicadaDeEnfermeiro.Handlers;
using foiPicadaDeEnfermeiro.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace foiPicadaDeEnfermeiro.formularios
{
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }


        clientePacienteDAL clientePacientesDAL = new clientePacienteDAL();

        private void button_Adicionar_Click(object sender, EventArgs e)
        {
            clientePacienteHander cph = new clientePacienteHander();
            (int codigo, clientePaciente clientePacientes, string error) = cph.ValidarClientePacienteInsert(textBox_ID.Text, textBox_NomeApelido.Text, textBox_Contacto.Text, textBox_SNS.Text .ToString());

            switch (codigo)
            {
                case 1:
                    MessageBox.Show(error);
                    textBox_ID.Focus();
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
                    textBox_SNS.Focus();
                    return;

                default:
                    (int registo, string erro) = clientePacientesDAL.inserirClientePaciente (clientePacientes);
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

        private void carregarLista()
        {

   
            List<clientePaciente> clientePacientes = clientePacientesDAL.listarClientePaciente ();
            dataGridView_Clientes.DataSource = clientePacientes;

        }
        private void frmClientes_Load(object sender, EventArgs e)
        {
            carregarLista();
        }

        private void textBox_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_SNS_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button_Actualizar_Click(object sender, EventArgs e)
        {
            clientePacienteHander cph = new clientePacienteHander();
            (int codigo, clientePaciente clientePacientes, string error) = cph.ValidarClientePacienteUpdate(textBox_ID.Text, textBox_NomeApelido.Text, textBox_Contacto.Text, textBox_SNS.Text.ToString());

            switch (codigo)
            {
                case 1:
                    MessageBox.Show(error);
                    textBox_ID.Focus();
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
                    textBox_SNS.Focus();
                    return;

                default:
                    (int registo, string erro) = clientePacientesDAL.atualizarClientePaciente (clientePacientes);
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
                    return;
            }
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            clientePacienteHander cph = new clientePacienteHander();
            (int codigo, clientePaciente clientePacientes, string error) = cph.VValidarClientePacienteDelete(textBox_ID.Text);

            switch (codigo)
            {
                case 1:
                    MessageBox.Show(error);
                    textBox_ID.Focus();
                    return;
         

                default:
                    (int registo, string erro) = clientePacientesDAL.eliminarClientePaciente (clientePacientes);
                    if (registo > 0)
                    {
                        MessageBox.Show("Registo apagado na base de dados com sucesso!");
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


        private void LimparFormulario() {
            textBox_ID.Clear();
                textBox_NomeApelido.Clear();
                textBox_Contacto.Clear();
            textBox_SNS.Clear();
            carregarLista();
        }
        private void button_LimparCampos_Click(object sender, EventArgs e)
        {
            LimparFormulario();
           
        }

        private void dataGridView_Clientes_MouseDown(object sender, MouseEventArgs e)
        {
            textBox_ID.Text = dataGridView_Clientes[0, dataGridView_Clientes.CurrentRow.Index].Value.ToString();
            textBox_NomeApelido.Text = dataGridView_Clientes[1, dataGridView_Clientes.CurrentRow.Index].Value.ToString();
            textBox_Contacto.Text = dataGridView_Clientes[2, dataGridView_Clientes.CurrentRow.Index].Value.ToString();
            textBox_SNS.Text = dataGridView_Clientes[3, dataGridView_Clientes.CurrentRow.Index].Value.ToString();


        }
    }
}
