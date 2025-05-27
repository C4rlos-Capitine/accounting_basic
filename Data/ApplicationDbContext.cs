using Acounting_basic.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Acounting_basic.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<MinhaEmpresa> minhaEmpresas { get; set; }
        public DbSet<TipoConta> tipoContas { get; set; }
        public DbSet<ClassConta> classes { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
          
        }
      
    }
}
