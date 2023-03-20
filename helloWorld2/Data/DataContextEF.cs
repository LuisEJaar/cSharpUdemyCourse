using Microsoft.EntityFrameworkCore;
using helloWorld2.Models;
using Microsoft.Extensions.Configuration;

namespace helloWorld2.Data{

    public class DataContextEF : DbContext {

        private IConfiguration _config;
        
        public DataContextEF(IConfiguration config){
            _config = config;
        }

        public DbSet<Computer>? Computer {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder options){
            if(!options.IsConfigured){
                options.UseSqlServer(_config.GetConnectionString("DefaultConnection"), 
                    options => {
                        options.EnableRetryOnFailure();
                    } 
                );
            }
        }

        //Maps model to actual table on sql server
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.HasDefaultSchema("TutorialAppSchema");

            modelBuilder.Entity<Computer>()
                //If we have no key, we use this
                // .hasNoKey();

                //If we had a key we would say this. Key being unique labels for each line. Think like 1,2,3,4
                //So if there was only one line for each motherboard then you would use this.
                .HasKey(c => c.ComputerId);

            //To table is used to change the default schema. 
                // .ToTable("Computer", "TutorialAppSchema");
                // .ToTable("TableName", "SchemaName");
        }
    }
}