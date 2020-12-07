using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjConsultorio
{
    public partial class FormMedico : Form
    {
        public FormMedico()
        {
            InitializeComponent();
        }

        public void limparcampos()
        {
            txtId.Clear();
            txtNome.Clear();
            txtEspecialidade.SelectedIndex = -1;
            txtCEP.Clear();
            txtRua.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            txtEstado.Clear();
            txtTelefone.Clear();
            txtCPF.Clear();
        }

        public void AtualizaGrid()
        {

            using (var tb = new Contexto())
            {

                GridMedico.DataSource = null;
                GridMedico.DataSource = tb.ObjetoMedico.ToList();

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

        private void btnInserir_Click(object sender, EventArgs e)
        {
            using (var tb = new Contexto())
            {

                try
                {
                    tb.ObjetoMedico.Add(new Medico { Nome = txtNome.Text, IdEspecialidade = Convert.ToInt32(txtEspecialidade.SelectedValue),CEP = txtCEP.Text, Rua = txtRua.Text, Bairro = txtBairro.Text, Cidade = txtCidade.Text, Estado = txtEstado.Text, Telefone = txtTelefone.Text, CPF = txtCPF.Text });
                    tb.SaveChanges();
                    limparcampos();
                    MessageBox.Show("Médico cadastrado", "Cadastro de Médico");
                    AtualizaGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void FormMedico_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'dbConsultorioDataSet6.Medicos'. Você pode movê-la ou removê-la conforme necessário.
            this.medicosTableAdapter.Fill(this.dbConsultorioDataSet6.Medicos);
            AtualizaGrid();
            this.especialidadsTableAdapter.Fill(this.dbConsultorioDataSet1.Especialidads);
        }

        private void txtCEP_Leave(object sender, EventArgs e)
        {
            LocalizaCep();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            using (var tb = new Contexto())
            {

                try
                {
                    var objeto = tb.ObjetoMedico.Find(Convert.ToInt32(txtId.Text));
                    objeto.Nome = txtNome.Text;
                    objeto.IdEspecialidade = Convert.ToInt32(txtEspecialidade.SelectedValue);
                    objeto.CEP = Convert.ToString(txtCEP.Text);
                    objeto.Rua = txtRua.Text;
                    objeto.Bairro = txtBairro.Text;
                    objeto.Estado = txtEstado.Text;
                    objeto.Cidade = txtCidade.Text;
                    objeto.Telefone = Convert.ToString(txtTelefone.Text);
                    objeto.CPF = Convert.ToString(txtCPF.Text);

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

        private void GridMedico_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = GridMedico.CurrentRow.Cells[0].Value.ToString();

            using (var tb = new Contexto())
            {
                try
                {
                    int EspecialidadeID;

                    EspecialidadeID = Convert.ToInt32(GridMedico.CurrentRow.Cells[1].Value);
                    var objeto = tb.ObjetoEspecialidade.Find(EspecialidadeID);
                    txtEspecialidade.Text = objeto.Especialidade;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            txtNome.Text = GridMedico.CurrentRow.Cells[2].Value.ToString();
            txtCEP.Text = GridMedico.CurrentRow.Cells[5].Value.ToString();
            txtRua.Text = GridMedico.CurrentRow.Cells[6].Value.ToString();
            txtBairro.Text = GridMedico.CurrentRow.Cells[7].Value.ToString();
            txtCidade.Text = GridMedico.CurrentRow.Cells[8].Value.ToString();
            txtEstado.Text = GridMedico.CurrentRow.Cells[9].Value.ToString();
            txtTelefone.Text = GridMedico.CurrentRow.Cells[3].Value.ToString();
            txtCPF.Text = GridMedico.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                using (var tb = new Contexto())
                {
                    var objeto = tb.ObjetoMedico.Find(Convert.ToInt32(txtId.Text));
                    tb.ObjetoMedico.Remove(objeto);
                    tb.SaveChanges();
                    MessageBox.Show("Medico excluido com Sucesso", "Exclusão");
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
