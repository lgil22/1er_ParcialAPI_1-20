using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.EntityFrameworkCore;
using _1er_ParcialAPI_1_20.DAL;
using _1er_ParcialAPI_1_20.Entidades;
//using _1er_ParcialAPI_1_20.UI.Registros;
/*using_1er_ParcialAPI_1_20.UI;
using_1er_ParcialAPI_1_20.BLL;*/



namespace _1er_ParcialAPI_1_20.DAL.Scripts
{
    public class Contexto : DbContext
    {

        public DbSet<Articulos> Articulos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = .\SqlExpress; Database = ArticulosDb; Trusted_Connection = True; ");
        }

    }

}
