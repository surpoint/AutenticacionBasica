using AutenticacionBasica.Filtros;
using AutenticacionBasica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace AutenticacionBasica.Controllers
{
    public class ValuesController : ApiController
    {


        [BasicAuthentication]
        public HttpResponseMessage Get(string gender = "A")
        {
            string username = Thread.CurrentPrincipal.Identity.Name;

            using (EjemploEntities entities = new EjemploEntities())
            {
                switch (gender)
                {
                    case "M":
                        return Request.CreateResponse(HttpStatusCode.OK,
                            entities.Personas.Where(e => e.Sexo.ToUpper() == "M").ToList());
                    case "F":
                        return Request.CreateResponse(HttpStatusCode.OK,
                            entities.Personas.Where(e => e.Sexo.ToUpper() == "F").ToList());
                    case "A":
                        return Request.CreateResponse(HttpStatusCode.OK,
                            entities.Personas.ToList());
                    default:

                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                 "Valor para sexo debe ser  M F A. " + gender + " es inválido");
                }
            }
        }

     
     
    }
}
