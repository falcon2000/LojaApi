using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaApi.Entities
{
	// A classe que representa o nosso recurso 
	[Table("TB_CLIENTES")]
	public class Cliente
	{
		[Key]
		[Column("id_cliente")]
		public int Id { get; set; }
		[Column("nome_cliente")]
		[Required(ErrorMessage = "O nome do cliente é obrigatório")]
		[StringLength(150, MinimumLength = 2, ErrorMessage = "O nome do cliente deve ter entre 2 e 150 caracteres")]    
		public string Nome { get; set; } = string.Empty;
		[Column("email_cliente")]
		[Required(ErrorMessage = "O e-mail do cliente é obrigatório")]
		[StringLength(150, MinimumLength = 3, ErrorMessage = "O e-mail do cliente deve ter entre 2 e 150 caracteres")]    
		[EmailAddress(ErrorMessage = "O formato do e-mail email está incorreto")]
		public string Email { get; set; } = string.Empty;
		[Column("ativo")]
		[Required(ErrorMessage = "Obrigatório informar se está ativo ou inativo")]
		public bool Ativo { get; set; }
		[Column("data_cadastro")]
		public DateTime DataCadastro { get; set; }
	}
}
