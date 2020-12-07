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
    public partial class FormEspecialidade : Form
    {
        public FormEspecialidade()
        {
            InitializeComponent();
        }

        public void limparcampos()
        {

            txtId.Clear();
            txtEspecialidade.Clear();

        }

        public void AtualizaGrid()
        {

            using (var tb = new Contexto())
            {

                GridEspecialidade.DataSource = null;
                GridEspecialidade.DataSource = tb.ObjetoEspecialidade.ToList();

            }

        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            using (var tb = new Contexto())
            {

                try
                {
                    tb.ObjetoEspecialidade.Add(new Especialidad { Especialidade = txtEspecialidade.Text });
                    tb.SaveChanges();
                    limparcampos();
                    MessageBox.Show("Especialidade cadastrada", "Cadastro de Paciente");
                    AtualizaGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void FormEspecialidade_Load(object sender, EventArgs e)
        {
            AtualizaGrid();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            using (var tb = new Contexto())
            {

                try
                {
                    var objeto = tb.ObjetoEspecialidade.Find(Convert.ToInt32(txtId.Text));
                    objeto.Especialidade = txtEspecialidade.Text;

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

        private void GridEspecialidade_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = GridEspecialidade.CurrentRow.Cells[0].Value.ToString();
            txtEspecialidade.Text = GridEspecialidade.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                using (var tb = new Contexto())
                {
                    var objeto = tb.ObjetoEspecialidade.Find(Convert.ToInt32(txtId.Text));
                    tb.ObjetoEspecialidade.Remove(objeto);
                    tb.SaveChanges();
                    MessageBox.Show("Especialidade excluida com Sucesso", "Exclusão");
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
