using AutoMapper;
using EmprestimosLivros.API.DTOs;
using EmprestimosLivros.API.Interfaces;
using EmprestimosLivros.API.Models;
using EmprestimosLivros.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimosLivros.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        public readonly IClienteRepository _clienteRepository;
        public readonly IMapper _mapper;

        public ClienteController(IClienteRepository clienteRepository, IMapper mapper)
        {
            _mapper= mapper;
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetCliente()
        {
            var clientes = await _clienteRepository.SelecionarTodos();
            var clientesDTO = _mapper.Map<IEnumerable<ClienteDTO>>(clientes);
            return Ok(clientesDTO);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> SelecionarCliente(int id)
        {
            var cliente = await _clienteRepository.SelecionarByPk(id);

            if (cliente == null)
            {
                return NotFound("Cliente não encontrado.");
            }

            var clienteDTO = _mapper.Map<ClienteDTO>(cliente);

            return Ok(clienteDTO);
        }


        [HttpPost]
        public async Task<ActionResult> CadastrarCliente(ClienteDTO clientesDTO)
        {            
            var cliente = _mapper.Map<Cliente>(clientesDTO);
            _clienteRepository.Incluir(cliente);
            if (await _clienteRepository.SaveAllAsync())
            {
                return Ok("Cliente cadastrado com sucesso!");
            }
            return BadRequest("Ocorreu um erro ao cadastrar o cliente.");
        }


        [HttpPut]
        public async Task<ActionResult> AlterarCliente(ClienteDTO clienteDTO)
        {
            if (clienteDTO.Id == 0)
            {
                return BadRequest("Não é possivel Alterar o cliente, informe o 'ID'.");
            }

            var clienteExiste = await _clienteRepository.SelecionarByPk(clienteDTO.Id);
            if (clienteExiste == null)
            {
                return NotFound("Cliente não encontrado.");
            }


            var cliente = _mapper.Map<Cliente>(clienteDTO);
            _clienteRepository.Alterar(cliente);
            if (await _clienteRepository.SaveAllAsync())
            {
                return Ok("Cliente Alterado com sucesso!");
            }
            return BadRequest("Ocorreu um erro ao Alterar o cliente.");
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> ExcluirCliente(int id)
        {
            var cliente = await _clienteRepository.SelecionarByPk(id);
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado.");
            }

            _clienteRepository.Excluir(cliente);
            if (await _clienteRepository.SaveAllAsync())
            {
                return Ok("Cliente excluido com sucesso!");
            }
            return BadRequest("Ocorreu um erro ao excluir o cliente.");
        }
    }
}
