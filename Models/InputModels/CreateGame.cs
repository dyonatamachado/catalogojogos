using System.ComponentModel.DataAnnotations;

namespace CatalogoDeJogos.Models.InputModels
{
    public class CreateGame
    {   
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "The Name is required and must have between 3 and 100 characters.")]
        public string Name { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "The Publisher is required and must have between 3 and 100 characters.")]
        public string Publisher { get; set; }
        [Required]
        [Range(1,1000, ErrorMessage = "The Price is required and must be between R$ 1.00 and R$ 1,000.00")]
        public double Price { get; set; }
    }
}