using System.Globalization;
using System.Net.Mime;
using CashFlow.Application.UseCases.Expenses.Reports.Excel;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReportController : Controller
{
    [HttpGet("excel")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetExcel(
        [FromServices] IGenerateExpensesReportExcelUseCase useCase,
        [FromQuery] DateTime month)
    {
        byte[] file = await useCase.Execute(month);
        
        if(file.Length > 0)
            return File(file, MediaTypeNames.Application.Octet, "cash-flow-report.xlsx");

        return NoContent();
    }
}