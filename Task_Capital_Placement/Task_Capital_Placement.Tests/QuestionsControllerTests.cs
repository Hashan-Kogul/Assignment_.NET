using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using Task_Capital_Placement.Controllers;
using Task_Capital_Placement.DTOs;
using Task_Capital_Placement.Services;

namespace Task_Capital_Placement.Tests
{
    public class QuestionsControllerTests
    {
        private readonly Mock<IQuestionService> _questionServiceMock;
        private readonly QuestionsController _controller;

        public QuestionsControllerTests()
        {
            _questionServiceMock = new Mock<IQuestionService>();
            _controller = new QuestionsController(_questionServiceMock.Object);
        }

        [Fact]
        public async Task CreateQuestion_ShouldReturnOk()
        {
            // Arrange
            var question = new QuestionDTO { Id = "1", QuestionText = "Sample Question", QuestionType = "Paragraph" };

            // Act
            var result = await _controller.CreateQuestion(question);

            // Assert
            var okResult = Assert.IsType<OkResult>(result);
            _questionServiceMock.Verify(service => service.CreateQuestionAsync(question), Times.Once);
        }

        [Fact]
        public async Task GetQuestions_ShouldReturnOkWithQuestions()
        {
            // Arrange
            var questions = new List<QuestionDTO>
            {
                new QuestionDTO { Id = "1", QuestionText = "Sample Question 1", QuestionType = "Paragraph" },
                new QuestionDTO { Id = "2", QuestionText = "Sample Question 2", QuestionType = "YesNo" }
            };
            _questionServiceMock.Setup(service => service.GetQuestionsAsync()).ReturnsAsync(questions);

            // Act
            var result = await _controller.GetQuestions();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<QuestionDTO>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }
    }
}
