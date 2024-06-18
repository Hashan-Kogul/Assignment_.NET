using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Xunit;
using Task_Capital_Placement.DTOs;
using Task_Capital_Placement.Models;
using Task_Capital_Placement.Repository;
using Task_Capital_Placement.Services;

namespace Task_Capital_Placement.Tests
{
    public class QuestionServiceTests
    {
        private readonly Mock<ICosmosDbService> _cosmosDbServiceMock;
        private readonly IQuestionService _questionService;

        public QuestionServiceTests()
        {
            _cosmosDbServiceMock = new Mock<ICosmosDbService>();
            _questionService = new QuestionService(_cosmosDbServiceMock.Object);
        }

        [Fact]
        public async Task CreateQuestionAsync_ShouldAddQuestion()
        {
            // Arrange
            var question = new QuestionDTO { Id = "1", QuestionText = "Sample Question", QuestionType = "Paragraph" };

            // Act
            await _questionService.CreateQuestionAsync(question);

            // Assert
            _cosmosDbServiceMock.Verify(db => db.AddItemAsync(It.IsAny<Question>()), Times.Once);
        }

        [Fact]
        public async Task GetQuestionsAsync_ShouldReturnQuestions()
        {
            // Arrange
            var questions = new List<Question>
            {
                new Question { Id = "1", QuestionText = "Sample Question 1", QuestionType = "Paragraph" },
                new Question { Id = "2", QuestionText = "Sample Question 2", QuestionType = "YesNo" }
            };
            _cosmosDbServiceMock.Setup(db => db.GetItemsAsync<Question>()).ReturnsAsync(questions);

            // Act
            var result = await _questionService.GetQuestionsAsync();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("Sample Question 1", result[0].QuestionText);
        }
    }
}
