using Application.ViewModels;
using MediatR;

namespace Application.Queries.Movimentacao
{
    public class ListarMovimentacoesPorProdutoQuery : IRequest<List<MovimentacaoViewModel>>
    {
        public Guid IdProduto { get; set; }

        public ListarMovimentacoesPorProdutoQuery(Guid idProduto)
        {
            IdProduto = idProduto;
        }
    }
}
