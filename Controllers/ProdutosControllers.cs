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
            // 200 OK - Sucesso 
            return Ok(produtos);  
        } 

        // Endpoint: GET api/Produtos/{id} 
        // O {id} é um parâmetro de rota 
        [HttpGet("{id:int}")]  
        public ActionResult<Produto> GetById(int id) 
        { 
            var produto = ProdutoRepository.GetById(id); 
 
            if (produto == null) 
            { 
                // 404 Not Found - Recurso não encontrado 
                return NotFound(); 
            } 
 
            // 200 OK - Sucesso 
            return Ok(produto);  
        }
    } 
} 