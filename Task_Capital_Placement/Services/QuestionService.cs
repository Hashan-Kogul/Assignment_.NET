using Task_Capital_Placement.DTOs;
using Task_Capital_Placement.Models;
using Task_Capital_Placement.Repository;

public class QuestionService : IQuestionService
{
    private readonly ICosmosDbService _cosmosDbService;

    public QuestionService(ICosmosDbService cosmosDbService)
    {
        _cosmosDbService = cosmosDbService;
    }

    public async Task CreateQuestionAsync(QuestionDTO question)
    {
        var model = new Question
        {
            Id = question.Id,
            QuestionText = question.QuestionText,
            QuestionType = question.QuestionType,
            Options = question.Options
        };

        await _cosmosDbService.AddItemAsync(model);
    }

    public async Task UpdateQuestionAsync(string id, QuestionDTO question)
    {
        var model = new Question
        {
            Id = id,
            QuestionText = question.QuestionText,
            QuestionType = question.QuestionType,
            Options = question.Options
        };

        await _cosmosDbService.UpdateItemAsync(id, model);
    }

    public async Task<List<QuestionDTO>> GetQuestionsAsync()
    {
        var items = await _cosmosDbService.GetItemsAsync<Question>();
        return items.Select(item => new QuestionDTO
        {
            Id = item.Id,
            QuestionText = item.QuestionText,
            QuestionType = item.QuestionType,
            Options = item.Options
        }).ToList();
    }
}
