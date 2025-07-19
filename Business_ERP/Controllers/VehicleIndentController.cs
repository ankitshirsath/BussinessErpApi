using Business_ERP.Common_Code;
using Business_ERP.Models;
using Business_ERP.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Business_ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleIndentController : ControllerBase
    {
        #region
        VehicleIndent_Repo _VehicleIndent_Repo;
        #endregion
        [HttpPost]
        [Route("PostVehicleIndent")]
        public async Task<IActionResult> PostVehicleIndent(VehicleIndentModel model)
        {
            _VehicleIndent_Repo = new VehicleIndent_Repo();
            try
            {
                var Response = await _VehicleIndent_Repo.PostData(model);
                return Ok(new { success = true, data = Response });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new {success=false,message=ex.Message});
            }
        }
        [HttpGet]
        [Route("GetVehicleIndentReport")]
        public async Task<IActionResult> GetVehicleIndentReport()
        {
            _VehicleIndent_Repo = new VehicleIndent_Repo();
            try
            {
                var Report = await _VehicleIndent_Repo.VehicleIndentReport();
                return Ok(new { data = Report });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }
        
        [HttpGet]
        [Route("GetVehicleIndentReportByID")]
        public async Task<IActionResult> GetVehicleIndentReportByID(int ID)
        {
            _VehicleIndent_Repo = new VehicleIndent_Repo();
            try
            {
                var Report = await _VehicleIndent_Repo.VehicleIndentReportByID(ID);
                return Ok(new { data = Report });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }
        [HttpDelete]
        [Route("DeleteVehicleIndentByID")]
        public async Task<IActionResult> DeleteVehicleIndentByID(int ID)
        {
            _VehicleIndent_Repo = new VehicleIndent_Repo();
            try
            {
                var response = await _VehicleIndent_Repo.DeleteData(ID);
                return Ok(new { success = true, data = response });
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }
    }
}
