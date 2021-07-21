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
    public class PetsController : ControllerBase
    {

        private IPetRepository _petRepository { get; set; }

        public PetsController()
        {
            _petRepository = new PetRepository();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_petRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("{idPet}")]
        public IActionResult BuscarPorId(int idPet)
        {
            try
            {
                return Ok(_petRepository.BuscarPorId(idPet));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Pet novoPet)
        {
            try
            {
                _petRepository.Cadastrar(novoPet);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut("{idPet}")]
        public IActionResult Atualizar(int idPet, Pet petAtualizado)
        {
            try
            {
                _petRepository.Atualizar(idPet, petAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpDelete("{idPet}")]
        public IActionResult Deletar(int idPet)
        {
            try
            {
                _petRepository.Deletar(idPet);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

    }
}
