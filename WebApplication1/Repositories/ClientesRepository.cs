using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_CRUD.Model;

namespace WebApplication_CRUD.Repositories {


    public class ClientesRepository : IClientesRepository {

        public readonly ClientesContext _context;

        public ClientesRepository(ClientesContext context)
        {
            _context = context;
        }
        public Cliente Criar(Cliente clientes) 
        {
            _context.Clientes.Add(clientes);
            _context.SaveChanges();

            return clientes;
        }

        public void Deletar(int Id) 
        {
            var clientesToDelete =  _context.Clientes.Find(Id);
            _context.Clientes.Remove(clientesToDelete);
            _context.SaveChanges();
        }

        public List<Cliente> ObterTodos() 
        {
           return  _context.Clientes.ToList();
        }


        public Cliente ObterPorId(int Id) 
        {
            return  _context.Clientes.Find(Id);
        }

        public void Atualizar(Cliente clientes) 
        {
            _context.Entry(clientes).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
