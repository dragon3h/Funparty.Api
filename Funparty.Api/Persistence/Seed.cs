using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using Funparty.Api.Domain.Entities;

namespace Funparty.Api.Persistence
{
    public class Seed
    {
        public static void SeedMascots(FunpartyDbContext context)
        {
            if (!context.Mascots.Any())
            {
                var mascotsData = System.IO.File.ReadAllText("Persistence/MascotSeedData.json");
                var mascots = JsonConvert.DeserializeObject<List<Mascot>>(mascotsData);
                foreach (var mascot in mascots)
                {
                    context.Mascots.Add(mascot);
                }

                context.SaveChanges();
            }
        }
    }
}
