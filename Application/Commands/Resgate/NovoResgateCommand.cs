using Domain.Entities;
using MediatR;

namespace Application.Commands.Resgates
{
    public class NovoResgateCommand : IRequest<Guid>
    {
        public Guid Id { get; private set; }
        public Guid IdProduto { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataResgate { get; set; }

        public NovoResgateCommand(Guid idProduto, decimal valor, DateTime dataResgate)
        {
            Id = Guid.NewGuid();
            IdProduto = idProduto;
            Valor = valor;
            DataResgate = dataResgate;
        }

        public Resgate ToEntidade()
        {
            return new Resgate(Id, IdProduto, Valor, DataResgate);
        }
    }
}
