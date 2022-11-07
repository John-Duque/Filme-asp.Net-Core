using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc; // Serve para conseguirmos usar algumas anotações expecificas do http
using FilmesAPI.models;

namespace FilmesAPI.Controllers
{
    [ApiController] //Obrigatorio
    [Route("[controller]")]//Obrigatorio
    public class FilmeController : ControllerBase
    {


        [HttpPost] // serve para expecificar o metedo que sera usado  
        public IActionResult AdicionaFilme([FromBody] Filme filme) //FromBody Serve para usar os dados que seram enviados pelo meu body 
        {
            return CreatedAtAction(nameof(recuperarFilmePorId), new { Id = filme.Id}, filme);
        }

        [HttpGet]
        public IActionResult recuperaFilmes()
        {
            return Ok();
        }

        [HttpGet("{id}")] //PPara conseguirmos colocar params na URL
        public IActionResult recuperarFilmePorId(int id)
        {
            //O FirstOrDefault serve para retonar o primeiro filme que contenha o id expecificado pelo cliente
            Filme filme = .FirstOrDefault(filme => filme.Id == id);

            if (filme != null)
            {
                return Ok(filme);
            }

            return NotFound();
        }
    }
}