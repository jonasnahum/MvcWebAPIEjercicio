using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcWebAPIEjercicio.Controllers;
using MvcWebAPIEjercicio.Models;
using System.Collections.Generic;

namespace WebApi.Tests
{
    [TestClass]
    public class TestServiciosController
    {
        public XmlModelSerializer<alumnoModel> Db { get; set; }
        public ServiciosController Servicios { get; set; }

        public TestServiciosController() 
        {
            Db = new XmlModelSerializer<alumnoModel>();
            Servicios = new ServiciosController(Db);
        }
        
        [TestInitialize]//carga estos metodos primero antes de hacer los test.
        public void CreateEmptyDatabase() 
        {
            Db.CleanDataBase();
        }

        [TestMethod]
        public void GetReturnsListOfModels()
        {
            //arrange
            //Test Initialize

            //act
            IEnumerable<alumnoModel> result = Servicios.Get();

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void GetsOneModelById()
        {
            //arrange
            int id = 1;
            Servicios.Post(new alumnoModel() { grado = "1oA", id = 0, nombre = "test", promedio = 10 });

            //act
            alumnoModel result = Servicios.Get(id);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(id, result.id);
        }

        [TestMethod]
        public void SaveNewModel()
        {
            //arrange
            alumnoModel model = new alumnoModel() { grado = "1oA", id = 0, nombre = "test", promedio = 10 };

            //act
            Servicios.Post(model);
            alumnoModel fromDb = Servicios.Get(1); 

            //assert
            Assert.IsNotNull(fromDb);
        }

        [TestMethod]
        public void UpdateExistingModel()
        {
            //arrange
            alumnoModel model = new alumnoModel() { grado = "1oA", id = 0, nombre = "test", promedio = 10 };
            Servicios.Post(model);
            int id = 1;
            string grado = "2A";
            string nombre = "Juan";
            decimal promedio = 9.9m;
            alumnoModel fromDb = Servicios.Get(id);

            //act
            model.grado = grado;
            model.nombre = nombre;
            model.promedio = promedio;
            Servicios.Put(id, model);//se ejecuta el metodo put.
            alumnoModel afterUpdate = Servicios.Get(id);//se crea otro modelo y se manda traer el los datos del que se hizo model. porque si llamamos

            //assert
            Assert.AreEqual(grado, afterUpdate.grado);
            Assert.AreEqual(nombre, afterUpdate.nombre);
            Assert.AreEqual(promedio, afterUpdate.promedio);

        }

        [TestMethod]
        public void DeleteExistingModel()
        {
            //arrange
            alumnoModel model = new alumnoModel() { grado = "1oA", id = 0, nombre = "test", promedio = 10 };
            Servicios.Post(model);
            int id=1;

            //act
            Servicios.Delete(id);
            alumnoModel alumnoNull= Servicios.Get(id);
            
            //assert
            Assert.IsNull(alumnoNull);//como no existe, entonces es null.            
        }
    }
}
