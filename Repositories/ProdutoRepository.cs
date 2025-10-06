using LojaApi.Entities;

namespace LojaApi.Repositories
{
    public static class ProdutoRepository
    {
        private static List<Produto> _produtos = new List<Produto>
        {
            new Produto { Id = 1, Descricao = "Teclado USB ABNT2 com fio", Valor = 108.80m, Estoque = 80m },
            new Produto { Id = 2, Descricao = "Mouse USB com fio", Valor = 60.05m, Estoque = 100m },
            new Produto { Id = 3, Descricao = "Kit Teclado ABNT2 e mouse sem fio", Valor = 200.50m, Estoque = 120m },
        };

        private static int _nextId = 4;

        public static List<Produto> GetAll()
        {
            return _produtos;
        }

        public static Produto? GetById(int id)
        {
            return _produtos.FirstOrDefault(c => c.Id == id);
        }

        public static Produto Add(Produto novoProduto)
        {
            novoProduto.Id = _nextId++;
            _produtos.Add(novoProduto);
            return novoProduto;
        }

        public static Produto? Update(int id, Produto produtoAtualizado)
        {
            var produtoExistente = _produtos.FirstOrDefault(c => c.Id == id);

            if (produtoExistente == null)
            {
                return null;
            }

            produtoExistente.Descricao = produtoAtualizado.Descricao;
            produtoExistente.Valor = produtoAtualizado.Valor;
            produtoExistente.Estoque = produtoAtualizado.Estoque;

            return produtoExistente;
        }

        public static bool Delete(int id)
        {
            var produtoParaDeletar = _produtos.FirstOrDefault(c => c.Id == id);

            if (produtoParaDeletar == null)
            {
                return false;
            }

            _produtos.Remove(produtoParaDeletar);
            return true;
        }        
    }
}        
