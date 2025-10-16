using LojaApi.Entities;
using LojaApi.Services;
using LojaApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public ActionResult<List<Produto>> GetAll()
        {
            return Ok(_produtoService.ObterTodos());
        }

        [HttpGet("{id}")]
        public ActionResult<Produto> GetById(int id)
        {
            var produto = _produtoService.ObterPorId(id);
            if (produto == null) return NotFound();
            return Ok(produto);
        }

        [HttpPost]
        public ActionResult<Produto> Add(Produto novoProduto)
        {
            try
            {
                var produtoAdicionado = _produtoService.Adicionar(novoProduto);
                return CreatedAtAction(nameof(GetById), new { id = produtoAdicionado.Id }, produtoAdicionado);
            }
            catch (Exception ex)
            {
                // Retorna 400 Bad Request com a mensagem de erro de negócio. 
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Produto> Update(int id, Produto produtoAtualizado)
        {
            var produto = _produtoService.Atualizar(id, produtoAtualizado);
            if (produto == null) return NotFound();
            return Ok(produto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var sucesso = _produtoService.Remover(id);
            if (!sucesso) return NotFound();
            return NoContent();            
        }
    }

}
