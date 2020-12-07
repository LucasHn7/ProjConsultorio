using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjConsultorio
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        public void limpacampos()
        {

            txtUsuario.Focus();
            txtUsuario.Clear();
            txtSenha.Clear();

        }

        public void Login()
        {

            if (txtUsuario.Text == "" || txtSenha.Text == "")
            {

                MessageBox.Show("Digite seu usuário e senha!", "Campos em Branco!" ,MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            else
            {

                using (var tb = new Contexto())
                {

                    try
                    {
                        var objeto = tb.ObjetoManutUser.Where(a => a.Usuario == txtUsuario.Text).FirstOrDefault();

                        if (objeto != null)
                        {
                            if(objeto.Usuario == txtUsuario.Text)
                            {
                                if (objeto.Senha == txtSenha.Text)
                                {

                                    MessageBox.Show("Login Efetuado", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    limpacampos();
                                    this.Hide();
                                    Form f = new Sistema();
                                    f.Closed += (s, args) => this.Close();
                                    f.Show();

                                }
                                else
                                {

                                    MessageBox.Show("Usuário ou senha incorretos!", "Falha ao logar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    limpacampos();

                                }
                            }
                            else
                            {

                                MessageBox.Show("Usuário ou senha incorretos!", "Falha ao logar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                limpacampos();

                            }
                        }
                        else
                        {
                            MessageBox.Show("Usuário ou senha incorretos!", "Falha ao logar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            limpacampos();
                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }

            }

        }

        private void btnLogar_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {

                Login();

            }
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                Login();

            }
        }
    }
}
