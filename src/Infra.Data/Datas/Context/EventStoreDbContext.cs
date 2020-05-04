using Domain.Core.Events;
using Infra.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Infra.Data.Datas.Context
{
    public class EventStoreDbContext : DbContext
    {
        /// <summary>
        /// Classe que é responsavel por registrar os eventos do sistema
        /// </summary>

        private readonly IHostingEnvironment env;
        public EventStoreDbContext(IHostingEnvironment env)
        {
            this.env = env;
        }
        public DbSet<StoredEvent> StoredEvent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StoreEventConfig());
            
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //pega as configurações do app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();

            //define a dataBase que vai ser utilizada
            //SqlServer
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));

            //para utilizar o mysql descomente o código abaixo
            // optionsBuilder.UseMySql(config.GetConnectionString("DefaultConnetion_Mysql"));
        }
    }
}
