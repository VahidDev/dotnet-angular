using AutoMapper;
using Newtonsoft.Json;
using Project.Core.Utilities.Results;
using Project.Infrastructure.Dtos;
using Project.Infrastructure.Repositories.Abstraction;
using Project.Service.Calculators;
using Project.Service.Services.Abstraction;
using Rectangle = Project.Core.Entities.Rectangle;

namespace Project.Service.Services.Implementation
{
    public class RectangleService : IRectangleService
    {
        private readonly IRectangleRepository _rectangleRepository;
        private readonly IMapper _mapper;

        public static readonly string DimensionsFileName = "dimensions.json";

        public RectangleService(
            IRectangleRepository rectangleRepository,
            IMapper mapper
            )
        {
            _rectangleRepository = rectangleRepository;
            _mapper = mapper;
        }

        public Result GetRectangle()
        {
            var result = new Result();

            try
            {
                using (var reader = new StreamReader(DimensionsFileName))
                {
                    string json = reader.ReadToEnd();
                    var rectangle = JsonConvert.DeserializeObject<Rectangle>(json);
                    var dtoToSend = _mapper.Map<RectangleDto>(rectangle);

                    if (rectangle.Id != 0)
                    {
                        var dbRectangle = EnsureCreated(rectangle);
                        dtoToSend.Id = dbRectangle.Id;
                    }

                    dtoToSend.Perimeter = RectangleCalculator.CalculatePerimeter(dtoToSend.Width, dtoToSend.Height);

                    result.Data = _mapper.Map<RectangleDto>(dtoToSend);
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Error = ex.Message;
            }

            return result;
        }

        private Rectangle EnsureCreated(Rectangle rectangle)
        {
            var dbRectangle = _rectangleRepository.Get(r => r.Id == rectangle.Id && !r.IsDeleted);

            if (dbRectangle != null)
            {
                return dbRectangle;
            }

            rectangle.Id = 0;

            _rectangleRepository.Add(rectangle);

            return rectangle;
        }

        public Result SaveDimensions(RectangleDto rectangleDto)
        {
            var result = new Result();

            try
            {
                RectangleDto dtoToSend = null;

                if (rectangleDto.Id == 0)
                {
                    var newRectangle = _mapper.Map<Rectangle>(rectangleDto);
                    newRectangle.CreatedAt = DateTime.Now;

                    result = _rectangleRepository.Add(newRectangle);

                    if (!result.Success)
                    {
                        return result;
                    }

                    dtoToSend = _mapper.Map<RectangleDto>(newRectangle);
                    dtoToSend.Perimeter = RectangleCalculator.CalculatePerimeter(dtoToSend.Width, dtoToSend.Height);

                    result.Data = dtoToSend;
                    
                    UpdateJsonFile(dtoToSend);

                    return result;
                }

                var dbRectangle = _rectangleRepository.Get(r => r.Id == rectangleDto.Id && !r.IsDeleted);

                if (dbRectangle == null)
                {
                    result.Success = false;
                    result.Error = "Rectangle not found!";
                    return result;
                }

                _mapper.Map(rectangleDto, dbRectangle);
                dbRectangle.UpdatedAt = DateTime.Now;

                result = _rectangleRepository.Update(dbRectangle);

                if (!result.Success)
                {
                    return result;
                }

                dtoToSend = _mapper.Map<RectangleDto>(dbRectangle);
                dtoToSend.Perimeter = RectangleCalculator.CalculatePerimeter(dtoToSend.Width, dtoToSend.Height);

                result.Data = dtoToSend;

                UpdateJsonFile(dtoToSend);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Error = ex.Message;
            }

            return result;
        }

        private void UpdateJsonFile(RectangleDto newRectangle)
        {
            try
            {
                string json = JsonConvert.SerializeObject(newRectangle);
                File.WriteAllText(DimensionsFileName, json);
            }
            catch (Exception)
            {
            }
        }
    }
}
