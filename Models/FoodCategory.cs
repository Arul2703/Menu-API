using System.ComponentModel.DataAnnotations;

namespace FoodMenuApi.Models{
  public class FoodCategory{
     public string Name { get; set; }
    
    public List<FoodItem> Items { get; set; }
  }
} 