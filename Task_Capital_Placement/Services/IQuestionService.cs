using Task_Capital_Placement.DTOs;

public interface IQuestionService
{
    Task CreateQuestionAsync(QuestionDTO question);
    Task UpdateQuestionAsync(string id, QuestionDTO question);
    Task<List<QuestionDTO>> GetQuestionsAsync();
}
