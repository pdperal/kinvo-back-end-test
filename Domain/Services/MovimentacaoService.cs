using Domain.Entities;
using Domain.Interfaces;
using Domain.Repositories;

namespace Domain.Services
{
    public class MovimentacaoService : IMovimentacaoService
    {
        private readonly IMovimentacaoRepository _movimentacaoRepository;

        public MovimentacaoService(IMovimentacaoRepository movimentacaoRepository)
        {
            _movimentacaoRepository = movimentacaoRepository;
        }

        public async Task<bool> RealizarResgate(Resgate resgate)
        {
            try
            {
                var aplicacoes = await _movimentacaoRepository.BuscarAplicacoesPorProdutoAsync(resgate.IdProduto);

                if (!aplicacoes.Any())
                {
                    return false;
                }

                var movimentacoesOrdenadas = aplicacoes
                    .OrderBy(x => x.DataMovimentacao)
                    .ToList();

                if (resgate.DataMovimentacao < aplicacoes.First().DataMovimentacao)
                {
                    return false;
                }

                var valorResgate = resgate.ValorMovimentacao;

                foreach (var aplicacao in movimentacoesOrdenadas)
                {
                    if (aplicacao.ValorMovimentacao < valorResgate)
                    {

                    }
                }


                return true;

            }
            catch
            {
                throw;
            }
        }
    }
}
