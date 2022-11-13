using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Data.Dtos
{
    public class UpdateFilmeDto
    {
        [Required(ErrorMessage = "O Campo título é obrigatório")] // serve para dizer que esse atributo e obrigatório
        public string? Titulo { get; set; }

        [Required(ErrorMessage = "O Campo diretor é obrigatório")]
        public string? Diretor { get; set; }

        [StringLength(30, ErrorMessage = "O gênero não pode passar de 30 caracteres")]
        public string? Genero { get; set; }

        [Range(1, 600, ErrorMessage = "A duração deve ter no minimo 1 e no maximo 600 minutos")] // serve para colocar um um range da duracao do filme
        public int Duracao { get; set; }
    }
}