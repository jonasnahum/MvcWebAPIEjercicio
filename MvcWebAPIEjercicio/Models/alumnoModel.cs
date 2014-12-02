using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebAPIEjercicio.Models
{
    public interface IAlumnoModel
    {
        int id { get; set; }
        string nombre { get; set; }
        decimal promedio { get; set; }
        string grado { get; set; }
    }

    public class alumnoModel : IAlumnoModel
    {
        public alumnoModel() { }
        public int id { get; set; }
        public string nombre { get; set; }
        public decimal promedio { get; set; }
        public string grado { get; set; }
    }
}