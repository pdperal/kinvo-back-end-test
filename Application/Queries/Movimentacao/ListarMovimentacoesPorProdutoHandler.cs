using Application.ViewModels;
using Domain.Repositories;
using MediatR;

namespace Application.Queries.Movimentacao
{
    public class ListarMovimentacoesPorProdutoHandler : IRequestHandler<ListarMovimentacoesPorProdutoQuery, List<MovimentacaoViewModel>>
    {
        private readonly IMovimentacaoRepository _aplicacaoRepository;

        public ListarMovimentacoesPorProdutoHandler(IMovimentacaoRepository aplicacaoRepository)
        {
            _aplicacaoRepository = aplicacaoRepository;
        }
        public async Task<List<MovimentacaoViewModel>> Handle(ListarMovimentacoesPorProdutoQuery request, CancellationToken cancellationToken)
        {
            var products = await _aplicacaoRepository.BuscarMovimentacoesPorProdutoAsync(request.IdProduto);

            return products
                .Select(x => MovimentacaoViewModel.FromEntidade(x))
                .ToList();
        }
    }
}
