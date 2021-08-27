using Application.Validations;
using AutoMapper;
using Domain.Interfaces.Notification;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using Domain.Interfaces.UoW;
using Domain.Models;
using Infra.CrossCutting.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProdutoService : BaseService, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;
        private readonly INotificador _notificador;
        private readonly IUnitOfWork _uow;

        public ProdutoService(IProdutoRepository produtoRepository,
            IMapper mapper,
            INotificador notificador,
            IUnitOfWork uow) : base(notificador)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
            _notificador = notificador;
            _uow = uow;
        }

        public async Task<List<ProdutoDto>> BuscarProdutosPorId(List<Guid> ids)
        {
            return _mapper.Map<List<ProdutoDto>>(await _produtoRepository.BuscarProdutosPorIds(ids));
        }

        public async Task Cadastrar(CadastroProdutoDto dados, IFormFile foto)
        {
            Produto novoProduto = _mapper.Map<Produto>(dados);
            if (foto != null)
            {
                if (foto.Length > 0)
                    UploadArquivo(novoProduto, foto);
            }

            if (!ExecutarValidacao(new ProdutoValidation(), novoProduto))
                return;

            await _produtoRepository.Adicionar(novoProduto);

            _uow.Commit();
        }

        private Produto UploadArquivo(Produto novoProduto, IFormFile arquivo)
        {
            string imgNome = $"{novoProduto.Id} - {novoProduto.Descricao}.jpg";
            byte[] x = new byte[] { };
            using (var memoryStream = new MemoryStream())
            {
                arquivo.CopyToAsync(memoryStream);
                x = memoryStream.ToArray();
            }
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", imgNome);

            if (System.IO.File.Exists(filePath))
            {
                Notificar("Já existe um arquivo com este nome!");
            }

            System.IO.File.WriteAllBytes(filePath, x);

            novoProduto.Foto = imgNome;

            return novoProduto;
        }
    }
}