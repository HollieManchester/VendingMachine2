// VendingMachineBank.cs
using System;
using System.Collections.Generic;
using System.Linq;

public class VendingMachineBank
{
    // Current amount of money in the vending machine
    private decimal amount;

    // Dictionary to store available coin denominations and their counts
    private Dictionary<decimal, int> coinDenominations;

    // Reference to the currency used
    private Currency currentCurrency;

    // Constructor to initialise the bank with an initial amount and currency
    public VendingMachineBank(decimal initialAmount, Currency currentCurrency)
    {
        amount = initialAmount;
        this.currentCurrency = currentCurrency;
        InitializeCoinDenominations();
    }

    // Initialise coin denominations with their counts
    private void InitializeCoinDenominations()
    {
        coinDenominations = new Dictionary<decimal, int>
        {
            { 2.00m, 10 }, // £2 coins
            { 1.00m, 10 }, // £1 coins
            { 0.50m, 10 }, // 50p coins
            { 0.20m, 10 }, // 20p coins
            { 0.10m, 10 }, // 10p coins
            { 0.05m, 10 }, // 5p coins
            { 0.02m, 10 }, // 2p coins
            { 0.01m, 10 }  // 1p coins
        };
    }

    // Method to insert a coin into the vending machine
    public decimal InsertCoin(decimal coinValue)
    {
        if (coinDenominations.ContainsKey(coinValue) && coinDenominations[coinValue] > 0)
        {
            amount += coinValue;
            coinDenominations[coinValue]--;
            Console.WriteLine($"Inserted {currentCurrency.Symbol}{coinValue:F2}. Current balance: {currentCurrency.Symbol}{amount:F2}");
            return amount;
        }
        else
        {
            Console.WriteLine($"Invalid coin or insufficient change available for {currentCurrency.Symbol}{coinValue:F2}");
            return amount;
        }
    }

    // Method to give change based on the item price
    public decimal GiveChange(decimal itemPrice)
    {
        decimal changeAmount = amount - itemPrice;

        if (changeAmount >= 0)
        {
            Console.WriteLine($"Change given: {currentCurrency.Symbol}{changeAmount:F2}");
            DispenseChange(changeAmount);
            amount = 0; // Reset balance after giving change
        }
        else
        {
            Console.WriteLine($"Insufficient funds. Please insert more coins.");
        }

        return changeAmount;
    }

    // Method to dispense change in appropriate coin denominations
    private void DispenseChange(decimal changeAmount)
    {
        foreach (var denomination in coinDenominations.OrderByDescending(d => d.Key))
        {
            int coinsToDispense = (int)(changeAmount / denomination.Key);
            if (coinsToDispense > 0 && coinDenominations[denomination.Key] >= coinsToDispense)
            {
                Console.WriteLine($"Dispensing {coinsToDispense} x {currentCurrency.Symbol}{denomination.Key:F2} coins");
                changeAmount -= coinsToDispense * denomination.Key;
                coinDenominations[denomination.Key] -= coinsToDispense;
            }
        }
    }
}
