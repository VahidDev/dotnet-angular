using System.ComponentModel.DataAnnotations;

namespace Project.Infrastructure.Dtos
{
    public class RectangleDto
    {
        public int Id { get; set; }
        [Required]
        public int Width { get; set; }
        [Required]
        public int Height { get; set; }
        [Required]
        public int X { get; set; }
        [Required]
        public int Y { get; set; }

        public int Perimeter { get; set; }
    }
}
