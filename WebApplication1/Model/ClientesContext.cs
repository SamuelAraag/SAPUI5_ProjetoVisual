using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_CRUD.Model
{
    public class ClientesContext : DbContext {
        public ClientesContext(DbContextOptions<ClientesContext> options) : base(options) 
        {
           Database.EnsureCreated();

        }

        public DbSet<Cliente> Clientes { get; set; }

        
        
    }
}
