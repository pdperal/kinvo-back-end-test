using Domain.Entities.Base;

namespace Application.ViewModels
{
    public class MovimentacaoViewModel
    {
        public Guid Id { get; set; }
        public Guid IdProduto { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public string TipoMovimentacao { get; set; }

        public MovimentacaoViewModel(Guid id, Guid idProduto, decimal valor, DateTime data, string tipoMovimentacao)
        {
            Id = id;
            IdProduto = idProduto;
            Valor = valor;
            Data = data;
            TipoMovimentacao = tipoMovimentacao;
        }

        public static MovimentacaoViewModel FromEntidade(Movimentacao movimentacao)
        {
            return new MovimentacaoViewModel(movimentacao.Id, movimentacao.IdProduto, movimentacao.ValorMovimentacao, movimentacao.DataMovimentacao, nameof(movimentacao.TipoMovimentacao));
        }
    }
}
