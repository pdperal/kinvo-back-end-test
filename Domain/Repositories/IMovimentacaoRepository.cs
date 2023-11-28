using Domain.Entities;

namespace Domain.Repositories
{
    public interface IMovimentacaoRepository
    {
        public Task InserirAplicacaoAsync(Aplicacao aplicacao);
        public Task<List<Movimentacao>> BuscarMovimentacoesPorProdutoAsync(Guid id);
        public Task<List<Aplicacao>> BuscarAplicacoesPorProdutoAsync(Guid id);
    }
}
