namespace Business_ERP.Models
{
    public class PartyModel
    {
        public int PartyId { get; set; }

        public string PartyName { get; set; }

        public int PartyTypeId { get; set; }

        public int PartyNatureId { get; set; }

        public int PartyGroupId { get; set; }

        public int PartyCategoryId { get; set; }

        public int ZoneId { get; set; }

        public int PartyIndustryTypeId { get; set; }

        public int TdsDeducteeTypeId { get; set; }

        public int PartyGradeId { get; set; }

        public int CurrencyId { get; set; }

        public string IsSalesTaxApplicable { get; set; }

        public string IsCustomDutyApplicable { get; set; }

        public string IsExciseDutyApplicable { get; set; }

        public string IsServiceTaxPayableByParty { get; set; }

        public string IsServiceTaxExempted { get; set; }

        public string ExciseRange { get; set; }

        public string ExciseDivision { get; set; }

        public string ExciseCollectorate { get; set; }

        public int FieldSetId { get; set; }

        public int ChargeHeadSetId { get; set; }

        public decimal CreditLimit { get; set; }

        public int DefaultConsigneeId { get; set; }

        public int DefaultAgentId { get; set; }

        public int DefaultTransporterId { get; set; }

        public int DefaultPriceListGroupId { get; set; }

        public int DefaultPricePolicyId { get; set; }

        public int UserOrgLocationId { get; set; }

        public int UserProfileId { get; set; }

        public int UserId { get; set; }

        public string LoginName { get; set; }

        public string Password { get; set; }
    }
}
