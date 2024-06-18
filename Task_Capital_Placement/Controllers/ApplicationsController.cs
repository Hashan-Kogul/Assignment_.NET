using Microsoft.AspNetCore.Mvc;
using YourProjectName.DTOs;
using YourProjectName.Services;

[ApiController]
[Route("api/[controller]")]
public class ApplicationsController : ControllerBase
{
    private readonly IApplicationService _applicationService;

    public ApplicationsController(IApplicationService applicationService)
    {
        _applicationService = applicationService;
    }

    [HttpPost]
    public async Task<IActionResult> SubmitApplication([FromBody] List<AnswerDTO> answers)
    {
        await _applicationService.SubmitApplicationAsync(answers);
        return Ok();
    }
}
