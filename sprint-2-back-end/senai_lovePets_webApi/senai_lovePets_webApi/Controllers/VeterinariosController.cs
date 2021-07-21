using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using senai_lovePets_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class VeterinariosController : ControllerBase
    {

        private IVeterinarioRepositoory _vetRepository { get; set; }

        public VeterinariosController()
        {
            _vetRepository = new VeterinarioRepository();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_vetRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("{idVeterinario}")]
        public IActionResult BuscarPorId(int idVeterinario)
        {
            try
            {
                return Ok(_vetRepository.BuscarPorId(idVeterinario));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Veterinario novoVeterinario)
        {
            try
            {
                _vetRepository.Cadastrar(novoVeterinario);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut("{idVeterinario}")]
        public IActionResult Atualizar(int idVeterinario, Veterinario vetAtualizado)
        {
            try
            {
                _vetRepository.Atualizar(idVeterinario, vetAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpDelete("{idVeterinario}")]
        public IActionResult Deletar(int idVeterinario)
        {
            try
            {
                _vetRepository.Deletar(idVeterinario);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

    }
}
