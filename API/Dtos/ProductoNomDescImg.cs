using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ProductoNomDescImg
    {
        public string Nombre { get; set; }
        public string Img { get; set; }
        #nullable enable
        public string? Descripcion { get; set; }

    }
}