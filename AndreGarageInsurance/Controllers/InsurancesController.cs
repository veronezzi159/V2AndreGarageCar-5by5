using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Models;
using Models.DTO;


namespace AndreGarageInsurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsurancesController : ControllerBase
    {
        private  string Conn { get; set; }

        public InsurancesController()
        {
            Conn = System.Configuration.ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString;
        }

        [HttpGet]
        public async Task<ActionResult<List<Insurance>>> GetInsurance()
        {
            if (Conn == null)
            {
                return NotFound();
            }
            using(SqlConnection conn = new SqlConnection(Conn))
            {
                conn.Open();
                var insurance = conn.Query<Insurance,Client,Car,Driver,CNH,Category,Insurance>(Insurance.SELECT, (insurance, client, car, driver,cnh,category) =>
                {

                    insurance.Client = client;
                    insurance.Car = car;
                    insurance.Driver = driver;
                    driver.CNH = cnh;
                    cnh.Category = category;
                    return insurance;
                }, splitOn: "Document,Plate,Document,Cnh,Id").ToList();
                if (insurance == null)
                {
                    return NotFound();
                }
                return insurance;
            }
        }
        [HttpPost]
        public async Task<ActionResult<Insurance>> PostInsurance(InsuranceDTO insuranceDTO)
        {
            if (Conn == null)
            {
                return NotFound();
            }
            using (SqlConnection conn = new SqlConnection(Conn))
            {
                conn.Open();
                var insurance = conn.Execute(Insurance.INSERT, insuranceDTO);
                conn.Close();
                if (insurance == 0)
                {
                    return NotFound();
                }
            }
            return CreatedAtAction("GetInsurance", new { id = insuranceDTO.Id }, insuranceDTO);
            
        }

    }
}
