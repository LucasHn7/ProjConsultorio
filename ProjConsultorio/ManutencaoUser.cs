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
    public partial class ManutencaoUser : Form
    {
        public ManutencaoUser()
        {
            InitializeComponent();
        }

        public void limparcampos()
        {
            txtNome.Clear();
            txtSobrenome.Clear();
            txtSegNome.Clear();
            txtUsuario.Clear();
            txtSenha.Clear();
            txtId.Clear();
        }

        private void AtualizaGrid()
        {
            using (var tb = new Contexto())
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = tb.ObjetoManutUser.ToList();
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if(txtUsuario.Text != "" && txtSenha.Text != "")
            { 
                try
                {
                    

                    using (var tb = new Contexto())

                    {
                        tb.ObjetoManutUser.Add(new ManutUser { Nome = txtNome.Text, SegundoNome = txtSegNome.Text, Sobrenome = txtSobrenome.Text, Usuario = txtUsuario.Text,
                        Senha = txtSenha.Text });
                        tb.SaveChanges();
                        limparcampos();
                        AtualizaGrid();
                        MessageBox.Show("Usuário incluído com Sucesso", "Inclusão");

                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);

                }
            }
            else
            {
                MessageBox.Show("Preencha os campos corretamente", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtSobrenome_Leave(object sender, EventArgs e)
        {
            if (alterar == 0)
            {

                string nome = txtNome.Text;
                string segundonome = txtSegNome.Text;
                string sobrenome = txtSobrenome.Text;

                string usuario;

                if (segundonome == "")
                {
                    usuario = nome + "." + sobrenome;
                    txtUsuario.Text = usuario;
                }
                else
                {
                    string sn = segundonome.Substring(0, 1);
                    usuario = nome + "." + sn + sobrenome;
                    txtUsuario.Text = usuario;
                }

            }
            
        }

        private void ManutencaoUser_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'dbConsultorioDataSet4.ManutUsers'. Você pode movê-la ou removê-la conforme necessário.
            this.manutUsersTableAdapter.Fill(this.dbConsultorioDataSet4.ManutUsers);
            AtualizaGrid();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            using (var tb = new Contexto())
            {

                try
                {
                    alterar = 0;
                    var objeto = tb.ObjetoManutUser.Find(Convert.ToInt32(txtId.Text));
                    objeto.Nome = txtNome.Text;
                    objeto.SegundoNome = txtSegNome.Text;
                    objeto.Sobrenome = txtSobrenome.Text;
                    objeto.Usuario = txtUsuario.Text;
                    objeto.Senha = txtSenha.Text;

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

        private void txtUsuario_DoubleClick(object sender, EventArgs e)
        {
            LoginAdm Confimado = new LoginAdm();
            Confimado.ShowDialog();

            if(Confimado.confirm == 1)
            {

                txtUsuario.ReadOnly = false;

            }
            else
            {

                txtUsuario.ReadOnly = true;

            }

        }

        int alterar = 0;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            alterar = 1;
            txtId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtUsuario.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtSenha.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtNome.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtSegNome.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtSobrenome.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                using (var tb = new Contexto())
                {
                    var objeto = tb.ObjetoManutUser.Find(Convert.ToInt32(txtId.Text));
                    tb.ObjetoManutUser.Remove(objeto);
                    tb.SaveChanges();
                    MessageBox.Show("Usuário excluido com Sucesso", "Exclusão");
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
