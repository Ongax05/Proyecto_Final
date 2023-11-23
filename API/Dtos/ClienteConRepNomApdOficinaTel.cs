using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ClienteConRepNomApdOficinaTel
    {
        public string Nombre_Cliente { get; set; }
        #nullable enable
        public string? Nombre_Representante { get; set; }
        public string? Apellido_Representante { get; set; }
        public string? Telefono_Oficina { get; set; }
    }
}