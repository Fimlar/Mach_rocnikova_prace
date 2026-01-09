using Mach_rocnikova_prace.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mach_rocnikova_prace.Data
{
    public static class DbSeeder
    {
        public static void Seed()
        {
            var factory = new RocnikovkaDbContextFactory();
            using var context = factory.CreateDbContext();

            // Vytvoří DB + aplikuje migrace (pokud DB neexistuje, vytvoří se)
            context.Database.Migrate();

            // Nechceme seedovat opakovaně
            if (context.People.Any() || context.Roles.Any() || context.Teams.Any())
                return;

            // 3 role
            var roles = new List<Role>
            {
                new Role { Name = "Vedoucí" },
                new Role { Name = "Trenér" },
                new Role { Name = "Člen" }
            };

            // 3 týmy
            var teams = new List<Team>
            {
                new Team { Name = "A-tým" },
                new Team { Name = "B-tým" },
                new Team { Name = "Juniorka" }
            };

            context.Roles.AddRange(roles);
            context.Teams.AddRange(teams);
            context.SaveChanges(); // teď mají roles/teams vyplněná Id

            // Pomocné mapy pro čitelné přiřazení
            int roleVedouci = roles.Single(r => r.Name == "Vedoucí").Id;
            int roleTrener = roles.Single(r => r.Name == "Trenér").Id;
            int roleClen = roles.Single(r => r.Name == "Člen").Id;

            int teamA = teams.Single(t => t.Name == "A-tým").Id;
            int teamB = teams.Single(t => t.Name == "B-tým").Id;
            int teamJunior = teams.Single(t => t.Name == "Juniorka").Id;

            // aspoň 10 lidí
            var people = new List<Person>
            {
                new Person { FirstName="Jan",   LastName="Novák",     DateOfBirth=new DateOnly(2006, 3, 14), BirthNumber="060314/1234", InsuranceCompanyName="VZP", InsuranceCompanyId="111", TeamId=teamA,      RoleId=roleVedouci, StreetName="Dlouhá",      PostalNumber="12", PostalCode="11000", City="Praha",      Active=true },
                new Person { FirstName="Petra", LastName="Svobodová", DateOfBirth=new DateOnly(2007, 9,  2), BirthNumber="070902/2345", InsuranceCompanyName="VoZP",InsuranceCompanyId="201", TeamId=teamA,      RoleId=roleTrener,  StreetName="Jabloňová",  PostalNumber="7",  PostalCode="60200", City="Brno",       Active=true },
                new Person { FirstName="Tomáš", LastName="Dvořák",    DateOfBirth=new DateOnly(2008, 1, 22), BirthNumber="080122/3456", InsuranceCompanyName="ČPZP",InsuranceCompanyId="205", TeamId=teamA,      RoleId=roleClen,    StreetName="Polní",      PostalNumber="3",  PostalCode="77900", City="Olomouc",    Active=true },

                new Person { FirstName="Klára", LastName="Procházková",DateOfBirth=new DateOnly(2009, 5,  8), BirthNumber="090508/4567", InsuranceCompanyName="OZP", InsuranceCompanyId="207", TeamId=teamB,      RoleId=roleClen,    StreetName="Školní",     PostalNumber="18", PostalCode="50002", City="Hradec Králové", Active=true },
                new Person { FirstName="David", LastName="Kučera",    DateOfBirth=new DateOnly(2006,11, 30), BirthNumber="061130/5678", InsuranceCompanyName="VZP", InsuranceCompanyId="111", TeamId=teamB,      RoleId=roleTrener,  StreetName="Nádražní",   PostalNumber="1",  PostalCode="30100", City="Plzeň",      Active=true },
                new Person { FirstName="Eva",   LastName="Veselá",    DateOfBirth=new DateOnly(2007, 7, 17), BirthNumber="070717/6789", InsuranceCompanyName="VoZP",InsuranceCompanyId="201", TeamId=teamB,      RoleId=roleClen,    StreetName="Květná",     PostalNumber="44", PostalCode="46001", City="Liberec",    Active=true },

                new Person { FirstName="Martin",LastName="Horák",     DateOfBirth=new DateOnly(2010, 2,  5), BirthNumber="100205/7890", InsuranceCompanyName="ČPZP",InsuranceCompanyId="205", TeamId=teamJunior, RoleId=roleClen,    StreetName="Lesní",      PostalNumber="9",  PostalCode="74601", City="Opava",      Active=true },
                new Person { FirstName="Lucie", LastName="Blažková",  DateOfBirth=new DateOnly(2011,10, 19), BirthNumber="111019/8901", InsuranceCompanyName="OZP", InsuranceCompanyId="207", TeamId=teamJunior, RoleId=roleClen,    StreetName="Hlavní",     PostalNumber="25", PostalCode="26101", City="Příbram",    Active=true },
                new Person { FirstName="Ondřej",LastName="Král",      DateOfBirth=new DateOnly(2010, 6, 11), BirthNumber="100611/9012", InsuranceCompanyName="VZP", InsuranceCompanyId="111", TeamId=teamJunior, RoleId=roleClen,    StreetName="U Lípy",     PostalNumber="6",  PostalCode="53002", City="Pardubice",  Active=true },
                new Person { FirstName="Michaela",LastName="Němcová", DateOfBirth=new DateOnly(2009,12,  1), BirthNumber="091201/0123", InsuranceCompanyName="VoZP",InsuranceCompanyId="201", TeamId=teamJunior, RoleId=roleVedouci, StreetName="Sadová",     PostalNumber="10", PostalCode="75701", City="Valašské Meziříčí", Active=true },
            };

            context.People.AddRange(people);
            context.SaveChanges();
        }
    }
}

