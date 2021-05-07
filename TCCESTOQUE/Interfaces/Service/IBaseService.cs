﻿using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCESTOQUE.Interfaces.Service
{
    public interface IBaseService<T> where T : class
    {
        public T GetOne(Guid? id);

        public ICollection<T> GetAll();
    }
}
