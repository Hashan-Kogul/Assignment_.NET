namespace Task_Capital_Placement.DTOs
{
    public class QuestionDTO
    {
        public string Id { get; set; }
        public string QuestionText { get; set; }
        public string QuestionType { get; set; } // Paragraph, YesNo, Dropdown, etc.
        public List<string> Options { get; set; } // For Dropdown and MultipleChoice
    }
}