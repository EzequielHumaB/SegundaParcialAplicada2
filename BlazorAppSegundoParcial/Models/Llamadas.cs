using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorAppSegundoParcial.Models
{
    public class Llamadas
    {
        [Key]
        [Range(0,10000000000000,ErrorMessage ="El Id no puede ser menor que cero")]
        [Required(ErrorMessage ="El Id debe ser un numero")]
        public int LlamadasId { get; set; }

        [Required(ErrorMessage ="La descripcion no puede estar vacia")]
        [MinLength(3,ErrorMessage ="Descripcion muy corta")]
        [MaxLength(60,ErrorMessage ="Descripcion muy larga")]
        public string Descripcion { get; set; }

        [ForeignKey("LlamadaId")]
        public virtual List<LlamadasDetalle> LlamadasDetalles { get; set; }

        public Llamadas()
        {
            LlamadasId = 0;
            Descripcion = string.Empty;
            LlamadasDetalles = new List<LlamadasDetalle>();
        }

    }
}
