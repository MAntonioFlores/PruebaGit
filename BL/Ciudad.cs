using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Ciudad
    {
        public static (bool, string, ML.Ciudad, Exception) GetAll()
        {
            ML.Ciudad ciudad = new ML.Ciudad();
            try
            {
                using(DL.ProyectoGitEntities context = new DL.ProyectoGitEntities())
                {
                    var query = context.GetAllDDLCiudad().ToList();

                    if (query.Count > 0)
                    {
                        ciudad.Ciudades = new List<ML.Ciudad>();
                        foreach (var registro in query)
                        {
                            ML.Ciudad ciudadObj = new ML.Ciudad();

                            ciudadObj.IdCiudad = registro.IdCiudad;
                            ciudadObj.Nombre = registro.Nombre;

                            ciudad.Ciudades.Add(ciudadObj);
                        }
                        return (true, null, ciudad, null);
                    }
                    else
                    {
                        return (false, "Ocurrio un error", ciudad, null);
                    }
                }
            }
            catch (Exception ex )
            {
                return (false, "Ocurrio un error"+ ex, null, ex);
            }
        }
    }
}
