using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using Projet_BDTN.Data;
using System;
using System.Linq;

namespace Projet_BDTN.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new Projet_BDTNContext(
            serviceProvider.GetRequiredService<
            DbContextOptions<Projet_BDTNContext>>()))
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            if (!context.Cnsl.Any())
            {
                //Créez et ajoutez des consoles
                var console1 = new cnsl { Name = "Sony", Constructors = "Sony Corporation" };
                var console2 = new cnsl { Name = "Nintendo Switch", Constructors = "Nintendo" };
                var console3 = new cnsl { Name = "Playstation", Constructors = "Sony Computer" };
                context.Cnsl.AddRange(console1, console2, console3);
                
                context.SaveChanges();

                //Créez et ajoutez des données de ventes
                context.Vente.AddRange(
                    new Vente { year=2020, amount=25, cnslId=console1.Id },
                    new Vente { year = 2021, amount = 30, cnslId = console2.Id },
                     new Vente { year = 2023, amount = 100, cnslId = console3.Id }
                );

                context.SaveChanges();
            }
        }
    }
}
