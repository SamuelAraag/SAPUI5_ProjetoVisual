using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_CRUD.Model;

namespace WebApplication_CRUD.Repositories {
    public interface IClientesRepository {

        public List<Cliente> ObterTodos();

        public Cliente ObterPorId(int Id);

        public Cliente Criar(Cliente clientes);

        public void Atualizar(Cliente clietes);

        public void Deletar(int Id);
        
    }
}
