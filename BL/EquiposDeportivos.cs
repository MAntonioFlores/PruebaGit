using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class EquiposDeportivos
    {
        public static (bool, string, Exception) Add(ML.EquiposDeportivos equiposDeportivos)
        {
            //ML.EquiposDeportivos equiposDeportivos = new ML.EquiposDeportivos();
            try
            {
                using (DL.ProyectoGitEntities context = new DL.ProyectoGitEntities())
                {
                    var rowsAffected = context.EquipoAdd(equiposDeportivos.NombreEquipo, equiposDeportivos.Entrenador, equiposDeportivos.Fundacion, equiposDeportivos.CampeonatosGanados, equiposDeportivos.Ciudad.IdCiudad);

                    if (rowsAffected > 0)
                    {
                        return (true, null, null);
                    }
                    else
                    {
                        return (false, null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, "Ocurrio un error" + ex, ex);
            }
        }
        public static (bool, string, Exception) Update(ML.EquiposDeportivos equiposDeportivos)
        {
            //ML.EquiposDeportivos equiposDeportivos = new ML.EquiposDeportivos();
            try
            {
                using (DL.ProyectoGitEntities context = new DL.ProyectoGitEntities())
                {
                    var rowsAffected = context.EquipoUpdate(equiposDeportivos.IdEquipo, equiposDeportivos.NombreEquipo, equiposDeportivos.Entrenador, equiposDeportivos.Fundacion, equiposDeportivos.CampeonatosGanados, equiposDeportivos.Ciudad.IdCiudad);

                    if (rowsAffected > 0)
                    {
                        return (true, null, null);
                    }
                    else
                    {
                        return (false, null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, "Ocurrio un error" + ex, ex);
            }
        }
        public static (bool, string, Exception) Delete(int? IdEquipo)
        {
            try
            {
                using (DL.ProyectoGitEntities context = new DL.ProyectoGitEntities())
                {
                    var rowsAffected = context.EquipoDelete(IdEquipo);

                    if (rowsAffected > 0)
                    {
                        return (true, null, null);
                    }
                    else
                    {
                        return (false, null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, "Ocurrio un error: " + ex, ex);
            }
        }

        public static (bool, string, ML.EquiposDeportivos, Exception) GetAll()
        {
            ML.EquiposDeportivos equiposDeportivos = new ML.EquiposDeportivos();
            try
            {
                using (DL.ProyectoGitEntities context = new DL.ProyectoGitEntities())
                {
                    var query = context.GetAll().ToList();

                    if (query.Count > 0)
                    {
                        equiposDeportivos.EquipoDeportivo = new List<ML.EquiposDeportivos>();
                        foreach (var registro in query)
                        {
                            ML.EquiposDeportivos equipoObj = new ML.EquiposDeportivos();

                            equipoObj.IdEquipo = registro.IdEquipo;
                            equipoObj.NombreEquipo = registro.NombreEquipo;
                            equipoObj.Entrenador = registro.Entrenador;
                            equipoObj.Fundacion = registro.Fundacion;
                            equipoObj.CampeonatosGanados = registro.CampeonatosGanados.Value;
                            equipoObj.Ciudad = new ML.Ciudad();
                            equipoObj.Ciudad.Nombre = registro.Nombre;

                            equiposDeportivos.EquipoDeportivo.Add(equipoObj);
                        }
                        return (true, null, equiposDeportivos, null);
                    }
                    else
                    {
                        return (false, "Ocurrio un error: ", equiposDeportivos, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, "Ocurrio un error: " + ex, null, null);
            }
        }
        public static (bool, string, ML.EquiposDeportivos, Exception) GetById(int? IdEquipo)
        {
            ML.EquiposDeportivos equipos = new ML.EquiposDeportivos();
            try
            {
                using (DL.ProyectoGitEntities context = new DL.ProyectoGitEntities())
                {
                    var query = context.GetByIdEquipo(IdEquipo).SingleOrDefault();

                    if (query != null)
                    {
                        equipos.NombreEquipo = query.NombreEquipo;
                        equipos.Entrenador = query.Entrenador;
                        equipos.Fundacion = query.Fundacion;
                        equipos.CampeonatosGanados = query.CampeonatosGanados.Value;
                        equipos.Ciudad = new ML.Ciudad();
                        equipos.Ciudad.IdCiudad = query.IdCiudad.Value;

                        return (true, null, equipos, null);
                    }
                    else
                    {
                        return (false, "Ocurrio un error: ", equipos, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, "Ocurrio un error: " + ex, null, ex);
            }
        }
    }
}
