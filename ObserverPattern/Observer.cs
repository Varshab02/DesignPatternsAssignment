using System;

public class Investor : IStockInvestor
{
    private string investorName;

    public Investor(string name)
    {
        investorName = name;
    }

    public void Update(string stockName, double price)
    {
        Console.WriteLine($"{investorName} received alert: {stockName} is now {price}");
    }
}

