using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Ciudad
    {
        public int IdCiudad { get; set; }
        public string Nombre { get; set; }
        public List<ML.Ciudad> Ciudades { get; set; }
    }
}
