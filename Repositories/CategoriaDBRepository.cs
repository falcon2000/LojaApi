using System;
using LojaApi.Data;
using LojaApi.Entities;
using LojaApi.Repositories.Interfaces;

namespace LojaApi.Repositories;

public class CategoriaDBRepository : ICategoriaRepository
{
    private readonly LojaContext _context;

    public CategoriaDBRepository(LojaContext context)
    {
        _context = context;
    }

    public List<Categoria> ObterTodos()
    {
        return _context.Categorias.ToList();
    }

    public Categoria? ObterPorId(int id)
    {
        return _context.Categorias.FirstOrDefault(c => c.Id == id);
    }

    public Categoria Adicionar(Categoria novaCategoria)
    {
        novaCategoria.Ativo = true;
        _context.Add(novaCategoria);
        _context.SaveChanges();

        return novaCategoria;
    }

    public Categoria? Atualizar(int id, Categoria categoriaAtualizada)
    {
        _context.Update(categoriaAtualizada);
        _context.SaveChanges();

        return categoriaAtualizada;
    }

    public bool Remover(int id)
    {
        var categoriaRemover = _context.Categorias.FirstOrDefault(c => c.Id == id);

        if (categoriaRemover == null) return false;

        _context.Remove(categoriaRemover);
        _context.SaveChanges();
        return true;
    }
}
