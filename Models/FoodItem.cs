using System.ComponentModel.DataAnnotations;

namespace FoodMenuApi.Models{
  public class FoodItem{
     [Key]
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }

    [Required]    
    public int Price { get; set; }
    
    [Required]
    public string Description { get; set; }
    
    [Required]
    public string ImageUrl { get; set; }
    
    [Required]
    public string Category { get; set; }

    [Required]
    public bool IsVegan { get; set; }

    [Required]
    public float Calories { get; set; }
  }
}