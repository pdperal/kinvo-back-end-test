using Domain.Entities.Base;

namespace Domain.Entities
{
    public class Resgate : Movimentacao
    {
        public Resgate(Guid id, Guid idProduto, decimal valorResgate, DateTime dataResgate)
            : base(id, idProduto, dataResgate, valorResgate, Enum.TipoMovimentacaoEnum.Resgate)
        {
            IdProduto = idProduto;
        }
    }
}
