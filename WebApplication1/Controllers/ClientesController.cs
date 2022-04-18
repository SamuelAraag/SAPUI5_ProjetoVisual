using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_CRUD.Model;
using WebApplication_CRUD.Repositories;

namespace WebApplication_CRUD.Controllers {

    [Route("api/[Controller]")]
    [ApiController]
    public class ClientesController : ControllerBase 
    {
        public readonly IClientesRepository _clientesRepository;
        public ClientesController(IClientesRepository clientesRepository) 
        {
            _clientesRepository = clientesRepository;
        }

        [HttpGet]
        [Route("ObterTodos")]
        public IActionResult ObterClientes() 
        {
            var todosOsCliente = _clientesRepository.ObterTodos();
            if ( todosOsCliente.Count() == 0)
            {
                return new OkObjectResult(new { message = "Nenhum Cliente Cadastrado" });
            }
            return Ok (todosOsCliente);
        }

        [HttpGet("ObterComId")]
        public IActionResult ObterClientePorId(int Id) 
        {

            var cliente = _clientesRepository.ObterPorId(Id);
            if(cliente == null)
            {
                return new OkObjectResult(new { message = "Cliente não encontrado" });
            }
            return Ok(cliente);
        }

        [HttpPost]
        [Route("Inserir")]
        public IActionResult InserirCliente([FromBody] Cliente cliente) 
        {
            _clientesRepository.Criar(cliente);
            return new OkObjectResult(new { message = "Cliente Cadastrado" });
        }

        [HttpDelete("Deletar")]
        public IActionResult DeletarCliente(int Id) 
        {
            var clienteToDelete = _clientesRepository.ObterPorId(Id);
            if (clienteToDelete == null)
            {
                return new OkObjectResult(new { message = "Cliente não encontrado" });
            }
            _clientesRepository.Deletar(Id);
            return new OkObjectResult(new { message = "Cliente deletado" });
        }

        [HttpPut]
        [Route("Atualizar")]
        public IActionResult AtualizarCliente(int Id, [FromBody] Cliente cliente)
        {
            if (Id != cliente.Id)
            {
                return new OkObjectResult(new { message = "Cliente não encontrado" });
            }
            _clientesRepository.Atualizar(cliente);
            return new OkObjectResult(new { message = "Cliente atualizado" });
        }
    }
}
