﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Models;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<FornecedorEnderecoViewModel, FornecedorModel>();
            CreateMap<FornecedorEnderecoViewModel, FornecedorEnderecoModel>();
            CreateMap<FornecedorEnderecoModel, FornecedorEnderecoViewModel>();
            CreateMap<FornecedorModel, FornecedorEnderecoViewModel>();
        }
    }
}
