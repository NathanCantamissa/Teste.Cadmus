using Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Notification
{
    public interface INotificador
    {
        bool TemNotificacao();

        List<string> ObterNotificacoes();

        void Notificar(string notificacao);
    }
}