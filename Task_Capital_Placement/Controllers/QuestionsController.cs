using Microsoft.AspNetCore.Mvc;
using Task_Capital_Placement.DTOs;
using Task_Capital_Placement.Services;

[ApiController]
[Route("api/[controller]")]
public class QuestionsController : ControllerBase
{
    private readonly IQuestionService _questionService;

    public QuestionsController(IQuestionService questionService)
    {
        _questionService = questionService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateQuestion([FromBody] QuestionDTO question)
    {
        await _questionService.CreateQuestionAsync(question);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateQuestion(string id, [FromBody] QuestionDTO question)
    {
        await _questionService.UpdateQuestionAsync(id, question);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetQuestions()
    {
        var questions = await _questionService.GetQuestionsAsync();
        return Ok(questions);
    }
}
