using Microsoft.EntityFrameworkCore;
using TCCESTOQUE.Models;

namespace TCCESTOQUE.Data
{
    public class TCCESTOQUEContext : DbContext
    {
        public TCCESTOQUEContext (DbContextOptions<TCCESTOQUEContext> options)
            : base(options)
        {
        }

        public DbSet<TCCESTOQUE.Models.VendedorModel> VendedorModel { get; set; }

        public DbSet<TCCESTOQUE.Models.FornecedorModel> FornecedorModel { get; set; }

        public DbSet<TCCESTOQUE.Models.ProdutoModel> ProdutoModel { get; set; }

        public DbSet<TCCESTOQUE.Models.FornecedorEnderecoModel> FornecedorEnderecoModel { get; set; }

        public DbSet<TCCESTOQUE.Models.ClienteModel> ClienteModel { get; set; }

        public DbSet<TCCESTOQUE.Models.VendaModel> VendaModel { get; set; }

        public DbSet<TCCESTOQUE.Models.VendaItensModel> VendaItensModel { get; set; }

        public DbSet<TCCESTOQUE.Models.ClienteEnderecoModel> ClienteEnderecoModel { get; set; }
    }
}
