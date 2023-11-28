using Domain.Entities;

namespace Domain.Repositories
{
    public interface IProdutoRepository
    {
        public Task InserirProdutoAsync(Produto aplicacao);
        public Task<List<Produto>> BuscarTodosProdutosAsync();
    }
}
