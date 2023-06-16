using System.ComponentModel.DataAnnotations;

namespace Store.Catalog.Application.DTOs;

public class ProductDTO
{
    [Key]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "The field {0} is required.")]
    public string Name { get; }

    [Required(ErrorMessage = "The field {0} is required.")]
    public string Description { get; set; }

    [Required(ErrorMessage = "The field {0} is required.")]
    public bool Active { get; set; }

    [Required(ErrorMessage = "The field {0} is required.")]
    public decimal Price { get; }

    [Required(ErrorMessage = "The field {0} is required.")]
    public DateTime RegistrationDate { get; set; }

    [Required(ErrorMessage = "The field {0} is required.")]
    public string Image { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "The field {0} must have a minimum value of {1}.")]
    [Required(ErrorMessage = "The field {0} is required.")]
    public int StockQuantity { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "The field {0} must have a minimum value of {1}.")]
    [Required(ErrorMessage = "The field {0} is required.")]
    public int Height { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "The field {0} must have a minimum value of {1}.")]
    [Required(ErrorMessage = "The field {0} is required.")]
    public int Width { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "The field {0} must have a minimum value of {1}.")]
    [Required(ErrorMessage = "The field {0} is required.")]
    public int Depth { get; set; }

    [Required(ErrorMessage = "The field {0} is required.")]
    public Guid CategoryId { get; }

    public IEnumerable<CategoryDTO> Categories { get; set; }
}