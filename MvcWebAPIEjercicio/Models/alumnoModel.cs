using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebAPIEjercicio.Models
{
    public class alumnoModel
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public decimal promedio { get; set; }
        public string grado { get; set; }
    }
}