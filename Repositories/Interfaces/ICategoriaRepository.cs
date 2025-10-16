using System;
using LojaApi.Entities;

public interface ICategoriaRepository
{
    List<Categoria> ObterTodos();
    Categoria? ObterPorId(int id);
    Categoria Adicionar(Categoria novaCategoria);
    Categoria? Atualizar(int id, Categoria categoriaAtualizada);
    bool Remover(int id); 
}
