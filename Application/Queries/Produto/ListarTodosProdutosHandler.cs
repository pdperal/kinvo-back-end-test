using Application.ViewModels;
using Domain.Repositories;
using MediatR;

namespace Application.Queries.Produto
{
    public class ListarTodosProdutosHandler : IRequestHandler<ListarTodosProdutosQuery, List<ProdutoViewModel>>
    {
        private readonly IProdutoRepository _produtoRepository;

        public ListarTodosProdutosHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public async Task<List<ProdutoViewModel>> Handle(ListarTodosProdutosQuery request, CancellationToken cancellationToken)
        {
            var products = await _produtoRepository.BuscarTodosProdutosAsync();

            return products
                .Select(x => ProdutoViewModel.FromEntidade(x))
                .ToList();
        }
    }
}
