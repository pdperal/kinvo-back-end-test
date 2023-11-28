using Domain.Repositories;
using Infra.Persistence;
using Infra.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra
{
    public static class Extensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection collection)
        {
            collection.AddScoped<IProdutoRepository, ProdutoRepository>();
            collection.AddScoped<IMovimentacaoRepository, MovimentacaoRepository>();

            return collection;
        }

        public static IServiceCollection AddConnectionString(this IServiceCollection collection)
        {
            collection.AddSingleton(x =>
            {
                var config = x.GetService<IConfiguration>();
                var connection = new ConnectionString();
                config.GetSection("ConnectionStrings").Bind(connection);

                return connection;
            });

            return collection;
        }
    }
}
