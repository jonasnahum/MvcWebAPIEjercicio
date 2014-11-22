using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace MvcWebAPIEjercicio.Models
{
    public interface IDataBase<T>//interface que recibe un tipo
    {
        IEnumerable<T> Get();//debe tener metodo Get que regrese un IEnumerable de tipo T.
        T Get(int id);//otro que reciba un id y que regrese un tipo T.
        void Save(T model);//que reciba un modelo de T.
        void Delete(int id);//que reciba un id y no regrese nada.
    }


    public class XmlModelSerializer : IDataBase<alumnoModel>//serializador de modelo.se manda el tipo alumnoModel a la interface.
    {
        /*
           <?xml version="1.0" encoding="utf-16"?>
           <ArrayOfAlumnoModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" />
         */
        private List<alumnoModel> mAlumnos = null;
        public XmlModelSerializer()//constructor de la clase.
        {          
            LoadFromFile();
        }

        private void LoadFromFile() 
        {
            alumnoModel[] alumnos = null;//primero el array alumnos es nulo.
            XmlSerializer serializer = new XmlSerializer(typeof(alumnoModel[]));//se crea un objeto serializador de alumnoModel[]
            using (Stream fs = File.OpenRead(Path))
            {
                alumnos = (alumnoModel[])serializer.Deserialize(fs);//se deserializa lo que halla en el path y se guarda en alumnos, que antes estaba vacio.
            }
            mAlumnos = alumnos.ToList();//se convierte a lista y se manda a la variable privada.
        }

        private void SaveToFile()
        {
            XmlSerializer x = new XmlSerializer(typeof(alumnoModel[]));//se crea un objeto serializador de alumnoModel[]
            using (var fileStream = File.Create(Path))//se guarda la direccion.
            {
                x.Serialize(fileStream, Alumnos.ToArray());//se manda serializar lo que hay en List<alumnoModel> Alumnos
            }
        }

        public string Path 
        {
            get 
            {
                return @"C:\Users\casa\Documents\GitHub\MvcWebAPIEjercicio\MvcWebAPIEjercicio\App_Data\AlumnosApp\DataBase.xml";
            }
        }

        public List<alumnoModel> Alumnos 
        {
            get 
            {
                return mAlumnos;
            }
        }

        public IEnumerable<alumnoModel> Get()
        {
            return Alumnos;
        }

        public alumnoModel Get(int id)
        {
            return Alumnos.FirstOrDefault(a => a.id == id);
        }

        public void Save(alumnoModel model)
        {
            alumnoModel item = Get(model.id);
            if (item != null)
            {
                item.nombre = model.nombre;
                item.promedio = model.promedio;
                item.grado = model.grado;
            }
            else 
            {
                model.id = Alumnos.Count + 1;
                Alumnos.Add(model);
            }
            SaveToFile();
        }

        public void Delete(int id)
        {
            alumnoModel item = Get(id);
            if (item != null)
            {
                Alumnos.Remove(item);
            }
            SaveToFile();
        }
    }
}