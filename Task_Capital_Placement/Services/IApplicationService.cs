using Task_Capital_Placement.DTOs;

public interface IApplicationService
{
    Task SubmitApplicationAsync(List<AnswerDTO> answers);
}
