using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_S.Models
{
    public class MasterDetailViewModel
    {

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int id { get; set; }


        public IEnumerable<Venta> Ventas { get; set; }
        public IEnumerable<Producto> Productos { get; set; }
       

       
 
       


    }
}
