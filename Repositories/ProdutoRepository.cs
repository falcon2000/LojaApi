using LojaApi.Entities;

namespace LojaApi.Repositories
{
    public static class ProdutoRepository
    {
        private static List<Produto> _produtos = new List<Produto>
        {
            new Produto { Id = 1, Descricao = "Produto teste 01", Valor = 10, Saldo = 20 },
            new Produto { Id = 2, Descricao = "Produto teste 02", Valor = 150, Saldo = 100 },
            new Produto { Id = 3, Descricao = "Produto teste 03", Valor = 1000, Saldo = 120 },
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
    }
}        
