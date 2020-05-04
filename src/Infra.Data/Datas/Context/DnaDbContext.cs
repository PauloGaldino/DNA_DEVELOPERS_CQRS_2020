using Domain.Models;
using Infra.Data.Configurations.Clientes;
using Infra.Data.Configurations.Produtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Infra.Data.Datas.Context
{
    public class DnaDbContext : DbContext
    {
        /// <summary>
        /// /Classe que define as cofigurações do banco de dados
        /// </summary>
        
        private readonly IHostingEnvironment env;
        public DnaDbContext(IHostingEnvironment env)
        {
            this.env = env;
        }
        //define as entidados do banco de dados
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Utiliza as cofigurações fetas na classe Config/Map
            modelBuilder.ApplyConfiguration(new ClienteConfig());
            modelBuilder.ApplyConfiguration(new ProdutoConfig());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //pega o as configuações do app Ssttings
            var config = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appSettings.json")
                .Build();

            //define a dataBase que vai ser utilizada
            //SqlServer
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));


            //para utilizar o mysql descomente o código abaixo
            // optionsBuilder.UseMySql(config.GetConnectionString("DefaultConnetion_Mysql"));
        }
    }
}
