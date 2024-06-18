using Task_Capital_Placement.DTOs;
using Task_Capital_Placement.Models;
using Task_Capital_Placement.Repository;

public class ApplicationService : IApplicationService
{
    private readonly ICosmosDbService _cosmosDbService;

    public ApplicationService(ICosmosDbService cosmosDbService)
    {
        _cosmosDbService = cosmosDbService;
    }

    public async Task SubmitApplicationAsync(List<AnswerDTO> answers)
    {
        var application = new Application
        {
            Id = Guid.NewGuid().ToString(),
            Answers = answers.Select(a => new Answer
            {
                QuestionId = a.QuestionId,
                AnswerText = a.AnswerText
            }).ToList()
        };

        await _cosmosDbService.AddItemAsync(application);
    }
}
