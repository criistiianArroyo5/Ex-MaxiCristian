using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ex_MaxiCristian.Modelos
{
    public class Beneficiarios
    {
        public int id { get; set; } = 0;

        public string Nombre { get; set; } = "";

        public string Apellidos { get; set; } = "";

        public string fNacimiento { get; set; } = "";

        public string Curp { get; set; } = "";

        public string Ssn { get; set; } = "";

        public int Telefono { get; set; } = 0;

        public string Nacionalidad { get; set; } = "";

        public int Porcentaje { get; set; } = 0;
        public int idEmpleado { get; set; } = 0;
    }
}
