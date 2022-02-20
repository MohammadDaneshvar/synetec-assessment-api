using System.Collections.Generic;

namespace Framework.Domain.Enum
{
    public enum ActionTypeDetailEnum : byte
    {
        Node = 0,
        Edge = 1,
    }
    public static class ActionTypeCategory
    {
        public static List<ActionTypeEnum> GetActionTypeDetailList()
        {
            return new List<ActionTypeEnum>() {
                ActionTypeEnum.GetRealPersonFamilyRelationQuery ,
                ActionTypeEnum.GetFamilyRelationGraphQuery,
                ActionTypeEnum.GetAllRealPersonRelationQuery,
             ActionTypeEnum.GetRelationQuery};
        }

        public static List<ActionTypeEnum> GetActionTypeIHaveCostList()
        {
            return new List<ActionTypeEnum>() {
                ActionTypeEnum.GetRealPersonFamilyRelationQuery ,
                ActionTypeEnum.GetFamilyRelationGraphQuery,
                ActionTypeEnum.CalculateRequestCostQuery ,
                ActionTypeEnum.GetPersonFullNameQuery};
        }
    }
}
