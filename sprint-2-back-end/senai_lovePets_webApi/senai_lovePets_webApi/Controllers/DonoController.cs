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
    public class DonoController : ControllerBase
    {

        private IDonoRepository _donoRepository { get; set; }

        public DonoController()
        {
            _donoRepository = new DonoRepository();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_donoRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("{idDono}")]
        public IActionResult BuscarPorId(int idDono)
        {
            try
            {
                return Ok(_donoRepository.BuscarPorId(idDono));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Dono novoDono)
        {
            try
            {
                _donoRepository.Cadastrar(novoDono);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut("{idDono}")]
        public IActionResult Atualizar(int idDono, Dono donoAtualizado)
        {
            try
            {
                _donoRepository.Atualizar(idDono, donoAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpDelete("{idDono}")]
        public IActionResult Deletar(int idDono)
        {
            try
            {
                _donoRepository.Deletar(idDono);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


    }
}
