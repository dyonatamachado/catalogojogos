using System.ComponentModel.DataAnnotations;

namespace CatalogoDeJogos.Models.InputModels
{
    public class UpdateGame
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must have between 3 and 100 characters.")]
        public string Name { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Publisher must have between 3 and 100 characters.")]
        public string Publisher { get; set; }
        [Required]
        [Range(1,1000, ErrorMessage = "Price must be between R$ 1.00 and R$ 1,000.00")]
        public double Price { get; set; }
    }
}