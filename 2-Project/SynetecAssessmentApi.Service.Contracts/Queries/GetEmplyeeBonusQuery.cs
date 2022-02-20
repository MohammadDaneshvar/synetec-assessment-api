using Framework.Application;
using SynetecAssessmentApi.Service.Contracts.Dtos;

namespace SynetecAssessmentApi.Service.Contracts.Queries
{
    public class GetEmplyeeBonusQuery : IHaveResult<BonusPoolCalculatorResultDto>, IRestrictedCommand
    {
        public int bonusPoolAmount { get; set; }
        public int? selectedEmployeeId { get; set; }
        public BonusPoolCalculatorResultDto Result { get; set; }
    }
}
