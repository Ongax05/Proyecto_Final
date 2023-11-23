using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Gama_Producto : StringBaseEntity
    {
        #nullable enable
        public string? Descripcion_Texto { get; set; }
        public string? Descripcion_HTML { get; set; }
        public string? Imagen { get; set; }
        #nullable disable
        public ICollection<Producto> Productos { get; set; }
    }
}