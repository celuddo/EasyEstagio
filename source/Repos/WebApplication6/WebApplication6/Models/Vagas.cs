using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace EasyEstagio.Models
{
    public class Vagas
    {
        public int Id { get; set; }
        public string Nome { get; set; }    
        public string Atividades { get; set; }
        public string PreRequisitos { get; set; }
        public SqlMoney Salario { get; set; }
        public Decimal CargaHoraria { get; set; }
        public string Beneficios { get; set; }
        public string PalavrasChave { get; set; }
    }

    public class VagasDBContext : DbContext
    {
        public DbSet<Vagas> Vagas { get; set; }


    }

}