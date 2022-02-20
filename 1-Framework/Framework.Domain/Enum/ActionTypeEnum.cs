using Framework.Domain.Resource;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Framework.Domain.Enum
{
    public enum ActionTypeEnum
    {
        None = 0,
        [Display(Name = nameof(GetRelationQuery), ResourceType = typeof(ActionType))]
        [Description("Relation/GetGraph")]
        GetRelationQuery = 1,

        [Display(Name = nameof(GetFamilyRelationGraphQuery), ResourceType = typeof(ActionType))]
        [Description("Relation/GetFamilyRelationGraph")]
        GetFamilyRelationGraphQuery = 2,


        [Display(Name = nameof(GetLoanFullInformationQuery), ResourceType = typeof(ActionType))]
        [Description("Loan/GetLoanFullInfo")]
        GetLoanFullInformationQuery = 11,

        [Display(Name = nameof(GetLoanPersonOfContractQuery), ResourceType = typeof(ActionType))]
        [Description("Loan/GetLoanPersonOfContract")]
        GetLoanPersonOfContractQuery = 12,

        [Display(Name = nameof(GetPersonLoanInformationQuery), ResourceType = typeof(ActionType))]
        [Description("Loan/GetPersonLoanInfo")]
        GetPersonLoanInformationQuery = 13,


        [Display(Name = nameof(GetAllContractSidesQuery), ResourceType = typeof(ActionType))]
        [Description("Contract/GetContractSides")]
        GetAllContractSidesQuery = 21,

        [Display(Name = nameof(GetContractByIdQuery), ResourceType = typeof(ActionType))]
        [Description("Contract/GetContractForPerson")]
        GetContractByIdQuery = 22,

        [Display(Name = nameof(GetContractInfoQuery), ResourceType = typeof(ActionType))]
        [Description("Contract/GetContractInfo")]
        GetContractInfoQuery = 23,


        [Display(Name = nameof(GetAllLegalPersonMemberQuery), ResourceType = typeof(ActionType))]
        [Description("Gazette/GetLegalPersonMember")]
        GetAllLegalPersonMemberQuery = 31,

        [Display(Name = nameof(GetAllPersonCompanyQuery), ResourceType = typeof(ActionType))]
        [Description("Gazette/GetAllPersonCompany")]
        GetAllPersonCompanyQuery = 32,

        [Display(Name = nameof(GetGazetteInformationQuery), ResourceType = typeof(ActionType))]
        [Description("Gazette/GetGazetteInfo")]
        GetGazetteInformationQuery = 33,

        [Display(Name = nameof(GetGazettePersonInformationQuery), ResourceType = typeof(ActionType))]
        [Description("Gazette/GetGazettePersonInfo")]
        GetGazettePersonInformationQuery = 34,

        [Display(Name = nameof(GetLegalPersonGazetteQuery), ResourceType = typeof(ActionType))]
        [Description("Gazette/GetLegalPersonGazette")]
        GetLegalPersonGazetteQuery = 35,

        [Display(Name = nameof(GetLegalPersonLastManagerQuery), ResourceType = typeof(ActionType))]
        [Description("Gazette/GetLegalPersonLastManager")]
        GetLegalPersonLastManagerQuery = 36,


        [Display(Name = nameof(GetAllLegalPersonInformationQuery), ResourceType = typeof(ActionType))]
        [Description("Person/GetListLegalPersonInfo")]
        GetAllLegalPersonInformationQuery = 51,

        [Display(Name = nameof(GetAllNationalCodeRelationQuery), ResourceType = typeof(ActionType))]
        [Description("Person/GetListNationalCodeRelation")]
        GetAllNationalCodeRelationQuery = 52,

        [Display(Name = nameof(GetAllPersonByPhoneNumberQuery), ResourceType = typeof(ActionType))]
        [Description("Person/GetListPersonByPhoneNumber")]
        GetAllPersonByPhoneNumberQuery = 53,

        [Display(Name = nameof(GetAllRealPersonInformationQuery), ResourceType = typeof(ActionType))]
        [Description("Person/GetListRealPersonInfo")]
        GetAllRealPersonInformationQuery = 54,

        [Display(Name = nameof(GetRealPersonFamilyRelationQuery), ResourceType = typeof(ActionType))]
        [Description("Person/GetRealPersonFamilyRelation")]
        GetRealPersonFamilyRelationQuery = 50000,

        [Display(Name = nameof(GetAllRealPersonRelationQuery), ResourceType = typeof(ActionType))]
        [Description("Person/GetAllRealPersonRelation")]
        GetAllRealPersonRelationQuery = 56,

        [Display(Name = nameof(GetAllRelativeTypeChildQuery), ResourceType = typeof(ActionType))]
        [Description("Person/GetAllRelativeTypeChild")]
        GetAllRelativeTypeChildQuery = 57,

        [Display(Name = nameof(GetAllRelativeTypeParentQuery), ResourceType = typeof(ActionType))]
        [Description("Person/GetAllRelativeTypeParent")]
        GetAllRelativeTypeParentQuery = 58,

        [Display(Name = nameof(GetFamilyRelationQuery), ResourceType = typeof(ActionType))]
        [Description("Person/GetFamilyRelation")]
        GetFamilyRelationQuery = 59,

        [Display(Name = nameof(GetLegalPersonInformationQuery), ResourceType = typeof(ActionType))]
        [Description("Person/GetLegalPersonInfo")]
        GetLegalPersonInformationQuery = 60,

        [Display(Name = nameof(GetLegalPersonNationalCodeQuery), ResourceType = typeof(ActionType))]
        [Description("Person/GetLegalPersonNationalCode")]
        GetLegalPersonNationalCodeQuery = 61,

        [Display(Name = nameof(GetPersonAddressQuery), ResourceType = typeof(ActionType))]
        [Description("Person/GetPersonAddress")]
        GetPersonAddressQuery = 62,

        [Display(Name = nameof(GetPersonBankAccountInformationQuery), ResourceType = typeof(ActionType))]
        [Description("Person/GetPersonBankAccountInfo")]
        GetPersonBankAccountInformationQuery = 63,

        [Display(Name = nameof(GetPersonPhoneNumberQuery), ResourceType = typeof(ActionType))]
        [Description("Person/GetPersonPhoneNumber")]
        GetPersonPhoneNumberQuery = 64,

        [Display(Name = nameof(GetPersonFullNameQuery), ResourceType = typeof(ActionType))]
        [Description("Person/GetPersonFullName")]
        GetPersonFullNameQuery = 50001,

        [Display(Name = nameof(GetRealPersonInformationQuery), ResourceType = typeof(ActionType))]
        [Description("Person/GetRealPersonInfo")]
        GetRealPersonInformationQuery = 66,

        [Display(Name = nameof(GetRealPersonNationalCodeQuery), ResourceType = typeof(ActionType))]
        [Description("Person/GetRealPersonNationalCode")]
        GetRealPersonNationalCodeQuery = 67,

        [Display(Name = nameof(GetForeignPersonInformationQuery), ResourceType = typeof(ActionType))]
        [Description("Person/GetForeignPersonInfo")]
        GetForeignPersonInformationQuery = 68,

        [Display(Name = nameof(GetAllForeignPersonInformationQuery), ResourceType = typeof(ActionType))]
        [Description("Person/GetListForeignPersonInfo")]
        GetAllForeignPersonInformationQuery = 69,

        [Display(Name = nameof(GetLatestUpdateDateQuery), ResourceType = typeof(ActionType))]
        [Description("Version/GetLatestUpdateDate")]
        GetLatestUpdateDateQuery = 100,

        [Display(Name = nameof(UpdateRolePermissionCommand), ResourceType = typeof(ActionType))]
        [Description("admin/UpdateRolePermission")]
        UpdateRolePermissionCommand=101,

        [Display(Name = nameof(GetAllPermissionsByRoleQuery), ResourceType = typeof(ActionType))]
        [Description("admin/GetAllPermissionsByRole")]
        GetAllPermissionsByRoleQuery,

        [Display(Name = nameof(GetAllPermissionQuery), ResourceType = typeof(ActionType))]
        [Description("admin/Permissions")]
        GetAllPermissionQuery,

        [Display(Name = nameof(GetAllRolesByPermissionQuery), ResourceType = typeof(ActionType))]
        [Description("admin/GetAllRolesByPermission")]
        GetAllRolesByPermissionQuery,

        [Display(Name = nameof(GetActionHistoryQuery), ResourceType = typeof(ActionType))]
        [Description("admin/GetActionHistoryQuery")]
        GetActionHistoryQuery,

        [Display(Name = nameof(GetLogQuery), ResourceType = typeof(ActionType))]
        [Description("admin/GetLogQuery")]
        GetLogQuery,


        [Display(Name = nameof(GetAllActionPriceQuery), ResourceType = typeof(ActionType))]
        [Description("admin/GetAllActionPriceQuery")]
        GetAllActionPriceQuery,

        [Display(Name = nameof(GetTotalCountActionPriceQuery), ResourceType = typeof(ActionType))]
        [Description("admin/GetTotalCountActionPriceQuery")]
        GetTotalCountActionPriceQuery,

        [Display(Name = nameof(EditActionPriceCommand), ResourceType = typeof(ActionType))]
        [Description("admin/EditActionPriceCommand")]
        EditActionPriceCommand,

        [Display(Name = nameof(CreateActionPriceCommand), ResourceType = typeof(ActionType))]
        [Description("admin/CreateActionPriceCommand")]
        CreateActionPriceCommand,

        [Display(Name = nameof(DeleteActionPriceCommand), ResourceType = typeof(ActionType))]
        [Description("admin/DeleteActionPriceCommand")]
        DeleteActionPriceCommand,


        [Display(Name = nameof(CreateActionPriceDetailCommand), ResourceType = typeof(ActionType))]
        [Description("admin/CreateActionPriceDetailCommand")]
        CreateActionPriceDetailCommand,

        [Display(Name = nameof(DeleteActionPriceDetailCommand), ResourceType = typeof(ActionType))]
        [Description("admin/DeleteActionPriceDetailCommand")]
        DeleteActionPriceDetailCommand,

        [Display(Name = nameof(GetAllLimitRequestQuery), ResourceType = typeof(ActionType))]
        [Description("admin/GetAllLimitRequestQuery")]
        GetAllLimitRequestQuery,

        [Display(Name = nameof(GetTotalCountLimitRequestQuery), ResourceType = typeof(ActionType))]
        [Description("admin/GetTotalCountLimitRequestQuery")]
        GetTotalCountLimitRequestQuery,

        [Display(Name = nameof(CreateLimitRequestCommand), ResourceType = typeof(ActionType))]
        [Description("admin/CreateLimitRequestCommand")]
        CreateLimitRequestCommand,

        [Display(Name = nameof(DeleteLimitRequestCommand), ResourceType = typeof(ActionType))]
        [Description("admin/DeleteLimitRequestCommand")]
        DeleteLimitRequestCommand,

        [Display(Name = nameof(EditLimitRequestCommand), ResourceType = typeof(ActionType))]
        [Description("admin/EditLimitRequestCommand")]
        EditLimitRequestCommand,

        [Display(Name = nameof(CalculateRequestCostQuery), ResourceType = typeof(ActionType))]
        [Description("admin/CalculateRequestCostQuery")]
        CalculateRequestCostQuery,

        [Display(Name = nameof(GetAllOrganizationStockQuery), ResourceType = typeof(ActionType))]
        [Description("admin/GetAllOrganizationStockQuery")]
        GetAllOrganizationStockQuery,

        [Display(Name = nameof(EditOrganizationStockCommand), ResourceType = typeof(ActionType))]
        [Description("admin/EditOrganizationStockCommand")]
        EditOrganizationStockCommand,

        [Display(Name = nameof(CreateOrganizationStockCommand), ResourceType = typeof(ActionType))]
        [Description("admin/CreateOrganizationStockCommand")]
        CreateOrganizationStockCommand = 19000,

        [Display(Name = nameof(ChargeOrganizationStockCommand), ResourceType = typeof(ActionType))]
        [Description("admin/ChargeOrganizationStockCommand")]
        ChargeOrganizationStockCommand = 20000,

        [Display(Name = nameof(SubscriptionCommand), ResourceType = typeof(ActionType))]
        [Description("SubscriptionCommand")]
        SubscriptionCommand = 37000,//job


    }
}
