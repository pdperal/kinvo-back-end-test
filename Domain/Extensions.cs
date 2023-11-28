namespace Domain
{
    public static class Extensions
    {
        public static int CalcularMesesEntreDatas(this DateTime dataInicial, DateTime dataFinal)
        {
            return (dataFinal.Year - dataInicial.Year) * 12 + dataFinal.Month - dataInicial.Month;
        }
    }
}
