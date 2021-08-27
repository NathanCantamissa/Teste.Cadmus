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
    public class PedidoService : BaseService, IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;
        private readonly INotificador _notificador;
        private readonly IUnitOfWork _uow;
        private readonly IProdutoService _produtoService;

        public PedidoService(IPedidoRepository pedidoRepository,
            IMapper mapper,
            INotificador notificador,
            IUnitOfWork uow) : base(notificador)
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
            _notificador = notificador;
            _uow = uow;
        }

        public async Task Cadastrar(CadastroPedidoDto dados)
        {
            Pedido novoPedido = _mapper.Map<Pedido>(dados);

            novoPedido.Produtos = _mapper.Map<List<Produto>>(_produtoService.BuscarProdutosPorId(dados.ProdutoId));
            novoPedido.Cliente = new Cliente();
            novoPedido.PopularPropriedades();

            if (!ExecutarValidacao(new PedidoValidation(), novoPedido))
                return;

            await _pedidoRepository.Adicionar(novoPedido);

            _uow.Commit();
        }
    }
}