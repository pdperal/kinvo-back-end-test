using Application.ViewModels;
using MediatR;

namespace Application.Queries.Produto
{
    public class ListarTodosProdutosQuery : IRequest<List<ProdutoViewModel>>
    {

    }
}
