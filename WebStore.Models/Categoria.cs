using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStoreMODEL.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Este campo es obligatorio")]
        public string Nombre { get; set; }    
        public int? Orden { get; set; }
     
       
    }
}
