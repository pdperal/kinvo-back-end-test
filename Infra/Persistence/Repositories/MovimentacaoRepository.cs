﻿using Domain.Entities;
using Domain.Entities.Base;
using Domain.Enum;
using Domain.Repositories;
using Npgsql;
using System.Drawing;

namespace Infra.Persistence.Repositories
{
    public class MovimentacaoRepository : IMovimentacaoRepository
    {
        private readonly string _connectionstring;

        public MovimentacaoRepository(ConnectionString connectionString)
        {
            _connectionstring = connectionString.Database;
        }

        public async Task InserirAplicacaoAsync(Aplicacao aplicacao)
        {
            using var dataSource = NpgsqlDataSource.Create(_connectionstring);

            var conn = await dataSource.OpenConnectionAsync();
            try
            {
                var cmd = new NpgsqlCommand("insert into public.aplicacao (id, id_produto, saldo_aplicacao, valor_aplicacao, data) " +
                    " values (@p1, @p2, @p3, @p4, p5)", conn)
                {
                    Parameters =
                    {
                        new("p1", aplicacao.Id),
                        new("p2", aplicacao.IdProduto),
                        new("p3", aplicacao.ValorMovimentacao),
                        new("p4", aplicacao.ValorMovimentacao),
                        new("p5", aplicacao.DataMovimentacao),
                    }
                };

                await cmd.ExecuteNonQueryAsync();
            }
            catch
            {
                throw;
            }
            finally
            {
                await conn.CloseAsync();
            }
        }

        public async Task<List<Movimentacao>> BuscarMovimentacoesPorProdutoAsync(Guid id)
        {
            List<Movimentacao> result = new();
            using var dataSource = NpgsqlDataSource.Create(_connectionstring);
            var conn = await dataSource.OpenConnectionAsync();

            try
            {
                var cmd = new NpgsqlCommand("select a.id, p.id, a.valor, a.data_aplicacao, a.tipo_movimentacao  " +
                    " from public.movimentacao a inner join public.produto p on a.id_produto = p.id " +
                    $"where p.id = '{id}'", conn);
                using var reader = await cmd.ExecuteReaderAsync();

                while (reader.Read())
                {
                    result.Add(new Movimentacao(                        
                        id: Guid.Parse(reader.GetString(0)),
                        idProduto: Guid.Parse(reader.GetString(1)),
                        dataMovimentacao: reader.GetDateTime(3),
                        valor: reader.GetDecimal(2),
                        tipoMovimentacao: reader.GetString(4) switch
                        {
                            "Aplicacao" => TipoMovimentacaoEnum.Aplicacao,
                            "Resgate" => TipoMovimentacaoEnum.Resgate,
                        }));
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                await conn.CloseAsync();
            }

            return result;
        }

        public async Task<List<Aplicacao>> BuscarAplicacoesPorProdutoAsync(Guid id)
        {
            List<Aplicacao> result = new();
            using var dataSource = NpgsqlDataSource.Create(_connectionstring);
            var conn = await dataSource.OpenConnectionAsync();

            try
            {
                var cmd = new NpgsqlCommand("select a.id, a.id_produto, a.saldo_aplicacao, a.valor_aplicacao, a.data " +
                    "from public.aplicacao a inner join public.produto p on a.id_produto = p.id " +
                    $"where p.id = '{id}' " +
                    "and a.saldo_aplicacao > 0", conn);
                using var reader = await cmd.ExecuteReaderAsync();

                while (reader.Read())
                {
                    result.Add(new Aplicacao(
                        id: Guid.Parse(reader.GetString(0)),
                        idProduto: Guid.Parse(reader.GetString(1)),
                        saldoAplicacao: reader.GetDecimal(2),
                        valorAplicacao: reader.GetDecimal(3),
                        dataAplicacao: reader.GetDateTime(4)
                        ));
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                await conn.CloseAsync();
            }

            return result;

        }
    }
}
