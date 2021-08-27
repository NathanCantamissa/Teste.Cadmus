using Domain.Interfaces.Repository;
using Domain.Models;
using Infra.Data.Context;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ContextoEntity db) : base(db)
        {
        }

        public async Task<List<Produto>> BuscarProdutosPorIds(List<Guid> ids)
        {
            var sqlParamaters = ListaDeParametros(ids, out string[] parameters).ToArray();
            var sql = string.Format("SELECT * FROM SuaTabela WHERE Id IN ({0})", string.Join(", ", parameters));

            return await DbSet.FromSqlRaw(sql, sqlParamaters).ToListAsync();
        }
    }
}