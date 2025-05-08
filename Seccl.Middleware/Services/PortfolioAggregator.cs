using Seccl.Middleware.Models;

public class PortfolioAggregator
{
    public decimal AggregateTotal(List<PortfolioBalance> balances)
    {
        return balances.Sum(x => x.Value);
    }

    public Dictionary<string, decimal> AggregateByAccountType(List<PortfolioBalance> balances)
    {
        return balances
            .GroupBy(x => x.AccountType)
            .ToDictionary(g => g.Key, g => g.Sum(x => x.Value));
    }
}
