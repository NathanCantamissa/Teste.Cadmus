using AutoMapper;
using Domain.Models;
using Infra.CrossCutting.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cliente, CadastroClienteDto>().ReverseMap();
            CreateMap<Produto, CadastroProdutoDto>().ReverseMap();
            CreateMap<Pedido, CadastroPedidoDto>().ReverseMap();
        }
    }
}