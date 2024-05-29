using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class EquiposDeportivos
    {
        public int IdEquipo { get; set; }

        [Required]
        [Display(Name = "Nombre del Equipo")]
        public string NombreEquipo { get; set; }
        [Required]
        public string Entrenador { get; set; }
        [Required]
        public string Fundacion { get; set; }
        [Required]
        [Display(Name = "Campeonatos Ganados")]
        public int CampeonatosGanados { get; set; }
        public ML.Ciudad Ciudad{ get; set; }
        public List<ML.EquiposDeportivos> EquipoDeportivo {get; set;}

    }
}
