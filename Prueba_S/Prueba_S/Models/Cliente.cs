using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_S.Models
{
    public class Cliente
    {
        [MaxLength(10)]
        [Key]
        [DisplayName("Codigo Cliente")]
        public string CodCliente { get; set; }
        [MaxLength(100)]
        [DisplayName("Nombre Cliente")]
        public string NomCliente { get; set; }
        [MaxLength(60)]
        public string Ciudad { get; set; }
       
    }
}
