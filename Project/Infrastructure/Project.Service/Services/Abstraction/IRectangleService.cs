using Project.Core.Utilities.Results;
using Project.Infrastructure.Dtos;

namespace Project.Service.Services.Abstraction
{
    public interface IRectangleService 
    {
        Result GetRectangle();
        Result SaveDimensions(RectangleDto rectangleDto);
    }
}
