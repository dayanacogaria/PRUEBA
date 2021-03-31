using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_S.Models
{
    public class Venta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public DateTime fecha { get; set; }
       
        [DisplayName("Valor Unitario")]
        public decimal ValorUnitario { get; set; }
        [DisplayName("Valor Total")]
        public decimal ValorTotal { get; set; }
        public decimal Cantidad { get; set; }
   
        public Producto Producto { get; set; }
      public Cliente Cliente { get; set; }
    }
}
