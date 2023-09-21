namespace MyNoSqlRepositories.Abstraction.Markups;

public interface IMarkupProfilesRepository
{
    Task<IEnumerable<IMarkupProfile>> GetAllAsync();

    Task UpdateAsync(IMarkupProfile markupProfile);

    Task<IMarkupProfile> GetById(string profileId);
}