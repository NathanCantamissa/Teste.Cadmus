using Domain.Interfaces.Repository;
using Domain.Models;
using Infra.Data.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infra.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly ContextoEntity Db;
        protected readonly DbSet<TEntity> DbSet;

        protected BaseRepository(ContextoEntity db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
        }

        public virtual async Task Remover(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
        }

        public void Dispose()
        {
            Db?.Dispose();
        }

        public List<SqlParameter> ListaDeParametros<T>(List<T> lista, out string[] parameters)
        {
            parameters = new string[lista.Count];
            var sqlParameters = new List<SqlParameter>();
            for (var i = 0; i < lista.Count; i++)
            {
                parameters[i] = string.Format("@p{0}", i);
                sqlParameters.Add(new SqlParameter(parameters[i], lista[i]));
            }
            return sqlParameters;
        }
    }
}