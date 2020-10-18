using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace ProjConsultorio
{
    class Especialidad
    {
        [Key]
        public int IdEspecialidade { get; set; }
        public string Especialidade { get; set; }
    }
}
