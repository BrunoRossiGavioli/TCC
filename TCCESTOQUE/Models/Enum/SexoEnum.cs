using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TCCESTOQUE.Models.Enum
{
    public enum SexoEnum
    {
        Selecione = 0,
        Masculino,
        Feminino,
        [Display(Name = "Prefiro não informar")]
        Outros, //prefiro não informar
    }
}
