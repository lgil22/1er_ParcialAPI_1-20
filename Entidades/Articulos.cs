using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _1er_ParcialAPI_1_20.Entidades
{
    public class Articulos
    {
        [Key]
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public decimal Existencia { get; set; }
        public decimal Costo { get; set; }
        public decimal ValorInventario { get; set; }

        public Articulos()
        {
            ProductoId = 0;
            Descripcion = string.Empty;
            Existencia = 0;
            Costo = 0;
            ValorInventario = 0;
        }

        public Articulos(int productoid, string descripcion, decimal existencia, decimal costo, decimal valornumerico)
        {
            ProductoId = productoid;
            Descripcion = descripcion;
            Existencia = existencia;
            Costo = costo;
            ValorInventario = valornumerico;
        }

    }
}