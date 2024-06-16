using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;
using CashFlow.Communications.Responses;
using CashFlow.Exception;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
	[HttpPost]
	public IActionResult Register([FromBody] RequestRegisterExpenseJson request)
	{
		try
		{
			var useCase = new RegisterExpenseUseCase();

			var response = useCase.Execute(request);

			return Created(string.Empty, response);
		}
		catch (ErrorOnValidationException ex)
		{
			var errorResponse = new ResponseErrorJson(ex.Errors);
			return BadRequest(errorResponse);
		}
		catch
		{
			var errorResponse = new ResponseErrorJson("Unknown error");
			return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
		}
	}
}