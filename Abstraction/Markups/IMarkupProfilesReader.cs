namespace MyNoSqlRepositories.Abstraction.Markups;

public interface IMarkupProfilesReader
{
    IMarkupProfile Get(string profileId);
}