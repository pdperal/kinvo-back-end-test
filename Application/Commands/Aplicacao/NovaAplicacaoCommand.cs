using Domain.Entities;
using MediatR;

namespace Application.Commands.Aplicacoes
{
    public class NovaAplicacaoCommand : IRequest<Guid>
    {
        public Guid Id { get; private set; }
        public Guid IdProduto { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataAplicacao { get; set; }

        public NovaAplicacaoCommand(Guid idProduto, decimal valor, DateTime dataAplicacao)
        {
            Id = Guid.NewGuid();
            IdProduto = idProduto;
            Valor = valor;
            DataAplicacao = dataAplicacao;
        }

        public Aplicacao ToEntidade()
        {
            return new Aplicacao(Id, IdProduto, Valor, DataAplicacao);
        }
    }
}
