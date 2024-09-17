using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace SUMUP.API.Models
{

    [Table("produto")]
    public class Produto
    {
        /// <summary>
        /// Nome único do produto.
        /// </summary>    
        /// <returns>string value</returns> 
        [Key]
        public string Nome { get; set; }

        /// <summary>
        /// Descrição do produto.
        /// </summary>    
        /// <returns>string value</returns> 
        public string Descricao { get; set; }

        /// <summary>
        /// Preço do produto.
        /// </summary>    
        /// <returns>string value</returns> 
        public double Preco { get; set; }

        /// <summary>
        /// Data de Validade do produto.
        /// </summary>    
        /// <returns>string value</returns> 
        public DateTime Data_da_validade { get; set; }

        /// <summary>
        /// Imagem do produto.
        /// </summary>    
        /// <returns>string value</returns> 
        [NotMapped]
        public Blob Imagem { get; set; }

        /// <summary>
        /// Categoria do produto.
        /// </summary>    
        /// <returns>string value</returns> 
        [ForeignKey ("categoria"), Column(Order = 0)]
        public int Categoria { get; set; }

    }

}
