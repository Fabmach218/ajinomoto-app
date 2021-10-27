using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ajinomoto_app.Models
{
    [Table("t_proforma")]
    public class Proforma
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        public String UserID {get; set;}
        public Producto Producto {get; set;}
        public int Quantity{get; set;}
        public Decimal Price { get; set; }
        public string Status { get; set; } = "Pendiente";
        
    }
}