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
    public partial class FormConsulta : Form
    {
        public FormConsulta()
        {
            InitializeComponent();
        }

        public void AtualizaGrid()
        {

            using (var tb = new Contexto())
            {

                GridConsulta.DataSource = null;
                GridConsulta.DataSource = tb.ObjetoConsulta.ToList();

            }

        }

        public void limparcampos()
        {
            txtId.Clear();
            txtPaciente.SelectedIndex = -1;
            txtMedico.SelectedIndex = -1;
            txtData.Clear();
            txtValor.Clear();
            txtDiagnostico.Clear();
            txtExame.Clear();
        }

        private void FormConsulta_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'dbConsultorioDataSet5.Consultas'. Você pode movê-la ou removê-la conforme necessário.
            this.consultasTableAdapter.Fill(this.dbConsultorioDataSet5.Consultas);
            // TODO: esta linha de código carrega dados na tabela 'dbConsultorioDataSet3.Medicos'. Você pode movê-la ou removê-la conforme necessário.
            this.medicosTableAdapter.Fill(this.dbConsultorioDataSet3.Medicos);
            // TODO: esta linha de código carrega dados na tabela 'dbConsultorioDataSet2.Pacientes'. Você pode movê-la ou removê-la conforme necessário.
            this.pacientesTableAdapter.Fill(this.dbConsultorioDataSet2.Pacientes);
            AtualizaGrid();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            using (var tb = new Contexto())
            {

                try
                {
                    tb.ObjetoConsulta.Add(new Consulta { IdPaciente = Convert.ToInt32(txtPaciente.SelectedValue), IdMedico = Convert.ToInt32(txtMedico.SelectedValue), Data = Convert.ToDateTime(txtData.Text), Valor = Convert.ToDouble(txtValor.Text) ,Diagnostico = txtDiagnostico.Text, Exame = txtExame.Text });
                    tb.SaveChanges();
                    limparcampos();
                    MessageBox.Show("Consulta cadastrada", "Cadastro de Consulta");
                    AtualizaGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            using (var tb = new Contexto())
            {

                try
                {
                    var objeto = tb.ObjetoConsulta.Find(Convert.ToInt32(txtId.Text));
                    objeto.IdPaciente = Convert.ToInt32(txtPaciente.SelectedValue);
                    objeto.IdMedico = Convert.ToInt32(txtMedico.SelectedValue);
                    objeto.Data = Convert.ToDateTime(txtData.Text);
                    objeto.Valor = Convert.ToDouble(txtValor.Text);
                    objeto.Diagnostico = txtDiagnostico.Text;
                    objeto.Exame = txtExame.Text;

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

        private void GridConsulta_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            txtId.Text = GridConsulta.CurrentRow.Cells[0].Value.ToString();

            using (var tb = new Contexto())
            {
                try
                {
                    int MedicoID;

                    MedicoID = Convert.ToInt32(GridConsulta.CurrentRow.Cells[2].Value);
                    var objeto = tb.ObjetoMedico.Find(MedicoID);
                    txtMedico.Text = objeto.Nome;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            using (var tb = new Contexto())
            {
                try
                {
                    int PacienteID;

                    PacienteID = Convert.ToInt32(GridConsulta.CurrentRow.Cells[1].Value);
                    var objeto = tb.ObjetoPaciente.Find(PacienteID);
                    txtPaciente.Text = objeto.Nome;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            txtData.Text = GridConsulta.CurrentRow.Cells[3].Value.ToString();
            txtValor.Text = GridConsulta.CurrentRow.Cells[4].Value.ToString();
            txtDiagnostico.Text = GridConsulta.CurrentRow.Cells[5].Value.ToString();
            txtExame.Text = GridConsulta.CurrentRow.Cells[6].Value.ToString();

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                using (var tb = new Contexto())
                {
                    var objeto = tb.ObjetoConsulta.Find(Convert.ToInt32(txtId.Text));
                    tb.ObjetoConsulta.Remove(objeto);
                    tb.SaveChanges();
                    MessageBox.Show("Consulta excluida com Sucesso", "Exclusão");
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
