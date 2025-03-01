public interface IStockSubject
{
    void AddInvestor(IStockInvestor investor);
    void RemoveInvestor(IStockInvestor investor);
    void NotifyAll();
}
