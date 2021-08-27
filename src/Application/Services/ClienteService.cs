using Application.Validations;
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
    public class ClienteService : BaseService, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        private readonly INotificador _notificador;
        private readonly IUnitOfWork _uow;

        public ClienteService(IClienteRepository clienteRepository,
            IMapper mapper,
            INotificador notificador,
            IUnitOfWork uow) : base(notificador)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
            _notificador = notificador;
            _uow = uow;
        }

        public async Task Cadastrar(CadastroClienteDto dados)
        {
            if (!ExecutarValidacao(new ClienteValidation(), _mapper.Map<Cliente>(dados)))
                return;

            await _clienteRepository.Adicionar(_mapper.Map<Cliente>(dados));

            _uow.Commit();
        }

        public async Task<ClienteDto> Obter(Guid id)
        {
            return _mapper.Map<ClienteDto>(await _clienteRepository.ObterPorId(id));
        }
    }
}