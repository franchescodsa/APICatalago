﻿using APICatalogo.Models;
using AutoMapper;

namespace APICatalogo.DTOs.Mappings
{
    public class MapeamentoDTOautoMapper : Profile
    {
        public MapeamentoDTOautoMapper()
        {
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            CreateMap<Produto, ProdutoDTOUpdateRequest>().ReverseMap();
            CreateMap<Produto, ProdutoDTOUpdateResponse>().ReverseMap();
        }
    }
}
