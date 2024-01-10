// VendingMachineItem.cs
public class VendingMachineItem
{
    // Unique identifier for the item
    public int Id { get; }

    // Name of the item
    public string Name { get; }

    // Price of the item
    public decimal Price { get; }

    // Constructor to initialise item properties
    public VendingMachineItem(int id, string name, decimal price)
    {
        Id = id;
        Name = name;
        Price = price;
    }
}
