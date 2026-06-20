using SkillBridge.Api.Records;

namespace SkillBridge.Api.Interfaces;

public interface IPortfolioProjectService
{
    IEnumerable<PortfolioProjectResponseRecord> GetAll();

    PortfolioProjectResponseRecord? GetById(int id);

    PortfolioProjectResponseRecord Create(
        CreatePortfolioProjectRecord record);

    PortfolioProjectResponseRecord? Update(
        int id,
        UpdatePortfolioProjectRecord record);

    bool Delete(int id);
}