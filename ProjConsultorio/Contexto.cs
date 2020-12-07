using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ProjConsultorio
{
    class Contexto : DbContext
    {

        public Contexto() : base("conexao")
        {

        }

        public DbSet<Paciente> ObjetoPaciente { get; set; }
        public DbSet<Medico> ObjetoMedico { get; set; }
        public DbSet<Especialidad> ObjetoEspecialidade { get; set; }
        public DbSet<Consulta> ObjetoConsulta { get; set; }
        public DbSet<ManutUser> ObjetoManutUser { get; set; }

    }
}
