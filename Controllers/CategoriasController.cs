using LojaApi.Entities;
using LojaApi.Services;
using LojaApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriasController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public ActionResult<List<Categoria>> GetAll()
        {
            return Ok(_categoriaService.ObterTodos());
        }

        [HttpGet("{id}")]
        public ActionResult<Categoria> GetById(int id)
        {
            var categoria = _categoriaService.ObterPorId(id);
            if (categoria == null) return NotFound();
            return Ok(categoria);
        }

        [HttpPost]
        public ActionResult<Categoria> Add(Categoria novaCategoria)
        {
            if (string.IsNullOrWhiteSpace(novaCategoria.Descricao))
            {
                return BadRequest("A descrição da categoria é obrigatória");
            }

            var categoriaCriada = _categoriaService.Adicionar(novaCategoria);
            return CreatedAtAction(nameof(GetById), new { id = categoriaCriada.Id }, categoriaCriada);
        }

        [HttpPut("{id}")]
        public ActionResult<Categoria> Update(int id, Categoria categoriaAtualizada)
        {
            if (string.IsNullOrWhiteSpace(categoriaAtualizada.Descricao))
            {
                return BadRequest("A descrição da categoria é obrigatória");
            }

            var categoria = _categoriaService.Atualizar(id, categoriaAtualizada);
            if (categoria == null) return NotFound();
            return Ok(categoria);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var sucesso = _categoriaService.Remover(id);
            if (!sucesso) return NotFound();
            return NoContent();            
        }
    }

}
