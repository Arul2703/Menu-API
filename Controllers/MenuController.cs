using FoodMenuApi.Constraints;
using FoodMenuApi.Interfaces;
using FoodMenuApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
namespace FoodMenuApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IFoodMenuService _menuService;
        private readonly ILogger<MenuController> _logger;

        public MenuController(IFoodMenuService menuService, ILogger<MenuController> logger)
        {
            _menuService = menuService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFoodItemsAsync()
        {
            try
            {
                var foodItems = await _menuService.GetAllFoodItemsAsync();
                return Ok(foodItems);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving all food items.");
                return StatusCode(500, "An error occurred while retrieving all food items.");
            }
        }

        [HttpGet("Categories")]
        public async Task<IActionResult> GetAllFoodCategoriesAsync()
        {
            try
            {
                var foodItems = await _menuService.GetFoodCategoriesAsync();
                return Ok(foodItems);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving all food items.");
                return StatusCode(500, "An error occurred while retrieving all food items.");
            }
        }
        

        // [HttpGet("{name:length(5,20):alpha}")]
            
        // [HttpGet("Categories/{categoryName:category}")]

        [HttpGet("Categories/{categoryName}")]
        // [ServiceFilter(typeof(CategoryConstraintActionFilter))]
        public async Task<IActionResult> GetFoodItemsByCategoryAsync(string categoryName)
        {
            try
            {
                var foodItems = await _menuService.GetFoodItemsByCategoryAsync(categoryName);

                if (foodItems == null || !foodItems.Any())
                {
                    return NotFound();
                }

                return Ok(foodItems);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving food items with category {categoryName}.");
                return StatusCode(500, $"An error occurred while retrieving food items with category {categoryName}.");
            }
        }

        [HttpGet("Price/{price:decimal}")]
        public async Task<IActionResult> GetFoodItemsByPriceAsync(decimal price)
        {
            try
            {
                var foodItems = await _menuService.GetFoodItemsByPriceAsync(price);

                if (foodItems == null || !foodItems.Any())
                {
                    return NotFound();
                }

                return Ok(foodItems);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving food items with price {price}.");
                return StatusCode(500, $"An error occurred while retrieving food items with price {price}.");
            }
        }

        [HttpGet("Vegan/{isVegan:bool}")]
        public async Task<IActionResult> GetFoodItemsByVegan(bool isVegan)
        {
            try
            {
                var foodItems = await _menuService.GetFoodItemsByVeganAsync(isVegan);

                if (foodItems == null || !foodItems.Any())
                {
                    return NotFound();
                }

                return Ok(foodItems);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving food items by vegan: {isVegan}.");
                return StatusCode(500, $"An error occurred while retrieving food items by vegan: {isVegan}.");
            }
        }


        [HttpGet("{id:int:min(1):max(12)}")]
        public async Task<IActionResult> GetFoodItemAsync(int id)
        {
            try
            {
                var foodItem = await _menuService.GetFoodItemAsync(id);

                if (foodItem == null)
                {
                    return NotFound();
                }

                return Ok(foodItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving food item with id {id}.");
                return StatusCode(500, $"An error occurred while retrieving food item with id {id}.");
            }
        }

        [HttpGet("Calories/{maxCalories:float:min(0)}")]
        public async Task<IActionResult> GetFoodItemsByCaloriesAsync(float maxCalories)
        {
            try
            {
                var foodItems = await _menuService.GetFoodItemsByCaloriesAsync(maxCalories);

                if (foodItems == null || !foodItems.Any())
                {
                    return NotFound();
                }

                return Ok(foodItems);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving food items with calories <= {maxCalories}.");
                return StatusCode(500, $"An error occurred while retrieving food items with calories <= {maxCalories}.");
            }
        }


        

        [HttpPost]
         public async Task<IActionResult> AddFoodItemAsync([FromBody] FoodItem foodItem)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _menuService.AddFoodItemAsync(foodItem);
                return Ok(foodItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding a new food item.");
                return StatusCode(500, "An error occurred while adding a new food item.");
            }
        }

        [HttpPut("{id:int:range(1, 12)}")]
        public async Task<IActionResult> UpdateFoodItemAsync(int id, [FromBody] FoodItem foodItem)
        {
            try
            {
                if (id != foodItem.Id)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _menuService.UpdateFoodItemAsync(foodItem);
                return Ok(foodItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating food item with id {id}.");
                return StatusCode(500, $"An error occurred while updating food item with id {id}.");
            }
        }

        [HttpDelete("{id:int:min(1)}")]
        public async Task<IActionResult> DeleteFoodItemAsync(int id)
        {
            try
            {
                var foodItem = await _menuService.GetFoodItemAsync(id);

                if (foodItem == null)
                {
                    return NotFound();
                }

                await _menuService.DeleteFoodItemAsync(id);
                return Ok(foodItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while deleting food item with id {id}.");
                return StatusCode(500, $"An error occurred while deleting food item with id {id}.");
            }
        }
    }
}
