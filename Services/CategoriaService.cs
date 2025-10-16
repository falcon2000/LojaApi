using System;
using LojaApi.Entities;
using LojaApi.Services.Interfaces;

namespace LojaApi.Services
{
    public class CategoriaService : ICategoriaService
    {
        public readonly ICategoriaRepository _context;

        public CategoriaService(ICategoriaRepository context)
        {
            _context = context;
        }

        public List<Categoria> ObterTodos()
        {
            return _context.ObterTodos();
        }

        public Categoria? ObterPorId(int id)
        {
            return _context.ObterPorId(id);
        }

        public Categoria Adicionar(Categoria novaCategoria)
        {
            return _context.Adicionar(novaCategoria);
        }

        public Categoria? Atualizar(int id, Categoria categoriaAtualizada)
        {
            var categoria = _context.ObterPorId(id);
            if (categoria == null)
            {
                throw new Exception("A categoria informada para atualização não existe");
            }
            return _context.Atualizar(id, categoriaAtualizada);
        }

        public bool Remover(int id)
        {
            var categoria = _context.ObterPorId(id);
            if (categoria == null)
            {
                throw new Exception("A categoria informada não existe");
            }

            categoria.Ativo = false;
            return _context.Atualizar(id, categoria) != null;
        }
    }
}
