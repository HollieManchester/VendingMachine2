// VendingMachine.cs
using System;

public class VendingMachine
{
    private VendingMachineBank bank;
    private StockManager stockManager;
    private Currency currentCurrency;

    // Constructor to initialise the vending machine with bank, stock manager, and currency
    public VendingMachine(VendingMachineBank bank, StockManager stockManager, Currency currentCurrency)
    {
        this.bank = bank;
        this.stockManager = stockManager;
        this.currentCurrency = currentCurrency;
    }

    // Display available items and their prices
    public void DisplayStock()
    {
        Console.WriteLine("Available items:");
        foreach (var item in stockManager.Stock)
        {
            Console.WriteLine($"{item.Id}. {item.Name} - {currentCurrency.Symbol}{item.Price:F2}");
        }
    }

    // Method to insert a coin into the vending machine
    public decimal InsertCoin(decimal coinValue)
    {
        return bank.InsertCoin(coinValue);
    }

    // Method to select an item and give change
    public decimal SelectItem(int itemId)
    {
        var selectedItem = stockManager.Stock.Find(item => item.Id == itemId);
        if (selectedItem != null)
        {
            Console.WriteLine($"You have selected: {selectedItem.Name} - {currentCurrency.Symbol}{selectedItem.Price:F2}");

            decimal change = bank.GiveChange(selectedItem.Price);
            return change;
        }
        else
        {
            Console.WriteLine("Invalid item selection.");
            return 0m; // or another default value, depending on your requirements
        }
    }


    // Method to add a new stock item
    public void AddStockItem(int id, string name, decimal price)
    {
        stockManager.AddStockItem(id, name, price);
        Console.WriteLine($"Added new item: {name} - {currentCurrency.Symbol}{price:F2}");
    }

    // Method to remove a stock item based on its ID
    public void RemoveStockItem(int id)
    {
        if (stockManager.RemoveStockItem(id))
        {
            Console.WriteLine($"Removed item with ID {id} from stock.");
        }
        else
        {
            Console.WriteLine($"Item with ID {id} not found in stock.");
        }
    }
}
