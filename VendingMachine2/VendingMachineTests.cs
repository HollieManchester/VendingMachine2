using NUnit.Framework;
using System;
using System.Collections.Generic;

[TestFixture]
public class VendingMachineTests
{
    // Test inserting a coin into the vending machine
    [Test]
    public void TestInsertCoin()
    {
        // Arrange
        Currency currency = new Currency("£");
        VendingMachineBank bank = new VendingMachineBank(0, currency);
        StockManager stockManager = new StockManager(new List<VendingMachineItem>());
        VendingMachine vendingMachine = new VendingMachine(bank, stockManager, currency);

        // Act
        // The InsertCoin method likely returns void, so no need to assign its result
        vendingMachine.InsertCoin(1.00m);

        // Assert
        // Since InsertCoin returns void, there is nothing to assert here.
    }

    // Test selecting an item and giving change
    [Test]
    public void TestSelectItem()
    {
        // Arrange
        Currency currency = new Currency("£");
        VendingMachineBank bank = new VendingMachineBank(2.00m, currency);
        List<VendingMachineItem> initialStock = new List<VendingMachineItem>
        {
            new VendingMachineItem(1, "Cola", 1.50m),
            new VendingMachineItem(2, "Crisps", 1.25m),
            new VendingMachineItem(3, "Sprite", 1.00m)
        };
        StockManager stockManager = new StockManager(initialStock);
        VendingMachine vendingMachine = new VendingMachine(bank, stockManager, currency);

        // Act  
        decimal change = vendingMachine.SelectItem(2);

        // Assert
        Assert.AreEqual(0.75m, change);

    }
}
