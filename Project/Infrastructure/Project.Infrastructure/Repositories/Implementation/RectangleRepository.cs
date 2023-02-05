using Project.Core.Entities;
using Project.Infrastructure.DAL;
using Project.Infrastructure.Repositories.Abstraction;

namespace Project.Infrastructure.Repositories.Implementation
{
    public class RectangleRepository 
        : GenericRepository<Rectangle>
        , IRectangleRepository
    {
        public RectangleRepository(AppDbContext context) : base(context){}
    }
}
