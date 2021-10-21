using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class DtoCliente
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Identificacion { get; set; }
        public int Edad { get; set; }
        public bool Genero { get; set; }
        public bool Activo { get; set; }
        public bool Maneja { get; set; }
        public bool UsaLentes { get; set; }
        public bool EsDiabetico { get; set; }
        public bool PadeceOtraEnfermedad { get; set; }
        public string OtraEnfermedad { get; set; }
    }
}
