using AutoMapper;
using Domain.Interfaces.Notification;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using Domain.Interfaces.UoW;
using Domain.Models;
using Infra.CrossCutting.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        private readonly INotificador _notificador;
        private readonly IUnitOfWork _uow;

        public ClienteService(IClienteRepository clienteRepository,
            IMapper mapper,
            INotificador notificador,
            IUnitOfWork uow)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
            _notificador = notificador;
            _uow = uow;
        }

        public async void Cadastrar(CadastroClienteDto dados)
        {
            await _clienteRepository.Adicionar(_mapper.Map<Cliente>(dados));
            _uow.Commit();
        }
    }
}