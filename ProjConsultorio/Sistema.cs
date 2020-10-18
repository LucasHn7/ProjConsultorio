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
    public partial class Sistema : Form
    {
        public Sistema()
        {
            InitializeComponent();
        }

        private void msPaciente_Click(object sender, EventArgs e)
        {
            Form Paciente = new FormPaciente();
            Paciente.Show();
        }

        private void msMedico_Click(object sender, EventArgs e)
        {
            Form Medico = new FormMedico();
            Medico.Show();
        }

        private void msEspeciadade_Click(object sender, EventArgs e)
        {
            Form Especialidade = new FormEspecialidade();
            Especialidade.Show();
        }

        private void msConsulta_Click(object sender, EventArgs e)
        {
            Form Consulta = new FormConsulta();
            Consulta.Show();
        }

        private void msSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
