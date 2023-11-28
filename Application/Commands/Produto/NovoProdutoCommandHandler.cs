using Domain.Repositories;
using MediatR;

namespace Application.Commands.Produtos
{
    public class NovoProdutoCommandHandler : IRequestHandler<NovoProdutoCommand, Guid>
    {
        private readonly IProdutoRepository _produtoRepository;

        public NovoProdutoCommandHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public async Task<Guid> Handle(NovoProdutoCommand request, CancellationToken cancellationToken)
        {
            var entidade = request.ToEntidate();

            await _produtoRepository.InserirProdutoAsync(entidade);

            return entidade.Id;
        }
    }
}
