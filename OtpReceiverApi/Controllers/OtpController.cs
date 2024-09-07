using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using OtpReceiverApi.models;
using System.Threading.Tasks;

namespace OtpReceiverApi.Controllers{

    [Route("api/[controller]")]
    [ApiController]

    public class OtpController : ControllerBase
    {
        private readonly IMongoCollection<Otp>_otpCollection;

        public OtpController(IMongoClient mongoClient){

            var database = mongoClient.GetDatabase("OtpDB");
            _otpCollection = database.GetCollection<Otp>("Otp");
        }

        [HttpPost("receive-opt")]

        public async Task<IActionResult> ReceiveOtp([FromBody] Otp otp){

            if(otp == null || string.IsNullOrEmpty(Otp.MobileNumber) || string.IsNullOrEmpty(otp.OtpCode)){

                return BadRequest("Mobile Number and OTP are required");

            }

            //save OTP to database
            await _otpCollection.InsertOneAsync(otp);

            return Ok("OTP received successfully!");
        }
    }
}