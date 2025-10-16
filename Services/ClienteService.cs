// Services/ClienteService.cs
using LojaApi.Entities;
using LojaApi.Services.Interfaces;

namespace LojaApi.Services
{
    public class ClienteService : IClienteService
    {
        public readonly IClienteRepository _context;

        // O Service agora recebe sua dependência (o contrato do repositório) via construtor.
        public ClienteService(IClienteRepository context)
        {
            _context = context;
        }

        // Os métodos agora usam a dependência injetada (_clienteRepository)
        public List<Cliente> ObterTodos()
        {
            // Regra: Não exibir clientes inativos.
            return _context.ObterTodos().Where(c => c.Ativo).ToList();
        }

        public Cliente? ObterPorId(int id)
        {
            return _context.ObterPorId(id);
        }

        public Cliente Adicionar(Cliente novoCliente)
        {
            novoCliente.Nome = novoCliente.Nome.ToUpper();
            novoCliente.Ativo = true;
            return _context.Adicionar(novoCliente);
        }

        public Cliente? Atualizar(int id, Cliente clienteAtualizado)
        {
            if (id != clienteAtualizado.Id) return null;
            return _context.Atualizar(id, clienteAtualizado);
        }

        public bool Remover(int id)
        {
            var cliente = _context.ObterPorId(id);
            if (cliente == null)
            {
                throw new Exception("A cliente informado para atualização não existe");
            }
            cliente.Ativo = false;
            return _context.Atualizar(id, cliente) != null;
        }
    }
}