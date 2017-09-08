using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCore1.Model
{
    public class HopRepository : EntityFrameworkRepository<IngredientsContext, Hop>
    {
        public HopRepository(IngredientsContext context) : base(context)
        {
        }
    }
}
