using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCore1.Utilities;

namespace ApiCore1.Model
{
    public class HopRepository : EntityFrameworkRepository<IngredientsContext, Hop>
    {
        public HopRepository(IngredientsContext context) : base(context)
        {
        }

        public async Task<Hop> SaveHop(Hop postedHop)
        {
            int id = postedHop.Id;
            Hop hop;

            if (id < 1)
                hop = Create();
            else
            {
                hop = await Load(id);
                if (hop == null)
                    hop = Create();
            }

            DataUtils.CopyObjectData(postedHop, hop);

            //now lets save it all
            if (!await SaveAsync())
                return null;

            return hop;
        }
    }
}
