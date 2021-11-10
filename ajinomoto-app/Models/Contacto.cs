using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ajinomoto_app.Models
{
    [Table("t_contacto")]
    public class Contacto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id {get; set;}
        [Column("Nombre")]
        public string Nombre {get; set;}
        [Column("Correo")]
        public string Correo {get; set;}
        [Column("Pais")]
        public string Pais {get; set;}
        [Column("Comentario")]
        public string Comentario {get; set;}
    }
}