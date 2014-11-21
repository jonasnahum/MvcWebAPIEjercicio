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
    public interface IDataBase<T>
    {
        IEnumerable<T> Get();
        T Get(int id);
        void Save(T model);
        void Delete(int id);
    }


    public class XmlModelSerializer : IDataBase<alumnoModel>
    {
        /*
           <?xml version="1.0" encoding="utf-16"?>
           <ArrayOfAlumnoModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" />
         */
        private List<alumnoModel> mAlumnos = null;
        public XmlModelSerializer() 
        {          
            LoadFromFile();
        }

        private void LoadFromFile() 
        {
            alumnoModel[] alumnos = null;
            XmlSerializer serializer = new XmlSerializer(typeof(alumnoModel[]));
            using (Stream fs = File.OpenRead(Path))
            {
                alumnos = (alumnoModel[])serializer.Deserialize(fs);
            }
            mAlumnos = alumnos.ToList();
        }

        private void SaveToFile()
        {
            XmlSerializer x = new XmlSerializer(typeof(alumnoModel[]));
            using (var fileStream = File.Create(Path))
            {
                x.Serialize(fileStream, Alumnos.ToArray());
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