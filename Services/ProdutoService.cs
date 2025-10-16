using System;
using LojaApi.Entities;
using LojaApi.Services.Interfaces;

namespace LojaApi.Services
{
  public class ProdutoService : IProdutoService
  {
    private readonly IProdutoRepository _produtoRepository;
    private readonly ICategoriaRepository _categoriaRepository;

    public ProdutoService(
        IProdutoRepository produtoRepository,
        ICategoriaRepository categoriaRepository)
    {
      _produtoRepository = produtoRepository;
      _categoriaRepository = categoriaRepository;
    }

    public List<Produto> ObterTodos()
    {
      return _produtoRepository.ObterTodos().Where(p => p.Estoque > 0).ToList();
    }

    public Produto? ObterPorId(int id)
    {
      return _produtoRepository.ObterPorId(id);
    }

    public Produto Adicionar(Produto novoProduto)
    {
      var categoria = _produtoRepository.ObterPorId(novoProduto.CategoriaId);
      if (categoria == null)
      {
          throw new Exception("A categoria informada não existe.");
      }

      return _produtoRepository.Adicionar(novoProduto);
    }

    public Produto? Atualizar(int id, Produto produtoAtualizado)
    {
      //if (id != produtoAtualizado.Id) return null;
      var produto = _produtoRepository.ObterPorId(id);
      if (produto == null)
      {
        throw new Exception("O produto informado não existe");
      }    
      return _produtoRepository.Atualizar(id, produtoAtualizado);
    }

    public bool Remover(int id)
    {
      var produto = _produtoRepository.ObterPorId(id);
      if (produto == null)
      {
        throw new Exception("O produto informado não existe");
      }    
      produto.Ativo = false;
      return _produtoRepository.Atualizar(id, produto) != null;
    }
  }
}
