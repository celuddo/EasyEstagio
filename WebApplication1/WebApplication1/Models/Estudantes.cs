using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EasyEstagio.Models
{
    public class Estudantes
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Endereço { get; set; }
        public string Instituição { get; set; }
        public string Curso { get; set; }
        public DateTime Semestre { get; set; }
        public bool EstáProcurandoVagas { get; set; }

    }

    public class EstudantesDBContext : DbContext
    {
        public DbSet<Estudantes> Estudantes { get; set; }
    }


}