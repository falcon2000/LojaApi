using System;
using LojaApi.Data;
using LojaApi.Entities;
using LojaApi.Repositories.Interfaces;
using LojaApi.Services.Interfaces;

namespace LojaApi.Repositories;

public class ProdutoDBRepository : IProdutoRepository
{
    private readonly LojaContext _context;

    public ProdutoDBRepository(LojaContext context)
    {
        _context = context;
    }

    public List<Produto> ObterTodos()
    {
        return _context.Produtos.ToList();
    }

    public Produto? ObterPorId(int id)
    {
        return _context.Produtos.FirstOrDefault(c => c.Id == id);
    }

    public Produto Adicionar(Produto novoProduto)
    {
        novoProduto.Ativo = true;
        _context.Add(novoProduto);
        _context.SaveChanges();
        return novoProduto;
    }

    public Produto? Atualizar(int id, Produto produtoAtualizado)
    {
        _context.Update(produtoAtualizado);
        _context.SaveChanges();

        return produtoAtualizado;
    }

    public bool Remover(int id)
    {
        var produtoRemover = ObterPorId(id);

        if (produtoRemover == null) return false;

        _context.Remove(produtoRemover);
        _context.SaveChanges();
        return true;

    }


}
