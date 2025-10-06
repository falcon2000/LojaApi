using LojaApi.Entities; 
using LojaApi.Repositories; 
using Microsoft.AspNetCore.Mvc; 
 
namespace LojaApi.Controllers 
{
    [ApiController] // Indica que esta classe é um Controlador de API (sem Views) 
    [Route("api/[controller]")] // Define a rota base: 'api/Clientes' 
    public class ProdutosController : ControllerBase // Herda de ControllerBase (padrão para APIs) 
    {
        [HttpGet]
        public ActionResult<List<Produto>> GetAll()
        {
            var produtos = ProdutoRepository.GetAll();
            return Ok(produtos);
        }

        // Endpoint: GET api/Produtos/{id} 
        [HttpGet("{id:int}")]
        public ActionResult<Produto> GetById(int id)
        {
            var produto = ProdutoRepository.GetById(id);

            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }
        
        [HttpPost]  
        public ActionResult<Produto> Add(Produto novoProduto)  
        { 
            // Validações
            if (string.IsNullOrWhiteSpace(novoProduto.Descricao))
            {
                return BadRequest("A descrição do produto é obrigatória.");
            } 

            if (Decimal.IsNegative(novoProduto.Valor))
            {
                return BadRequest("O valor não pode ser negativo.");
            }

            if (Decimal.IsNegative(novoProduto.Estoque))
            {
                return BadRequest("O estoque não pode ser negativo.");
            }

            var produtoCriado = ProdutoRepository.Add(novoProduto); 
 
            // 201 Created - Novo recurso criado com sucesso 
            // Retorna o recurso criado e a URL para acessá-lo (boa prática REST) 
            return CreatedAtAction(nameof(GetById), new { id = produtoCriado.Id }, produtoCriado);  
        } 
 
        // ---------------------------------------------------- 
        // 3. PUT - Atualizar/Substituir Recurso (Completo) 
        // ---------------------------------------------------- 
         
        // Endpoint: PUT api/Produtos/{id} 
        [HttpPut("{id:int}")] 
        public ActionResult<Produto> Update(int id, Produto produtoAtualizado) 
        { 
            // Validação de entrada 
            if (string.IsNullOrWhiteSpace(produtoAtualizado.Descricao)) 
            { 
                 return BadRequest("A descrição do produto é obrigatória."); 
            } 
             
            var produto = ProdutoRepository.Update(id, produtoAtualizado); 
 
            if (produto == null) 
            { 
                // 404 Not Found - Tentou atualizar algo que não existe 
                return NotFound(); 
            } 
 
            // 200 OK - Sucesso (Recurso substituído) 
            return Ok(produto);  
        } 
 
        // ---------------------------------------------------- 
        // 4. DELETE - Excluir Recurso 
        // ---------------------------------------------------- 
         
        // Endpoint: DELETE api/Clientes/{id} 
        [HttpDelete("{id:int}")] 
        public IActionResult Delete(int id) // Usamos IActionResult pois não retornaremos um objeto Cliente 
        { 
            var sucesso = ProdutoRepository.Delete(id); 
 
            if (!sucesso) 
            { 
                // 404 Not Found - Tentou deletar algo que não existe 
                return NotFound(); 
            } 
 
            // 204 No Content - Sucesso, mas não há corpo de resposta (padrão REST para DELETE) 
            return NoContent();  
        } 
    } 
} 