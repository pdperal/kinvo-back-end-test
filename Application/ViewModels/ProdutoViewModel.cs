using Domain.Entities;

namespace Application.ViewModels
{
    public class ProdutoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal RendimentoMensal { get; set; }

        public ProdutoViewModel(Guid id, string nome, decimal rendimentoMensal)
        {
            Id = id;
            Nome = nome;
            RendimentoMensal = rendimentoMensal;
        }

        public static ProdutoViewModel FromEntidade(Produto produto)
        {
            return new ProdutoViewModel(produto.Id, produto.Nome, produto.PercentualRendimentoMensal);
        }
    }
}
