using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjConsultorio
{
    public partial class FormPaciente : Form
    {
        public FormPaciente()
        {
            InitializeComponent();
        }

        public void limparcampos()
        {
            txtId.Clear();
            txtNome.Clear();
            txtCEP.Clear();
            txtRua.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            txtEstado.Clear();
            txtTelefone.Clear();
            txtCPF.Clear();
            txtConvenio.SelectedIndex = -1;
            txtPlano.SelectedIndex = -1;
            txtNumCartao.Clear();
            txtNome.Focus();

        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            using (var tb = new Contexto())
            {

                try
                {
                    tb.ObjetoPaciente.Add(new Paciente { Nome = txtNome.Text, CEP = txtCEP.Text, Rua = txtRua.Text, Bairro = txtBairro.Text, Cidade = txtCidade.Text, Estado = txtEstado.Text ,Telefone = txtTelefone.Text, CPF = txtCPF.Text, Convenio = txtConvenio.Text, Plano = txtPlano.Text ,NumCartao = txtNumCartao.Text });
                    tb.SaveChanges();
                    limparcampos();
                    MessageBox.Show("Paciente cadastrado", "Cadastro de Paciente");
                    AtualizaGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        public void AtualizaGrid()
        {

            using (var tb = new Contexto())
            {

                GridPaciente.DataSource = null;
                GridPaciente.DataSource = tb.ObjetoPaciente.ToList();

            }

        }
        private void LocalizaCep()
        {
            using (var ws = new Correios.AtendeClienteClient())
            {
                var resultado = ws.consultaCEP(txtCEP.Text);
                txtEstado.Text = resultado.uf;

                txtCidade.Text = resultado.cidade;

                txtBairro.Text = resultado.bairro;

                txtRua.Text = resultado.end;
            }
        }

        private void maskedTextBox1_Leave(object sender, EventArgs e)
        {
            try
            {
                LocalizaCep();
            }
            catch (Exception)
            {
                MessageBox.Show("CEP inválido", "CEP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormPaciente_Load(object sender, EventArgs e)
        {
            AtualizaGrid();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            using (var tb = new Contexto())
            {

                try
                {
                    var objeto = tb.ObjetoPaciente.Find(Convert.ToInt32(txtId.Text));
                    objeto.Nome = txtNome.Text;
                    objeto.CEP = txtCEP.Text;
                    objeto.Rua = txtRua.Text;
                    objeto.Bairro = txtBairro.Text;
                    objeto.Estado = txtEstado.Text;
                    objeto.Cidade = txtCidade.Text;
                    objeto.Telefone = txtTelefone.Text;
                    objeto.CPF = txtCPF.Text;
                    objeto.Convenio = txtConvenio.Text;
                    objeto.Plano = txtPlano.Text;
                    objeto.NumCartao = txtNumCartao.Text;


                    tb.Entry(objeto).State = EntityState.Modified;
                    tb.SaveChanges();
                    MessageBox.Show("Alteração Concluida", "Alteração");
                    limparcampos();
                    AtualizaGrid();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);

                }

            }
        }

        private void GridPaciente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = GridPaciente.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = GridPaciente.CurrentRow.Cells[1].Value.ToString();
            txtCEP.Text = GridPaciente.CurrentRow.Cells[2].Value.ToString();
            txtRua.Text = GridPaciente.CurrentRow.Cells[3].Value.ToString();
            txtBairro.Text = GridPaciente.CurrentRow.Cells[4].Value.ToString();
            txtCidade.Text = GridPaciente.CurrentRow.Cells[5].Value.ToString();
            txtEstado.Text = GridPaciente.CurrentRow.Cells[6].Value.ToString();
            txtTelefone.Text = GridPaciente.CurrentRow.Cells[7].Value.ToString();
            txtCPF.Text = GridPaciente.CurrentRow.Cells[8].Value.ToString();
            txtConvenio.Text = GridPaciente.CurrentRow.Cells[9].Value.ToString();
            txtPlano.Text = GridPaciente.CurrentRow.Cells[10].Value.ToString();
            txtNumCartao.Text = GridPaciente.CurrentRow.Cells[11].Value.ToString();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                using (var tb = new Contexto())
                {
                    var objeto = tb.ObjetoPaciente.Find(Convert.ToInt32(txtId.Text));
                    tb.ObjetoPaciente.Remove(objeto);
                    tb.SaveChanges();
                    MessageBox.Show("Excluido com Sucesso", "Exclusão");
                    limparcampos();
                    AtualizaGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
