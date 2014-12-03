using Castle.MicroKernel;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace MvcWebAPIEjercicio.Models
{
    public interface IDataBase<T>//interface que recibe un tipo. en este caso recibe alumnoModel.
    {
        IEnumerable<T> Get();//la clase que implemente esta interface debe tener metodo Get que regrese un IEnumerable de tipo T.
        T Get(int id);//otro que reciba un id y que regrese un tipo T.
        void Save(T model);//que reciba un modelo de T.
        void Delete(int id);//que reciba un id y no regrese nada.
    }


    public class XmlModelSerializer<T> : IDataBase<T> where T : class, IAlumnoModel
    //serializador de modelo.se manda el tipo alumnoModel a la interface, cumple con contrato.
    {
        /*
           <?xml version="1.0" encoding="utf-16"?>
           <ArrayOfAlumnoModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" />
         */
        private List<T> mAlumnos = null;
        public XmlModelSerializer()//constructor de la clase.
        {          
            LoadFromFile();//se manda deserializar y se llena mAlumnos.        
        }

        private void LoadFromFile() 
        {
            T[] alumnos = null;//primero el array alumnos es nulo.
            XmlSerializer serializer = new XmlSerializer(typeof(T[]));//se crea un objeto serializador de alumnoModel[]
            using (Stream fs = File.OpenRead(Path))
            {
                alumnos = (T[])serializer.Deserialize(fs);//se   DESERIALIZA lo que halla en el path y se guarda en alumnos, que antes estaba vacio.
            }
            mAlumnos = alumnos.ToList();//se convierte a lista y se manda a la variable privada.
        }

        private void SaveToFile()
        {
            XmlSerializer x = new XmlSerializer(typeof(T[]));//se crea un objeto serializador de alumnoModel[]
            using (var fileStream = File.Create(Path))//se guarda la direccion.
            {
                x.Serialize(fileStream, Alumnos.ToArray());//se manda SERIALIZAR lo que hay en mAlumnos, que es la variable privada que corresponde a la variable publica.
            }
        }

        public string Path 
        {
            get 
            {
                return @"C:\Users\casa\Documents\GitHub\MvcWebAPIEjercicio\MvcWebAPIEjercicio\App_Data\AlumnosApp\DataBase.xml";
            }
        }

        public List<T> Alumnos 
        {
            get 
            {
                return mAlumnos;
            }
        }

        public IEnumerable<T> Get()//este metodo cumple con el contrato de la interface. IEnumerable<T> Get();
        {
            return Alumnos;
        }

        public T Get(int id)// T Get(int id);
        {
            return Alumnos.FirstOrDefault(a => a.id == id);
        }

        public void Save(T model)//  cumple con la interface void Save(T model);
        {
            T item = Get(model.id);//consigue de la lista de Alumnos el alumno y lo guanda en item. la lista ya esta cargada gracias al metodo Load.
            if (item != null)
            {
                item.nombre = model.nombre;
                item.promedio = model.promedio;
                item.grado = model.grado;
            }
            else 
            {
                model.id = Alumnos.Count + 1;//le asiga al parametro model recibido, un id.
                Alumnos.Add(model);//lo agreega a la lista de alumnos.
            }
            SaveToFile();//se manda SERIALIZAR lo que hay en mAlumnos, que es la variable privada que corresponde a la variable publica.
        }

        public void Delete(int id)
        {
            T item = Get(id);//consigue de la lista de Alumnos el alumno y lo guanda en item. la lista ya esta cargada gracias al metodo Load.
            if (item != null)
            {
                Alumnos.Remove(item);
            }
            SaveToFile();//se manda SERIALIZAR lo que hay en mAlumnos, que es la variable privada que corresponde a la variable publica.
        }

        public void CleanDataBase() 
        {
            Alumnos.Clear();
            SaveToFile();
        }
    }
}