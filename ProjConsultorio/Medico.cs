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
    class Medico
    {
        [Key]
        public int IdMedico { get; set; }
        [ForeignKey("Especialidad")]
        public int IdEspecialidade { get; set; }
        public Especialidad Especialidad { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
    }
}
