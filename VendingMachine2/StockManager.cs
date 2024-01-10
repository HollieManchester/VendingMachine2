// StockManager.cs
using System.Collections.Generic;
using System.Linq;

public class StockManager
{
    // List to store vending machine items
    public List<VendingMachineItem> Stock { get; }

    // Constructor to initialise stock with initial items
    public StockManager(List<VendingMachineItem> initialStock)
    {
        Stock = initialStock;
    }

    // Add a new item to the stock
    public void AddStockItem(int id, string name, decimal price)
    {
        var newItem = new VendingMachineItem(id, name, price);
        Stock.Add(newItem);
    }

    // Remove an item from the stock based on its ID
    public bool RemoveStockItem(int id)
    {
        var itemToRemove = Stock.FirstOrDefault(item => item.Id == id);
        if (itemToRemove != null)
        {
            Stock.Remove(itemToRemove);
            return true;
        }
        return false;
    }
}
