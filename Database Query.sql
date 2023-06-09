USE FoodDB;
INSERT INTO FoodCategories VALUES('Biryani'),
('Desserts'),
('Starter');


USE MenuAppDB;

INSERT INTO FoodItems (Name, Price, Description, ImageUrl, Category, FoodCategoryName) 
VALUES 
('Chicken Biryani', 280, 'Chicken Biryani', 'Chicken Biryani.JPG', 'Biryani', 'Biryani'),
('Mutton Biryani', 250, 'Savory mutton biryani dish', 'Mutton Biryani.JPG', 'Biryani', 'Biryani'),
('Egg Biryani', 190, 'Egg Biryani Dish', 'Egg Biryani.JPG', 'Biryani', 'Biryani'),
('Tandoori Chicken', 190, 'Spicy Tandoori Chicken', 'Tandoori Chicken.JPG', 'Starter', 'Starter'),
('Chicken Lollipop', 159, 'Chicken Lollipop', 'Chicken Lollipop.JPG', 'Starter', 'Starter'),
('Chicken 65', 130, 'Crispy Chicken 65', 'Chicken 65.JPG', 'Starter', 'Starter');

-- Final Code

SELECT 
	i.FKUserID,
    i.ID AS OrderId,
    i.DateInvoice AS OrderDate,
    f.Name AS FoodItemName,
    f.Description AS FoodItemDescription,
    f.ImageUrl AS FoodItemImageUrl,
    o.Unit_Price AS FoodItemPrice,
    o.Qty AS FoodItemQty,
    i.Total_Bill AS TotalAmount,
    i.ID AS InvoiceId
FROM orders o
INNER JOIN invoiceModel i ON o.FkInvoiceID = i.ID
INNER JOIN FoodItems f ON o.FkFoodItemId = f.Id
WHERE i.FKUserID = 1
GROUP BY 
	i.FKUserID,
    i.ID, 
    i.DateInvoice, 
    f.Name, 
    f.Description, 
    f.ImageUrl, 
    o.Unit_Price, 
    o.Qty, 
    i.Total_Bill;

