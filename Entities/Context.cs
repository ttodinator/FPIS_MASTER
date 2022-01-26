using System;
using System.Collections.Generic;
using FPIS.Entities._1_Identifikacija_novih_klijenata;
using Microsoft.EntityFrameworkCore;

namespace FPIS.Entities
{
    public class Context : DbContext
    {
        public DbSet<Delatnost> Delatnost { get; set; }

        public Context(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;
                                            Database=FPIS_NASTER");
        }
    }

}
