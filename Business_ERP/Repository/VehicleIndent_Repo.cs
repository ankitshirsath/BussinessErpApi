using Business_ERP.Common_Code;
using Business_ERP.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection;

namespace Business_ERP.Repository
{
    public class VehicleIndent_Repo
    {
        #region
        SqlConnection SqlCon = null;
        SqlCommand SqlCmd = null;
        CLS_Function cls = null;
        #endregion
        public VehicleIndent_Repo()
        { 
            cls = new CLS_Function();
        }
        public async Task<string> PostData(VehicleIndentModel model)
        {
            string Message = "";
            try
            {
                SqlCmd = new SqlCommand();
                SqlCmd.CommandTimeout = 60;
                SqlCmd.CommandText = "Sp_VehicleIndent";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Connection = cls.Connect();
                SqlCmd.Parameters.Clear();
                
                SqlCmd.Parameters.AddWithValue("@VehicleIndentId", model.VehicleIndentId);
                SqlCmd.Parameters.AddWithValue("@CommChannelId", model.CommChannelId);
                SqlCmd.Parameters.AddWithValue("@PartyId", model.PartyId);
                SqlCmd.Parameters.AddWithValue("@VehicleRequiredOn", model.VehicleRequiredOn);
                SqlCmd.Parameters.AddWithValue("@ExpiryDate", model.ExpiryDate);
                SqlCmd.Parameters.AddWithValue("@VehicleTypeId", model.VehicleTypeId);
                SqlCmd.Parameters.AddWithValue("@VehicleCount", model.VehicleCount);
                SqlCmd.Parameters.AddWithValue("@ExtendedExpiryDate", model.ExtendedExpiryDate);
                SqlCmd.Parameters.AddWithValue("@FromServiceNetworkId", model.FromServiceNetworkId);
                SqlCmd.Parameters.AddWithValue("@ToServiceNetworkId", model.ToServiceNetworkId);
                SqlCmd.Parameters.AddWithValue("@TransportItemId", model.TransportItemId);
                SqlCmd.Parameters.AddWithValue("@Description", model.Description);
                SqlCmd.Parameters.AddWithValue("@ConsignorId", model.ConsignorId);
                SqlCmd.Parameters.AddWithValue("@ConsigneeId", model.ConsigneeId);
                SqlCmd.Parameters.AddWithValue("@PackingTypeId", model.PackingTypeId);
                SqlCmd.Parameters.AddWithValue("@Weight", model.Weight);
                SqlCmd.Parameters.AddWithValue("@Packets", model.Packets);
                SqlCmd.Parameters.AddWithValue("@TemperatureRangeId", model.TemperatureRangeId);
                SqlCmd.Parameters.AddWithValue("@AssignedToBranchId", model.AssignedToBranchId);
                SqlCmd.Parameters.AddWithValue("@VehicleIndentTypeId", model.VehicleIndentTypeId);
                SqlCmd.Parameters.AddWithValue("@ContractId", model.ContractId);
                SqlCmd.Parameters.AddWithValue("@ShortCloseReasonId", model.ShortCloseReasonId);
                SqlCmd.Parameters.AddWithValue("@IndentRemarks", model.IndentRemarks);
                SqlCmd.Parameters.AddWithValue("@EstimatedRevenueCost", model.EstimatedRevenueCost);

                if (model.VehicleIndentId == 0)
                {
                    SqlCmd.Parameters.AddWithValue("@flag", 'I');
                }
                else
                {
                    SqlCmd.Parameters.AddWithValue("@flag", 'U');
                }
                SqlParameter Result = new SqlParameter();
                Result = SqlCmd.Parameters.Add("@result", SqlDbType.NVarChar, 100);
                Result.Direction = ParameterDirection.Output;
                SqlCmd.ExecuteNonQuery();
                Message = SqlCmd.Parameters["@result"].Value.ToString();
            }
            catch(Exception ex) 
            {
                throw ex;
            }
            return Message;
        }
        public async Task<List<VehicleIndentModel>> VehicleIndentReport()
        {
            string Qry = "select VehicleIndentId,CommChannelId,PartyId,VehicleRequiredOn,ExpiryDate,VehicleTypeId," +
                "VehicleCount,ExtendedExpiryDate,FromServiceNetworkId,ToServiceNetworkId,TransportItemId,Description," +
                "ConsignorId,ConsigneeId,PackingTypeId,Weight,Packets,TemperatureRangeId,AssignedToBranchId," +
                "VehicleIndentTypeId,ContractId,ShortCloseReasonId,IndentRemarks,EstimatedRevenueCost from VehicleIndent";
            var Vehicle_List = new List<VehicleIndentModel>();
            try
            {
                DataTable dt = await cls.FetchData(Qry);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    VehicleIndentModel Vehicle_model = new VehicleIndentModel()
                    {
                        VehicleIndentId = Convert.ToInt32(dt.Rows[i]["VehicleIndentId"]),
                        CommChannelId = Convert.ToInt32(dt.Rows[i]["CommChannelId"]),
                        PartyId = Convert.ToInt32(dt.Rows[i]["PartyId"]),
                        VehicleRequiredOn = Convert.ToDateTime(dt.Rows[i]["VehicleRequiredOn"]),
                        ExpiryDate = Convert.ToDateTime(dt.Rows[i]["ExpiryDate"]),
                        VehicleTypeId = Convert.ToInt32(dt.Rows[i]["VehicleTypeId"]),
                        VehicleCount = Convert.ToInt32(dt.Rows[i]["VehicleCount"]),
                        ExtendedExpiryDate = Convert.ToDateTime(dt.Rows[i]["ExtendedExpiryDate"]),
                        FromServiceNetworkId = Convert.ToInt32(dt.Rows[i]["FromServiceNetworkId"]),
                        ToServiceNetworkId = Convert.ToInt32(dt.Rows[i]["ToServiceNetworkId"]),
                        TransportItemId = Convert.ToInt32(dt.Rows[i]["TransportItemId"]),
                        Description = Convert.ToString(dt.Rows[i]["Description"]),
                        ConsignorId = Convert.ToInt32(dt.Rows[i]["ConsignorId"]),
                        ConsigneeId = Convert.ToInt32(dt.Rows[i]["ConsigneeId"]),
                        PackingTypeId = Convert.ToInt32(dt.Rows[i]["PackingTypeId"]),
                        Weight = Convert.ToInt32(dt.Rows[i]["Weight"]),
                        Packets = Convert.ToInt32(dt.Rows[i]["Packets"]),
                        TemperatureRangeId = Convert.ToInt32(dt.Rows[i]["TemperatureRangeId"]),
                        AssignedToBranchId = Convert.ToInt32(dt.Rows[i]["AssignedToBranchId"]),
                        VehicleIndentTypeId = Convert.ToInt32(dt.Rows[i]["VehicleIndentTypeId"]),
                        ContractId = Convert.ToInt32(dt.Rows[i]["ContractId"]),
                        ShortCloseReasonId = Convert.ToInt32(dt.Rows[i]["ShortCloseReasonId"]),
                        IndentRemarks = Convert.ToString(dt.Rows[i]["IndentRemarks"]),
                        EstimatedRevenueCost = Convert.ToInt32(dt.Rows[i]["EstimatedRevenueCost"]),
                    };
                    Vehicle_List.Add(Vehicle_model);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Vehicle_List;
        }
       
        public async Task<List<VehicleIndentModel>> VehicleIndentReportByID(int ID)
        {
            string Qry = "select VehicleIndentId,CommChannelId,PartyId,VehicleRequiredOn,ExpiryDate,VehicleTypeId," +
                "VehicleCount,ExtendedExpiryDate,FromServiceNetworkId,ToServiceNetworkId,TransportItemId,Description," +
                "ConsignorId,ConsigneeId,PackingTypeId,Weight,Packets,TemperatureRangeId,AssignedToBranchId," +
                "VehicleIndentTypeId,ContractId,ShortCloseReasonId,IndentRemarks,EstimatedRevenueCost from VehicleIndent where VehicleIndentId ="+ID;
            var Vehicle_List = new List<VehicleIndentModel>();
            try
            {
                DataTable dt = await cls.FetchData(Qry);
                VehicleIndentModel Vehicle_model = new VehicleIndentModel()
                {
                    VehicleIndentId = Convert.ToInt32(dt.Rows[0]["VehicleIndentId"]),
                    CommChannelId = Convert.ToInt32(dt.Rows[0]["CommChannelId"]),
                    PartyId = Convert.ToInt32(dt.Rows[0]["PartyId"]),
                    VehicleRequiredOn = Convert.ToDateTime(dt.Rows[0]["VehicleRequiredOn"]),
                    ExpiryDate = Convert.ToDateTime(dt.Rows[0]["ExpiryDate"]),
                    VehicleTypeId = Convert.ToInt32(dt.Rows[0]["VehicleTypeId"]),
                    VehicleCount = Convert.ToInt32(dt.Rows[0]["VehicleCount"]),
                    ExtendedExpiryDate = Convert.ToDateTime(dt.Rows[0]["ExtendedExpiryDate"]),
                    FromServiceNetworkId = Convert.ToInt32(dt.Rows[0]["FromServiceNetworkId"]),
                    ToServiceNetworkId = Convert.ToInt32(dt.Rows[0]["ToServiceNetworkId"]),
                    TransportItemId = Convert.ToInt32(dt.Rows[0]["TransportItemId"]),
                    Description = Convert.ToString(dt.Rows[0]["Description"]),
                    ConsignorId = Convert.ToInt32(dt.Rows[0]["ConsignorId"]),
                    ConsigneeId = Convert.ToInt32(dt.Rows[0]["ConsigneeId"]),
                    PackingTypeId = Convert.ToInt32(dt.Rows[0]["PackingTypeId"]),
                    Weight = Convert.ToInt32(dt.Rows[0]["Weight"]),
                    Packets = Convert.ToInt32(dt.Rows[0]["Packets"]),
                    TemperatureRangeId = Convert.ToInt32(dt.Rows[0]["TemperatureRangeId"]),
                    AssignedToBranchId = Convert.ToInt32(dt.Rows[0]["AssignedToBranchId"]),
                    VehicleIndentTypeId = Convert.ToInt32(dt.Rows[0]["VehicleIndentTypeId"]),
                    ContractId = Convert.ToInt32(dt.Rows[0]["ContractId"]),
                    ShortCloseReasonId = Convert.ToInt32(dt.Rows[0]["ShortCloseReasonId"]),
                    IndentRemarks = Convert.ToString(dt.Rows[0]["IndentRemarks"]),
                    EstimatedRevenueCost = Convert.ToInt32(dt.Rows[0]["EstimatedRevenueCost"]),
                };
                Vehicle_List.Add(Vehicle_model);
            }
            catch (Exception ex) 
            {
                throw ex;
            }
            return Vehicle_List;
        }
        public async Task<string> DeleteData(int ID)
        {
            string Message = "";
            try
            {
                SqlCmd = new SqlCommand();
                SqlCmd.CommandTimeout = 60;
                SqlCmd.CommandText = "Sp_VehicleIndent";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Connection = cls.Connect();
                SqlCmd.Parameters.Clear();

                SqlCmd.Parameters.AddWithValue("@VehicleIndentId", ID);
                SqlCmd.Parameters.AddWithValue("@CommChannelId",0);
                SqlCmd.Parameters.AddWithValue("@PartyId", 0);
                SqlCmd.Parameters.AddWithValue("@VehicleRequiredOn", "");
                SqlCmd.Parameters.AddWithValue("@ExpiryDate", "");
                SqlCmd.Parameters.AddWithValue("@VehicleTypeId", 0);
                SqlCmd.Parameters.AddWithValue("@VehicleCount", 0);
                SqlCmd.Parameters.AddWithValue("@ExtendedExpiryDate", "");
                SqlCmd.Parameters.AddWithValue("@FromServiceNetworkId", 0);
                SqlCmd.Parameters.AddWithValue("@ToServiceNetworkId", 0);
                SqlCmd.Parameters.AddWithValue("@TransportItemId", 0);
                SqlCmd.Parameters.AddWithValue("@Description", "");
                SqlCmd.Parameters.AddWithValue("@ConsignorId", 0);
                SqlCmd.Parameters.AddWithValue("@ConsigneeId", 0);
                SqlCmd.Parameters.AddWithValue("@PackingTypeId", 0);
                SqlCmd.Parameters.AddWithValue("@Weight", 0);
                SqlCmd.Parameters.AddWithValue("@Packets", 0);
                SqlCmd.Parameters.AddWithValue("@TemperatureRangeId", 0);
                SqlCmd.Parameters.AddWithValue("@AssignedToBranchId", 0);
                SqlCmd.Parameters.AddWithValue("@VehicleIndentTypeId", 0);
                SqlCmd.Parameters.AddWithValue("@ContractId", 0);
                SqlCmd.Parameters.AddWithValue("@ShortCloseReasonId", 0);
                SqlCmd.Parameters.AddWithValue("@IndentRemarks", "");
                SqlCmd.Parameters.AddWithValue("@EstimatedRevenueCost", 0);
                SqlCmd.Parameters.AddWithValue("@flag",'D');

                
                SqlParameter Result = new SqlParameter();
                Result = SqlCmd.Parameters.Add("@result", SqlDbType.NVarChar, 100);
                Result.Direction = ParameterDirection.Output;
                SqlCmd.ExecuteNonQuery();
                Message = SqlCmd.Parameters["@result"].Value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Message;
        }
    }
}
