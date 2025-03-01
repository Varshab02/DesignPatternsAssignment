class Program
{
    static void Main()
    {
        Stock appleStock = new Stock("Apple", 150.00);
        Investor investor1 = new Investor("Alice");
        Investor investor2 = new Investor("Bob");
        appleStock.AddInvestor(investor1);
        appleStock.AddInvestor(investor2);
        appleStock.SetPrice(155.00);
        appleStock.SetPrice(160.50);
        appleStock.RemoveInvestor(investor2);
        appleStock.SetPrice(162.75);
    }
}
