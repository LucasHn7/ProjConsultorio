using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjConsultorio
{
    public partial class LoginAdm : Form
    {
        public LoginAdm()
        {
            InitializeComponent();
        }

        public void limpacampos()
        {

            txtUsuario.Focus();
            txtUsuario.Clear();
            txtSenha.Clear();

        }

        public int confirm { get; set; }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (var tb = new Contexto())
            {
                try 
                { 
                    var objeto = tb.ObjetoManutUser.Where(a => a.Usuario == txtUsuario.Text).FirstOrDefault();


                    if (objeto != null)
                    {
                        if (objeto.Usuario == "adm")
                        {
                            if (objeto.Usuario == txtUsuario.Text)
                            {
                                if (objeto.Senha == txtSenha.Text)
                                {
                                    confirm = 1;
                                    this.Close();
                                    limpacampos();
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
