using Domain.Entities;
using Domain.Repositories;
using Npgsql;

namespace Infra.Persistence.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly string _connectionstring;

        public ProdutoRepository(ConnectionString connectionString)
        {
            _connectionstring = connectionString.Database;
        }

        public async Task<List<Produto>> BuscarTodosProdutosAsync()
        {
            List<Produto> result = new();

            try
            {
                using var dataSource = NpgsqlDataSource.Create(_connectionstring);

                var cmd = dataSource.CreateCommand("select p.id, p.nome, p.rendimento_mensal from public.produto p");

                using var reader = await cmd.ExecuteReaderAsync();

                while (reader.Read())
                {
                    result.Add(new Produto
                    {
                        Id = Guid.Parse(reader.GetString(0)),
                        Nome = reader.GetString(1),
                        PercentualRendimentoMensal = reader.GetDecimal(2)
                    });
                }

            }
            catch
            {
                throw;
            }

            return result;
        }

        public async Task InserirProdutoAsync(Produto produto)
        {
            try
            {
                using var dataSource = NpgsqlDataSource.Create(_connectionstring);

                var conn = await dataSource.OpenConnectionAsync();

                var cmd = new NpgsqlCommand("insert into public.produto (id, nome, rendimento_mensal) values (@p1, @p2, @p3)", conn)
                {
                    Parameters =
                    {
                        new("p1", produto.Id),
                        new("p2", produto.Nome),
                        new("p3", produto.PercentualRendimentoMensal),
                    }
                };

                await cmd.ExecuteNonQueryAsync();
            }
            catch
            {
                throw;
            }

        }
    }
}
