using Domain.Entities;
using MediatR;

namespace Application.Commands.Produtos
{
    public class NovoProdutoCommand : IRequest<Guid>
    {
        public string Nome { get; set; }
        public decimal RendimentoMensal { get; set; }

        public NovoProdutoCommand(string nome, decimal rendimentoMensal)
        {
            Nome = nome;
            RendimentoMensal = rendimentoMensal;
        }

        public Produto ToEntidate()
        {
            return new Produto(Nome, RendimentoMensal);
        }
    }
}
