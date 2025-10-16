using LojaApi.Entities;

public class ProdutoRepository : IProdutoRepository
{
    private readonly List<Produto> _produtos = new List<Produto>
    {
        new Produto { Id = 1, Descricao = "Teclado USB ABNT2 com fio", Valor = 102.10m, Estoque = 76m, Ativo = true },
        new Produto { Id = 2, Descricao = "Mouse USB com fio", Valor = 63.12m, Estoque = 100m, Ativo = true },
        new Produto { Id = 3, Descricao = "Kit Teclado ABNT2 e mouse sem fio", Valor = 212.50m, Estoque = 150m, Ativo = true }
    };

    private int _nextId = 4;

    public List<Produto> ObterTodos() => _produtos;

    public Produto? ObterPorId(int id) => _produtos.FirstOrDefault(p => p.Id == id);

    public Produto Adicionar(Produto novoProduto)
    {
        novoProduto.Id = _nextId++;
        _produtos.Add(novoProduto);
        return novoProduto;
    }

    public Produto? Atualizar(int id, Produto produtoAtualizado)
    {
        var produtoExistente = ObterPorId(id);
        if (produtoExistente == null) return null;

        produtoExistente.Descricao = produtoAtualizado.Descricao;
        produtoExistente.Valor = produtoAtualizado.Valor;
        produtoExistente.Estoque = produtoAtualizado.Estoque;
        produtoExistente.Ativo = produtoAtualizado.Ativo;
        return produtoExistente;
    }

    public bool Remover(int id)
    {
        var produtoRemover = ObterPorId(id);
        if (produtoRemover == null) return false;

        _produtos.Remove(produtoRemover);
        return true;
    }
}
