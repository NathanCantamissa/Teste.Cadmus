using Domain.Interfaces.Notification;
using Domain.Interfaces.UoW;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

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

        public bool Commit()
        {
            if (_context == null)
            {
                _notificador.Notificar("Não foi possível realizar a operação");
                return false;
            }

            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                _notificador.Notificar(e.InnerException.Message);
                return false;
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}