using Domain.Entities.Base;

namespace Domain.Entities
{
    public class Aplicacao : Movimentacao
    {
        public decimal FaixaIR { get => CalcularFaixaIR(); }
        public decimal ValorImposto { get => CalcularValorImposto(); }
        public decimal RendimentoBruto { get => CalcularRendimentoBruto(); }
        public decimal PercentualRendimentoAnualProduto { get; set; }

        public Aplicacao(Guid id, Guid idProduto, decimal valor, DateTime dataAplicacao)
            : base(id, idProduto, dataAplicacao, valor, Enum.TipoMovimentacaoEnum.Aplicacao) 
        {

        }

        private decimal CalcularFaixaIR()
        {
            var periodoEmMeses = DataMovimentacao.CalcularMesesEntreDatas(DateTime.Now);

            return periodoEmMeses switch
            {
                < 12 => 0.225m,
                >= 12 and < 24 => 0.185m,
                >= 24 => 0.15m
            };
        }

        private decimal CalcularValorImposto()
        {
            var faixaIr = CalcularFaixaIR();

            var rendimento = CalcularRendimentoBruto();

            return rendimento / 100 * faixaIr;
        }
        private decimal CalcularRendimentoBruto()
        {
            decimal valor = ValorMovimentacao;
            var periodoEmMeses = DataMovimentacao.CalcularMesesEntreDatas(DateTime.Now);

            for (int i = 0; i < periodoEmMeses; i++)
            {
                valor =+ (valor * (PercentualRendimentoAnualProduto/12));
            }

            return valor;
        }
    }
}
