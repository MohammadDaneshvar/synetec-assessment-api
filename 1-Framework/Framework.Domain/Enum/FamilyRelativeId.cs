using System.ComponentModel;

namespace Framework.Domain.Enum
{
    public enum FamilyRelativeId
    {
        [Description("برادر خواهر")]
        BrotherSister = 1,
        [Description("پدر/فرزند")]
        Father = 5,
        [Description("مادر/فرزند")]
        Mother = 15,
        [Description("ناپدری")]
        stepFather = 18,
        [Description("نامادری")]
        stepMother = 19,
        [Description("همسر")]
        Spouse = 21,
        [Description("همسردوم")]
        SecondWife = 23
    }
}
