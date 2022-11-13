using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc; // Serve para conseguirmos usar algumas anotações expecificas do http
using FilmesAPI.models;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using AutoMapper;

namespace FilmesAPI.Controllers
{
    [ApiController] //Obrigatorio
    [Route("[controller]")]//Obrigatorio
    public class FilmeController : ControllerBase
    {

        private FilmeContext _contenxt;
        private IMapper _mapper;

        public FilmeController(FilmeContext contenxt, IMapper mapper)
        {
            _contenxt = contenxt;
            _mapper = mapper; 
        }

        [HttpPost] // serve para expecificar o metedo que sera usado  
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto) //FromBody Serve para usar os dados que seram enviados pelo meu body 
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);
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
                ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);
                return Ok(filmeDto);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult atualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Filme filme = _contenxt.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return NotFound();
            }

            _mapper.Map(filmeDto, filme);
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