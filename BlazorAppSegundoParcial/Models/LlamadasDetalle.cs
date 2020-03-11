using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlazorAppSegundoParcial.Models
{
    public class LlamadasDetalle
    {
        [Key]
        public int LlamadaDetalleId { get; set; }
        public int LlamadaId { get; set; }
        public string Problema { get; set; }
        public string solucion { get; set; }


        public LlamadasDetalle()
        {
            LlamadaDetalleId = 0;
            Problema = string.Empty;
            solucion = string.Empty;
        }

    }
}
