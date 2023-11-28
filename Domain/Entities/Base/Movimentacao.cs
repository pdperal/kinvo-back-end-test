using Domain.Enum;

namespace Domain.Entities.Base
{
    public class Movimentacao : IEntidadeBase
    {
        public Guid Id { get; private set; }
        public Guid IdProduto { get; set; }
        public DateTime DataMovimentacao { get; set; }
        public decimal ValorMovimentacao { get; set; }        
        public TipoMovimentacaoEnum TipoMovimentacao { get; set; }

        public Movimentacao(Guid id, Guid idProduto, DateTime dataMovimentacao, decimal valor, TipoMovimentacaoEnum tipoMovimentacao)
        {
            Id = id;
            IdProduto = idProduto;
            DataMovimentacao = dataMovimentacao;
            TipoMovimentacao = tipoMovimentacao;
            ValorMovimentacao = valor;
        }
    }
}
