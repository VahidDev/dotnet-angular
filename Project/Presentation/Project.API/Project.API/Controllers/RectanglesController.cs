using Microsoft.AspNetCore.Mvc;
using Project.Infrastructure.Dtos;
using Project.Service.Services.Abstraction;

namespace Project.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RectanglesController : ControllerBase
    {
        private readonly IRectangleService _rectangleService;

        public RectanglesController(IRectangleService rectangleService)
        {
            _rectangleService = rectangleService;
        }

        [HttpPost]
        [ModelStateControl]
        public IActionResult SaveDimensions(RectangleDto rectangleDto)
        {
            var result = _rectangleService.SaveDimensions(rectangleDto);
            return Ok(result);
        }


        [HttpGet]
        public IActionResult GetRectangle()
        {
            var result = _rectangleService.GetRectangle();
            return Ok(result);
        }
    }
}
