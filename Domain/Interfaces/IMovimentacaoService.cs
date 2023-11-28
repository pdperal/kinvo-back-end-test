using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IMovimentacaoService
    {
        public Task<bool> RealizarResgate(Resgate resgate);
    }
}
