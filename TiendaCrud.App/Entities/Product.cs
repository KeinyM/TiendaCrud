using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaCrud.App.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public decimal Precio { get; set; }

        public int Cantidad { get; set; }
    }
}
