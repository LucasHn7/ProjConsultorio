using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjConsultorio
{
    class Consulta
    {
        [Key]
        public int IdConsulta { get; set; }
        [ForeignKey("Paciente")]
        public int IdPaciente { get; set; }
        public Paciente Paciente { get; set; }
        [ForeignKey("Medico")]
        public int IdMedico { get; set; }
        public Medico Medico { get; set; }
        public DateTime Data { get; set; }
        public double Valor { get; set; }
        public string Diagnostico { get; set; }
        public string Exame { get; set; }

    }
}
