namespace MyNoSqlRepositories.Abstraction.Trading.Swaps;

public interface ISwapProfileReader
{
    IReadOnlyList<ISwapProfile> GetAll();
    IReadOnlyList<ISwapProfile> Get(string id);
}