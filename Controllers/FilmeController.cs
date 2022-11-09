using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc; // Serve para conseguirmos usar algumas anotações expecificas do http
using FilmesAPI.models;
using FilmesAPI.Data;

namespace FilmesAPI.Controllers
{
    [ApiController] //Obrigatorio
    [Route("[controller]")]//Obrigatorio
    public class FilmeController : ControllerBase
    {

        private FilmeContext _contenxt;

        public FilmeController(FilmeContext contenxt)
        {
            _contenxt = contenxt;
        }

        [HttpPost] // serve para expecificar o metedo que sera usado  
        public IActionResult AdicionaFilme([FromBody] Filme filme) //FromBody Serve para usar os dados que seram enviados pelo meu body 
        {
            _contenxt.Add(filme);
            _contenxt.SaveChanges();// Para salvar as alterações que foram feitas
            return CreatedAtAction(nameof(recuperarFilmePorId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IEnumerable<Filme> recuperaFilmes()
        {
            //ira returnar todo o conjunto de dados de filme
            return _contenxt.Filmes;
        }

        [HttpGet("{id}")] //PPara conseguirmos colocar params na URL
        public IActionResult recuperarFilmePorId(int id)
        {
            //O FirstOrDefault serve para retonar o primeiro filme que contenha o id expecificado pelo cliente
            Filme filme = _contenxt.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme != null)
            {
                return Ok(filme);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult atualizaFilme(int id, [FromBody] Filme filmeNovo)
        {
            Filme filme = _contenxt.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return NotFound();
            }
            filme.Titulo = filmeNovo.Titulo;
            filme.Genero = filmeNovo.Genero;
            filme.Duracao = filmeNovo.Duracao;
            filme.Diretor = filmeNovo.Diretor;
            _contenxt.SaveChanges();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult deletaFilme(int id)
        {
            Filme filme = _contenxt.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return NotFound();
            }
            _contenxt.Remove(filme);
            _contenxt.SaveChanges();
            return NoContent();
        }
    }
}