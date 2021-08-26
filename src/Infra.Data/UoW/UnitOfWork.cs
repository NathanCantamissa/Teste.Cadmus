using Domain.Interfaces.Notification;
using Domain.Interfaces.UoW;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly INotificador _notificador;
        private readonly ContextoEntity _context;
        private IDbContextTransaction _transaction;

        public UnitOfWork(INotificador notificador, ContextoEntity context)
        {
            _notificador = notificador;
            _context = context;
        }

        public async void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransactionAsync().Result;
        }

        public bool Commit()
        {
            if (_context == null)
                throw new ArgumentException("");

            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                _notificador.Notificar(e.ToString());
                return false;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
        }
    }
}