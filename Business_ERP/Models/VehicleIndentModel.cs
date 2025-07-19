namespace Business_ERP.Models
{
    public class VehicleIndentModel
    {
        public  int VehicleIndentId { get; set; }

        public  int CommChannelId { get; set; }

        public  int PartyId { get; set; }

        public  DateTime VehicleRequiredOn { get; set; }

        public  DateTime ExpiryDate { get; set; }

        public  int VehicleTypeId { get; set; }

        public  int VehicleCount { get; set; }

        public  DateTime ExtendedExpiryDate { get; set; }

        public int FromServiceNetworkId { get; set; }

        public int ToServiceNetworkId { get; set; }

        public int TransportItemId { get; set; }

        public string Description { get; set; }

        public int ConsignorId { get; set; }

        public int ConsigneeId { get; set; }

        public int PackingTypeId { get; set; }

        public decimal Weight { get; set; }

        public int Packets { get; set; }

        public int TemperatureRangeId { get; set; }

        public int AssignedToBranchId { get; set; }

        public   int VehicleIndentTypeId { get; set; }

        public int ContractId { get; set; }

        public int ShortCloseReasonId { get; set; }

        public   string IndentRemarks { get; set; }

        public decimal EstimatedRevenueCost { get; set; }

    }
}
