using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ClienteConRepNameYCiudad
    {
        public string Nombre_Cliente { get; set; }
        #nullable enable
        public string? Nombre_Representante { get; set; }
        public string? Ciudad_Representante { get; set; }
    }
}