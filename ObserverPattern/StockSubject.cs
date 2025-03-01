using System;
using System.Collections.Generic;

public class Stock : IStockSubject
{
    private List<IStockInvestor> investors = new List<IStockInvestor>();
    private string stockName;
    private double price;

    public Stock(string name, double initialPrice)
    {
        stockName = name;
        price = initialPrice;
    }

    public void AddInvestor(IStockInvestor investor)
    {
        investors.Add(investor);
    }

    public void RemoveInvestor(IStockInvestor investor)
    {
        investors.Remove(investor);
    }

    public void NotifyAll()
    {
        foreach (var invester in investors)
        {
            invester.Update(stockName, price);
        }
    }

    public void SetPrice(double newPrice)
    {
        if (price != newPrice)
        {
            price = newPrice;
            Console.WriteLine($"\n{stockName} price updated to {price}");
            NotifyAll();
        }
    }
}
