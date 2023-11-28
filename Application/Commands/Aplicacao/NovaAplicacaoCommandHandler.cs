using Domain.Repositories;
using MediatR;

namespace Application.Commands.Aplicacoes
{
    public class NovaAplicacaoCommandHandler : IRequestHandler<NovaAplicacaoCommand, Guid>
    {
        private readonly IMovimentacaoRepository _bancoRepository;

        public NovaAplicacaoCommandHandler(IMovimentacaoRepository bancoRepository)
        {
            _bancoRepository = bancoRepository;
        }
        public async Task<Guid> Handle(NovaAplicacaoCommand request, CancellationToken cancellationToken)
        {
            var entidade = request.ToEntidade();

            await _bancoRepository.InserirAplicacaoAsync(entidade);

            return entidade.Id;
        }
    }
}
