using WiseCart.Domain.Entities;
using WiseCart.Domain.Interfaces;
using WiseCart.Infra.Context;

namespace WiseCart.Infra.Repositories
{
    public class UnitOfMeasureRepository : Repository<UnitOfMeasure>, IUnitOfMeasureRepository
    {
        public UnitOfMeasureRepository(AppDbContext context) : base(context)
        {
        }
    }
}
