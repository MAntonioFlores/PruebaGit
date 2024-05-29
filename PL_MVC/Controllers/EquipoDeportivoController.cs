using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace PL_MVC.Controllers
{
    public class EquipoDeportivoController : Controller
    {
        // GET: EquipoDeportivo
        public ActionResult GetAll()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:65041/api/");

                var responseTask = client.GetAsync("EquiposDeportivos/GetAll");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<(bool, string, ML.EquiposDeportivos, Exception)>();
                    readTask.Wait();


                    ML.EquiposDeportivos equipos = readTask.Result.Item3;
                    equipos.Ciudad = new ML.Ciudad();

                    var resultadoCiudad = BL.Ciudad.GetAll();
                    equipos.Ciudad.Ciudades = resultadoCiudad.Item3.Ciudades;

                    return View(equipos);

                }
                else
                {
                    ML.EquiposDeportivos equipos = new ML.EquiposDeportivos();
                    return View(equipos);
                }

            }
        }

        public ActionResult Form(int? IdEquipo)
        {
            ML.EquiposDeportivos equipos = new ML.EquiposDeportivos();
            if (IdEquipo != null)
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:65041/api/");

                    var responseTask = client.GetAsync("EquiposDeportivos/GetById?IdEquipo=" + IdEquipo);
                    responseTask.Wait();

                    var result = responseTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<(bool, string, ML.EquiposDeportivos, Exception)>();
                        readTask.Wait();

                        if (readTask.Result.Item1 == true)
                        {
                            ML.EquiposDeportivos equipos1 = readTask.Result.Item3;

                            equipos1.Ciudad.Ciudades = new List<ML.Ciudad>();

                            var resultadoCiudad = BL.Ciudad.GetAll();

                            equipos1.Ciudad.Ciudades = resultadoCiudad.Item3.Ciudades;

                            return View(equipos1);
                        }
                        else
                        {
                            ML.EquiposDeportivos equipos1 = new ML.EquiposDeportivos();
                            return View(equipos1);
                        }
                    }
                    else
                    {
                        ML.EquiposDeportivos equipos1 = new ML.EquiposDeportivos();
                        return View(equipos1);
                    }
                }
            }
            else
            {

                ML.EquiposDeportivos equipo = new ML.EquiposDeportivos();
                equipo.Ciudad = new ML.Ciudad();
                equipo.Ciudad.Ciudades = new List<ML.Ciudad>();
                List<ML.Ciudad> ciudad = new List<ML.Ciudad>();
                using (HttpClient client = new HttpClient())
                {

                    client.BaseAddress = new Uri("http://localhost:65041/api/");
                    var response = client.GetAsync("Ciudades/GetAll");
                    response.Wait();

                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var content = result.Content.ReadAsStringAsync().Result;
                        var json = JsonConvert.DeserializeObject<ML.Ciudad>(content);
                        ciudad = json.Ciudades;
                        equipo.Ciudad.Ciudades = ciudad;
                    }

                    return View(equipo);
                }
            }

        }

        [HttpPost]
        public ActionResult Form(ML.EquiposDeportivos equipo)
        {
            if (equipo.IdEquipo != 0)
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:65041/api/");

                    var responseTask = client.PutAsJsonAsync("EquiposDeportivos/Update", equipo);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Text = "El Registro se ha Actualizado Exitosamente";
                        return View("Modal");
                    }
                    else
                    {
                        ViewBag.Text = "Ocurrio un Error: El Registro No se Actualizo Exitosamente";
                        return PartialView("Modal");
                    }
                }
            }
            else
            {
                //Add
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:65041/api/");
                    var response = client.PostAsJsonAsync<ML.EquiposDeportivos>("EquiposDeportivos/Add", equipo);
                    response.Wait();

                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {

                        var responseBody = result.Content.ReadAsStringAsync().Result;
                        //ViewBag.Text = responseBody;
                        ViewBag.Text = "Se Agrego Exitosamente";
                        return PartialView("Modal");

                    }
                    else
                    {
                        var responseBody = result.Content.ReadAsStringAsync().Result;
                        //ViewBag.Text = responseBody;
                        ViewBag.Text = "No se pudo Agregar";
                        return PartialView("Modal");
                    }
                }
            }
        }

        [HttpGet]
        public ActionResult Delete(int? IdEquipo)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:65041/api/");
                var responseTask = client.DeleteAsync("EquiposDeportivos/Delete?IdEquipo=" + IdEquipo);

                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Text = "Se Elimino Exitosamente";
                    return PartialView("Modal");

                }
                else
                {
                    ViewBag.Text = "No se Elimino";
                    return PartialView("Modal");

                }
            }

        }
    }
}