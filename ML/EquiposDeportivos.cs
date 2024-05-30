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
        [StringLength(50, ErrorMessage = "El nombre del equipo debe tener 50 caracteres.")]
        public string NombreEquipo { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "El nombre del entrenador debe tener 50 caracteres.")]
        public string Entrenador { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "El nombre de la fundacion debe tener 50 caracteres.")]
        public string Fundacion { get; set; }
        [Required]
        [Display(Name = "Campeonatos Ganados")]
        public int CampeonatosGanados { get; set; }
        public ML.Ciudad Ciudad{ get; set; }
        public List<ML.EquiposDeportivos> EquipoDeportivo {get; set;}

    }
}
