using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Models{

    public class TripITContext : DbContext{


            public DbSet<Agencija> agencija {get;set;}
            
            public DbSet<Klijent> klijent { get; set; }

            public DbSet<Lokacija> lokacija { get; set; }

            public DbSet<Ponuda> ponuda { get; set; }

            public DbSet<Rezervacija> rezervacija { get; set; }
            public TripITContext(DbContextOptions options) : base(options){

            }

    }
}