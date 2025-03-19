using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimtestApi.Dto;
using MimtestApi.Service.Interfaces;
using Newtonsoft.Json;

namespace MimtestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {

		private readonly ILogger<LoanController> _logger;
		private readonly ILoanApplication _loanApplication;
        public LoanController(ILogger<LoanController> logger,   ILoanApplication loanApplication) 
        {
            _loanApplication = loanApplication;
			_logger = logger;
        }


		[HttpPost]
		[Route("CreateLoanApplication")]
		public async Task<IActionResult> CreateLoandApplication([FromBody] CreateLoanRequest model)
		{
			_logger.LogInformation(JsonConvert.SerializeObject(model));
			var response = await _loanApplication.CreateLoan(model);
			_logger.LogInformation(JsonConvert.SerializeObject(response));
			return await Task.FromResult(new JsonResult(response));

			
		}

		[HttpGet]
		[Route("getallloans")]
		public async Task<IActionResult> GetAllLoans
		()
		{

			var response = await _loanApplication.GetAllLoansApplication();
			_logger.LogInformation($"GetUserInfo response {JsonConvert.SerializeObject(response)}");
			return await Task.FromResult(new JsonResult(response));
		}

		[HttpGet]
		[Route("get-loan-by-id")]
		public async Task<IActionResult> GetAllLoansById
		(int id)
		{
			var response = await _loanApplication.GetLoanById(id);
			_logger.LogInformation($"GetUserInfo response {JsonConvert.SerializeObject(response)}");
			return await Task.FromResult(new JsonResult(response));
		}


		[HttpPut]
		[Route("UpdateLoanApplication")]
		public async Task<IActionResult> UpdateLoan(int id,[FromBody] UpdateLoanRequest model)
		{
			_logger.LogInformation(JsonConvert.SerializeObject(model));
			var response = await _loanApplication.UpdateLoan(id,model);
			_logger.LogInformation(JsonConvert.SerializeObject(response));
			return await Task.FromResult(new JsonResult(response));

		}
	}

}
