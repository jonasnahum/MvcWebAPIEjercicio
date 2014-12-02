using MvcWebAPIEjercicio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcWebAPIEjercicio.Controllers
{
    public class ServiciosController : ApiController//hereda de ApiController.
    {
        private XmlModelSerializer<alumnoModel> Db
        {
            get;
            set;
        }

        public ServiciosController(XmlModelSerializer<alumnoModel> db) 
        {
            this.Db = db;
        }

        // GET api/servicios
        public IEnumerable<alumnoModel> Get()
        {
            return Db.Get();//accesa a las propiedades de la clase  XmlModelSerializer() a travez de su objeto Db., que tambien hereda de la interface IDataBase.
        }

        // GET api/servicios/5
        public alumnoModel Get(int id)
        {
            return Db.Get(id);
        }

        // POST api/servicios        
        public void Post([FromBody]alumnoModel value)//[FromBody] es lo que viene del request en el data.que esta en controllers.js...recibe un objeto de tipo alumnoModel
        {
            Db.Save(value);
        }

        // PUT api/servicios/5
        public void Put(int id, [FromBody]alumnoModel value)//[FromBody]viene del data del ajax , y el id viene del url del request. es para que haga un objeto del body del request que a su vez viene del ajax.
        {
            Db.Save(value);
        }

        // DELETE api/servicios/5
        public void Delete(int id)
        {
            Db.Delete(id);
        }
    }
}
