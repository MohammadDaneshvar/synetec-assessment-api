using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Framework.Domain.Enum
{
    public enum NodeEnum { LegalPerson, RealPerson, ForeignPerson };

    public enum EdgeEnum
    {
        PublicCorporate = 9,

        PrivateCorporate = 4,

        FamilyRelative = 1,

        PublicLoan = 7859,

        PrivateLoan = 2664,

        Loan = 5,

        RealEstate = 6,

        Supervisor = 2,

        PrivatePostalCode = 2662,

        PublicPostalCode = 2666,

        PrivatePhone = 2663,

        PublicPhone = 2667,

        PrivateMobile = 2665,

        PublicMobile = 2668,

        InfoRelation = 8,

        Subsidy = 49,

        Insurance = 50
    };
}

