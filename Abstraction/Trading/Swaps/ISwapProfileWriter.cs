namespace MyNoSqlRepositories.Abstraction.Trading.Swaps;

public interface ISwapProfileWriter
{

    ValueTask<IEnumerable<ISwapProfile>> GetAllAsync();
    ValueTask<IEnumerable<ISwapProfile>> GetAsync(string id);
    ValueTask AddOrUpdate(ISwapProfile swapProfile);
    ValueTask DeleteAsync(string id, string instrumentId);
}