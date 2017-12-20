using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace EasyEstagio.Models
{
    public class Empresas
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereço { get; set; }
        public string Senha { get; set; }
        public int Cnpj { get; set; }

    }
    public class EmpresasDBContext : DbContext
    {
        public DbSet<Empresas> Empresas { get; set; }
    }
}