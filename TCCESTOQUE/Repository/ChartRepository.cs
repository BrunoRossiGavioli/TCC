using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Data;

namespace TCCESTOQUE.Repository
{
    public class ChartRepository
    {
        public readonly TCCESTOQUEContext _context;

        public ChartRepository(TCCESTOQUEContext context)
        {
            _context = context;
        }

        //public List<dynamic> EntradaProduto()
        //{

        //}

        //public List<dynamic> SaidaProd() 
        //{

        //}
    }
}
