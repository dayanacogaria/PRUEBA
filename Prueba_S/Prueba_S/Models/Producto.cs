using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_S.Models
{
    public class Producto
    {
        [MaxLength(20)]
        [Key]
        [DisplayName("Codigo Producto")]
        public string CodProducto { get; set; }
        [MaxLength(100)]
        [DisplayName("Nombre Producto")]
        public string NomProducto { get; set; }
        public bool Activo { get; set; }
        public ICollection<Venta> ventas { get; set; }
    }
}
