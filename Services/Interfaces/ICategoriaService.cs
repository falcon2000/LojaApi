using System;
using LojaApi.Entities;

namespace LojaApi.Services.Interfaces;

public interface ICategoriaService
{
    List<Categoria> ObterTodos();
    Categoria? ObterPorId(int id);
    Categoria Adicionar(Categoria novaCategoria);
    Categoria? Atualizar(int id, Categoria CategoriaAtualizada);
    bool Remover(int id); 
}
