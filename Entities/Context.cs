using System;
using System.Collections.Generic;
using FPIS.Entities._1_Identifikacija_novih_klijenata;
using FPIS.Entities._2_Prikupljanje_potrebnih_informacija_o_klijentu;
using FPIS.Entities._3_Sklapanje_ugovora;
using FPIS.Entities._4_Implementacija_potrebnih_servisa;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FPIS.Entities
{
    public class Context :IdentityDbContext<AppUser, AppRole, int,
                IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DbSet<Delatnost> Delatnost { get; set; }
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<Valuta> Valuta { get; set; }
        public DbSet<VrstaKredita> VrstaKredita { get; set; }

        public Context(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            builder.Entity<AppRole>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

            builder.Entity<Mesto>().HasMany(m => m.Ulice).WithOne(u => u.Mesto).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Ulica>().HasKey(u => new { u.IDUlice, u.PostanskiBroj });
            builder.Entity<Ulica>().HasMany(u => u.Brojevi).WithOne(b => b.Ulica).HasForeignKey(u => new { u.IDUlice, u.PostanskiBroj }).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Broj>().HasKey(b => new { b.PostanskiBroj, b.IDUlice, b.BrojAdrese });
            builder.Entity<PotencijalniKlijent>().HasOne(p => p.ZaposleniSalje).WithMany(zs => zs.PotencijalniKlijentSalje).HasForeignKey(p => p.ZaposleniSaljeId).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<PotencijalniKlijent>().HasOne(p => p.ZaposleniPrima).WithMany(zs => zs.PotencijalniKlijentPrima).HasForeignKey(p => p.ZaposleniPrimaId).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Klijent>().HasOne(k => k.Broj).WithMany(b => b.Klijenti).HasForeignKey(k => new { k.PostanskiBroj, k.IDUlice, k.BrojAdrese }).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Klijent>().HasOne(k => k.Ulica).WithMany(b => b.Klijenti).HasForeignKey(k => new { k.PostanskiBroj, k.IDUlice }).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Entities._2_Prikupljanje_potrebnih_informacija_o_klijentu.StavkaPonude>().HasOne(sp => sp.PonudaUredjajaITarifnihPaketa).WithMany(p => p.StavkePonude).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Kredit>().HasKey(k => new { k.IDKr, k.SifraVrsteKr, k.IDKlijenta });
            builder.Entity<Kredit>().HasOne(k => k.VrstaKredita).WithMany(v => v.Krediti).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Kredit>().HasOne(k => k.Klijent).WithMany(k => k.Krediti).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Zaposleni>().HasMany(z => z.ZahteviZaProveruKreditneSposobnostiPrima).WithOne(za => za.ZaposleniPrima);
            builder.Entity<Zaposleni>().HasMany(z => z.ZahteviZaProveruKreditneSposobnostiSalje).WithOne(za => za.ZaposleniSalje);
            builder.Entity<ZahtevZaProveruKreditneSposobnosti>().HasOne(z => z.Kredit).WithMany(k => k.ZahteviZaProveruKreditneSposobnosti).HasForeignKey(z => new { z.IDKr, z.SifraVrsteKr, z.IDKlijenta }).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<ZahtevZaProveruKreditneSposobnosti>().HasOne(z => z.VrstaKredita).WithMany(v => v.ZahteviZaProveruKreditneSposobnosti).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<ZahtevZaProveruKreditneSposobnosti>().HasOne(z => z.ZaposleniSalje).WithMany(za => za.ZahteviZaProveruKreditneSposobnostiSalje).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<ZahtevZaProveruKreditneSposobnosti>().HasOne(z => z.ZaposleniPrima).WithMany(za => za.ZahteviZaProveruKreditneSposobnostiPrima).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<StavkaZahteva>().HasKey(s => new { s.Rbr, s.IDZahteva });
            builder.Entity<StavkaProracuna>().HasKey(p => new { p.Rbr, p.IDProracuna });
            builder.Entity<Entities._3_Sklapanje_ugovora.StavkaPonudeSklapanjeUgovora>().HasKey(p => new { p.Rbr, p.IDPonude });
            builder.Entity<Entities._3_Sklapanje_ugovora.StavkaPonudeSklapanjeUgovora>().HasOne(s => s.StavkaProracuna).WithMany(sp => sp.StavkePonudeSklapanjeUgovora).HasForeignKey(x => new { x.Rbr, x.IDProracuna }).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<ZahtevZaProveruTehnickihUsluga>().HasOne(z => z.ZaposleniSalje).WithMany(z => z.ZahtevZaProveruTehnickihUslugaSalje).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<ZahtevZaProveruTehnickihUsluga>().HasOne(z => z.ZaposleniPrima).WithMany(z => z.ZahtevZaProveruTehnickihUslugaPrima).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Proracun>().HasOne(p => p.ZaposleniPrima).WithMany(z => z.ProracunPrima).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Proracun>().HasOne(p => p.ZaposleniSalje).WithMany(z => z.ProracunSalje).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Ugovor>().HasOne(p => p.ZaposleniPotpisuje).WithMany(z => z.UgovorPotpisuje).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Ugovor>().HasOne(p => p.ZaposleniProverava).WithMany(z => z.UgovorProverava).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Entities._3_Sklapanje_ugovora.StavkaPonudeSklapanjeUgovora>().HasOne(s => s.Proracun).WithMany(p => p.StavkePonudeSklapanjeUgovora).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<StavkaZahtevaAS>().HasKey(s => new { s.Rbr, s.IDZahtevaAS });
            builder.Entity<StavkaZahtevaTP>().HasKey(s => new { s.Rbr, s.IDZahtevaTP });
            builder.Entity<PotvrdaORealizacijiPodrske>().HasOne(p => p.StavkaZahtevaTP).WithMany(s => s.PotvrdeORealizacijiPodrske).HasForeignKey(x => new { x.Rbr, x.IDZahtevaTP });
            builder.Entity<ZahtevZaAktivacijuServisa>().HasOne(z => z.Zaposleni).WithMany(z => z.ZahteviZaAktivacijuServisa).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<ZahtevZaAktivacijuServisa>().HasOne(z => z.Ugovor).WithMany(z => z.ZahteviZaAktivacijuServisa).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<ZahtevZaTehnickomPodrskom>().HasOne(z => z.Zaposleni).WithMany(z => z.ZahteviZaTehnickomPodrskom).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<ZahtevZaTehnickomPodrskom>().HasOne(z => z.Ugovor).WithMany(z => z.ZahteviZaTehnickomPodrskom).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<PotvrdaORealizacijiPodrske>().HasOne(p => p.ZaTehnickomPodrskom).WithMany(z => z.PotvrdeORealizacijiPodrske).OnDelete(DeleteBehavior.NoAction);
            this.SeedUsers(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;
                                            Database=FPIS_NASTER");
        }

        
        private void SeedRoles(ModelBuilder builder)  
        {  
            builder.Entity<IdentityRole<int>>().HasData(  
                new IdentityRole() {  Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },  
                new IdentityRole() {  Name = "BasicUser", ConcurrencyStamp = "2", NormalizedName = "Basic User" }  
                );  
        }

        private void SeedUsers(ModelBuilder builder)
        {
            AppUser user = new AppUser()
            {
                Id = 1,
                Name = "Petar",
                Surname = "Todic",
                UserName = "admin1",
                Email = "admin@gmail.com",
                LockoutEnabled = false,
                PhoneNumber = "1234567890",
            };
            user.PasswordHash = new PasswordHasher<AppUser>().HashPassword(user, "P@$$w0rd");

            builder.Entity<AppUser>().HasData(user);
        }
    }

}
