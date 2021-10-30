using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace ajinomoto_app.Models
{

    [Table("t_pago")]
    public class Pago
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        public DateTime FechaPago { get; set; }
        public String NombreTarjeta { get; set; }
        
        [NotMapped]
        public String NumeroTarjeta { get; set; }
        
        [NotMapped]
        public String DueDateYYMM { get; set; }
        
        [NotMapped]
        public String Cvv { get; set; }
        public Decimal MontoTotal{ get; set; }
        public String UserID{ get; set; }

    
}