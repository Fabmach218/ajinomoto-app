using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ajinomoto_app.Models
{
    [Table("t_pedido")]
    public class Pedido
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        public String UserID { get; set; }
        public Decimal Total { get; set; } 
        public Pago Pago { get; set; }
        
    }
}