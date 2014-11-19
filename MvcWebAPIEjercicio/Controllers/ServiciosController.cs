using MvcWebAPIEjercicio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcWebAPIEjercicio.Controllers
{
    public class ServiciosController : ApiController
    {
        // GET api/servicios
        public IEnumerable<alumnoModel> Get()
        {
            return new alumnoModel[] 
            {
                new alumnoModel(){ id = 1, grado = "1a", nombre = "Jonas", promedio = 9.0m }//regresa un objeto anonimo.
            };
        }

        // GET api/servicios/5
        public alumnoModel Get(int id)
        {
            return new alumnoModel() { grado = "1a", nombre = "Jonas", promedio = 9.0m, id = id };
        }

        // POST api/servicios        
        public void Post([FromBody]alumnoModel value)//recibe un objeto de tipo alumnoModel
        {
            var it = value;
        }

        // PUT api/servicios/5
        public void Put(int id, [FromBody]alumnoModel value)//[FromBody]viene del data del ajax , y el id viene del url del request. es para que haga un objeto del body del request que a su vez viene del ajax.
        {
            var it = value;
        }

        // DELETE api/servicios/5
        public void Delete(int id)
        {
            var it = id;
        }
    }
}
