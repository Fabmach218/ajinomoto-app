using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ajinomoto_app.Models
{
    public class Producto
    {
        [Table("t_producto")]
        public class Producto
        {
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Column("id")]
            public int Id { get; set; }
            [Column("Nombre")]
            public string Nombre { get; set; }
            [Column("descripcion")]
            public string Descripcion { get; set; }
            [Column("precio")]
            public Decimal Precio { get; set; }
            [Column("imagen")]
            public string Imagen { get; set; }            
        }
    }
}