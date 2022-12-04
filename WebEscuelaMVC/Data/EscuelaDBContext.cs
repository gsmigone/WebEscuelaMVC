using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebEscuelaMVC.Models;

namespace WebEscuelaMVC.Data
{
    public class EscuelaDBContext : DbContext
    {
        public EscuelaDBContext() : base("KeyDBEscuelaMVC") { }

        public DbSet<Aula> Aulas { get; set; }
    }
}