using Domain.Interfaces;
using MediatR;

namespace Application.Commands.Resgates
{
    public class NovoResgateCommandHandler : IRequestHandler<NovoResgateCommand, Guid>
    {
        private readonly IMovimentacaoService _movimentacaoService;

        public NovoResgateCommandHandler(IMovimentacaoService movimentacaoService)
        {
            _movimentacaoService = movimentacaoService;
        }
        public async Task<Guid> Handle(NovoResgateCommand request, CancellationToken cancellationToken)
        {
            await _movimentacaoService.RealizarResgate(request.ToEntidade());


            return Guid.NewGuid();
        }
    }
}
