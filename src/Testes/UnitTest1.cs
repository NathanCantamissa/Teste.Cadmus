using Application.Services;
using Domain.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Testes
{
    public class Tests
    {
        private readonly IProdutoService _produtoService;
        private readonly IClienteService _clienteService;
        private readonly IPedidoService _pedidoService;

        public Tests()
        {
            var services = new ServiceCollection();

            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IPedidoService, PedidoService>();

            var serviceProvider = services.BuildServiceProvider();
            _produtoService = serviceProvider.GetService<IProdutoService>();
            _clienteService = serviceProvider.GetService<IClienteService>();
            _pedidoService = serviceProvider.GetService<IPedidoService>();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CadastrarProduto()
        {
            _produtoService.Cadastrar(new Infra.CrossCutting.Dto.CadastroProdutoDto
            {
                Valor = 950,
                Descricao = "Lalala"
            }, new FormFile { Name });
        }

        [Test]
        public void CadastrarPedido()
        {
            Assert.Pass();
        }

        [Test]
        public void CadastrarCliente()
        {
            Assert.Pass();
        }
    }
}