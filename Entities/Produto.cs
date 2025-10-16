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
    [Required(ErrorMessage = "O nome do produto é obrigatório")]
    [StringLength(150, MinimumLength = 3, ErrorMessage = "O nome do produto deve ter entre 3 e 150 caracteres")]
    public string Descricao { get; set; } = string.Empty;
    [Column("valor")]
    [Required(ErrorMessage = "O valor é obrigatório")]
    [Range(0.1, 100000.00, ErrorMessage = "O valor deve ser entre 0 e 100,000.00")]
    public decimal Valor { get; set; }
    [Column("estoque")]
    [Required(ErrorMessage = "O estoque deve ser informado")]
    [Range(0, 1000.00, ErrorMessage = "O estoque deve ser entre 0 e 1,000.00")]
    public decimal Estoque { get; set; }
    [Column("ativo")]
    [Required(ErrorMessage = "Obrigatório informar se está ativo ou inativo")]
    public bool Ativo { get; set; }
    [Column("id_categoria")]
    [Required(ErrorMessage = "O ID da categoria é obrigatório")]
    public int CategoriaId { get; set; }

    [ForeignKey("CategoriaId")]
    
    public Categoria? Categoria { get; set; }

  }
}
