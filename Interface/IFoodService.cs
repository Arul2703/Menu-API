using FoodMenuApi.Models;
namespace FoodMenuApi.Interfaces{
  public interface IFoodMenuService
{
    Task<FoodItem> GetFoodItemAsync(int foodItemId);
    Task<List<FoodItem>> GetAllFoodItemsAsync();
    Task<List<FoodCategory>> GetFoodCategoriesAsync();
    Task AddFoodItemAsync(FoodItem foodItem);
    Task UpdateFoodItemAsync(FoodItem foodItem);
    Task DeleteFoodItemAsync(int foodItemId);
    Task<List<FoodItem>> GetFoodItemsByCategoryAsync(string categoryName);
    Task<List<FoodItem>> GetFoodItemsByPriceAsync(decimal price);
    Task<List<FoodItem>> GetFoodItemsByVeganAsync(bool isVegan);
    Task<List<FoodItem>> GetFoodItemsByCaloriesAsync(float maxCalories);
}
}