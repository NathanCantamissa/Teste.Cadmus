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

        public void Commit()
        {
            if (_context == null)
                _notificador.Notificar("Não foi possível realizar a operação");

            if (!_notificador.TemNotificacao())
            {
                try
                {
                    _context.SaveChanges();
                }
                catch (Exception e)
                {
                    _notificador.Notificar(e.InnerException.Message);
                }
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}