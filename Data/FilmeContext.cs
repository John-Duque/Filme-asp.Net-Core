using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; // Precisa disso para conseguir usar o DbContext
using FilmesAPI.models;

namespace FilmesAPI.Data
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> opt) : base(opt)
        {
            
        }

        //serve tambem para criar o nome da tabela no banco de dados pelo migration
        public DbSet<Filme> Filmes { get; set; }
    }
}