using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcWebAPIEjercicio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Tests
{
    [TestClass]
    public class TestXmlModelSerializer
    {
        public XmlModelSerializer<alumnoModel> Db { get; set; }
        public TestXmlModelSerializer()
        {
            Db = new XmlModelSerializer<alumnoModel>();
        }

        [TestInitialize]//carga estos metodos primero antes de hacer los test.
        public void CreateEmptyDatabase()
        {
            Db.CleanDataBase();
        }
        [TestMethod]
        public void GetReturnsIEnumerableOfAlumnoModel()
        {
            //arrange

            //act
            IEnumerable<alumnoModel> result = Db.Get();

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }
        [TestMethod]
        public void GetsOneModelById()
        {
            //arrange
            int id = 1;
            Db.Save(new alumnoModel() { grado = "1oA", id = 0, nombre = "test", promedio = 10 });

            //act
            alumnoModel result = Db.Get(id);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(id, result.id);
        }
        [TestMethod]
        public void SaveWorks()
        {
            //arrange
            alumnoModel model = new alumnoModel() { grado = "1oA", id = 0, nombre = "test", promedio = 10 };

            //act
            Db.Save(model);
            alumnoModel NuevoalumnoModelParaProbarQueSeGuardomodelQuePermanecieronLosDatos = Db.Get(1);

            //assert
            Assert.IsNotNull(NuevoalumnoModelParaProbarQueSeGuardomodelQuePermanecieronLosDatos);
        }
        [TestMethod]
        public void DeleteExistingModel()
        {
            //arrange
            alumnoModel model = new alumnoModel() { grado = "1oA", id = 0, nombre = "test", promedio = 10 };
            Db.Save(model);
            int id = 1;//porque 0+1=1.

            //act
            Db.Delete(id);
            alumnoModel alumnoNull = Db.Get(id);//se crea otro alumnoModel para probar que lo que guardo model no existe.

            //assert
            Assert.IsNull(alumnoNull);//como no existe, es null
        }



    }
}
