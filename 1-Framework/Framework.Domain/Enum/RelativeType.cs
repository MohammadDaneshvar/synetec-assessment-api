using System.ComponentModel;

namespace Framework.Domain.Enum
{
    public enum RelativeType
    {
        [Description("خویشاوندی")]
        FamilyRelative = 1,

        [Description("سرپرستی")]
        Supervisor = 2,

        PrivateCorporate = 4,

        [Description("تسهیلات")]
        Loan =5,

        RealEstate = 6,
        InfoRelation = 8,
        PublicCorporate = 9,
        PrivatePostalCode = 2662,
        PrivatePhone = 2663,
        PrivateLoan = 2664,
        PrivateMobile = 2665,
        PublicPostalCode = 2666,
        PublicPhone = 2667,
        PublicMobile = 2668,
        PublicLoan = 7859
    }
}
