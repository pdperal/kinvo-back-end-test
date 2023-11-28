using Domain.Entities.Base;

namespace Domain.Entities
{
    public class Produto : IEntidadeBase
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal PercentualRendimentoMensal { get; set; }

        public Produto()
        {

        }
        public Produto(string nome, decimal rendimentoMensal)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            PercentualRendimentoMensal = rendimentoMensal;
        }
    }
}
