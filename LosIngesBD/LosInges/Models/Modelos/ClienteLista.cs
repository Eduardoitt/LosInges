using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace LosInges.Models
{
    public class ClienteLista
    {
      public int  IdCliente {get;set;}
      public string    Nombre { get; set; }
        public string ApPat { get; set; }
        public string ApMat { get; set; }
        public string Telefono { get; set; }
        public string  Correo { get; set; }
        public int IdTipoCliente { get; set; }
    }
}