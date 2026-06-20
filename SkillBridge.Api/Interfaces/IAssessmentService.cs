using SkillBridge.Api.Records;

namespace SkillBridge.Api.Interfaces;

public interface IAssessmentService
{
    IEnumerable<AssessmentResponseRecord> GetAll();

    AssessmentResponseRecord? GetById(int id);

    AssessmentResponseRecord Create(
        CreateAssessmentRecord record);

    AssessmentResponseRecord? Update(
        int id,
        UpdateAssessmentRecord record);

    bool Delete(int id);
}