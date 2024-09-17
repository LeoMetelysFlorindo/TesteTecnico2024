using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace SUMUP.API.Models
{
    [Table("categoria")]
    public class categoria
    {       

        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
