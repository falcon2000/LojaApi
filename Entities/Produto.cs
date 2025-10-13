using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaApi.Entities
{
    [Table("TB_PRODUTOS")]
    public class Produto
    {
        [Key]
        [Column("id_produto")]
        public int Id { get; set; }
        [Column("descricao")]
        [Required]
        [StringLength(150)]
        public string Descricao { get; set; } = string.Empty;
        [Column("valor")]
        public decimal Valor { get; set; }
        [Column("estoque")]
        public decimal Estoque { get; set; }
        [Column("ativo")]
        public bool Ativo { get; set; }
    }
}
