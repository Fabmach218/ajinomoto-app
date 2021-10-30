    
    
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public string Id { get; set; }
        public int Id { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("phone")]
        public string Phone { get; set; }
        [Column("name")]
        public string Name {get; set;}
        public string Comment {get; set; }
        [Column("comment")]
        public string Comment {get; set; }     
        public DateTime BirthDate { get; set; }
        [Column("gender")]
        public string Gender { get; set; }

    }