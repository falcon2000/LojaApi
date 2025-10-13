using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaApi.Entities
{
    [Table("TB_CATEGORIAS")]
    public class Categoria
    {
        [Key]
        [Column("id_categoria")]
        public int Id { get; set; }
        [Column("descricao")]
        [Required]
        [StringLength(100)]
        public string Descricao { get; set; } = string.Empty;
        [Column("ativo")]
        public bool Ativo { get; set; }
    }
}
