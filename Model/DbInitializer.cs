using System.Linq;

namespace ApiCore1.Model
{
    public static class DbInitializer
    {
        public static void Initialize(IngredientsContext ctx)
        {
            ctx.Database.EnsureCreated();

            if (ctx.Hops.Any())
            {
                return;
            }

            var hops = new Hop[]
            {
                new Hop{ Id=1,Name="Admiral",Description="Bittering hops derived from Wye Challenger.  Good high-alpha bittering hops.\nUsed for: Ales\nAroma: Primarily for bittering\nSubstitutes: Target, Northdown, Challenger\n"},
                new Hop{ Id=2,Name="Cascade",Description="A hops with Northern Brewers Heritage\nUsed for: American ales and lagers\nAroma: Strong spicy, floral, grapefruit character\nSubstitutes: Centennial\nExamples: Sierra Nevada Pale Ale, Anchor Liberty Ale"},
                new Hop{ Id=3,Name="Citra",Description="Special aroma hops released in 2007.  Imparts high alpha/oil content but low cohumulone.\nAroma: Adds interesting citrus and tropical fruit character to the beer.  \nSubstitutes: Unknown"},
                new Hop{ Id=4,Name="Columbia",Description="Sibling of Williamette hops.\nUsed for: All English Ales\nAroma: Close to Fuggles\nSubstitutes: Fuggles, Williamette"},
                new Hop{ Id=5,Name="Fuggle",Description="As Fuggle (U.K.), only organic variety\nTypical alpha: 3-5%. Organically grown Fuggle hops from the UK. Wonderful earthy, pipe-tobacco, floral character. Classic hop for any English ale."},
            };

            foreach (var h in hops)
            {
                ctx.Hops.Add(h);    
            }

            ctx.SaveChanges();
        }
    }
}