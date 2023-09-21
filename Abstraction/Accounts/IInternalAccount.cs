namespace MyNoSqlRepositories.Abstraction.Accounts;

public interface IInternalAccount
{
    string Id { get; }
        
    bool IsInternal { get; }
}