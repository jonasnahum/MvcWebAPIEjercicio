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
        private IDataBase<alumnoModel> mDb;
        private IDataBase<alumnoModel> Db //lazy loading
        {
            get 
            {
                if (mDb == null) 
                {
                    mDb = new XmlModelSerializer();
                }
                return mDb;
            }
        }

        // GET api/servicios
        public IEnumerable<alumnoModel> Get()
        {
            return Db.Get();
        }

        // GET api/servicios/5
        public alumnoModel Get(int id)
        {
            return Db.Get(id);
        }

        // POST api/servicios        
        public void Post([FromBody]alumnoModel value)//recibe un objeto de tipo alumnoModel
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
