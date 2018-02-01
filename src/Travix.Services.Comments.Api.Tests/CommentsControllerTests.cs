using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travix.Services.BusinessLogic.Validation;
using Travix.Services.Comments.Api.Controllers;
using Travix.Services.Comments.BusinessLogic;
using Travix.Services.Contracts.Comments;

namespace Travix.Services.Comments.Api.Tests
{
	[TestClass]
	public sealed class CommentsControllerTests
	{
		private List<Comment> _testData1;

		[TestInitialize]
		public void Initialize()
		{
			_testData1 = new List<Comment>()
			{
				new Comment(1, "comment1", 1, DateTime.Now) {  PostId = 1},
				new Comment(2, "comment2", 2, DateTime.Now) {  PostId = 2},
				new Comment(3, "comment3", 3, DateTime.Now) {  PostId = 3}
			};
		}

		private CommentsController Setup(List<Comment> data)
		{
			Mock<ICommentsService> commentsService = new Mock<ICommentsService>();

			commentsService.
				Setup(service => service.GetAsync()).
				ReturnsAsync(data);

			commentsService.
				Setup(service => service.GetAsync(It.IsAny<int>())).
				ReturnsAsync((int id) => data.FirstOrDefault(x => x.Id == id));

			Mock<IValidationService> validationService = new Mock<IValidationService>();
			object idValidationError = Resources.Validation.Id_Invalid;
			validationService.
				Setup(service => service.ValidateId(It.IsInRange<int>(Int32.MinValue, 0, Range.Inclusive), out idValidationError)).
				Returns(false);
			object noValidationError = null;
			validationService.
				Setup(service => service.ValidateId(It.IsInRange<int>(1, Int32.MaxValue, Range.Inclusive), out noValidationError)).
				Returns(true);

			Mock<ILogger<CommentsController>> logger = new Mock<ILogger<CommentsController>>();

			return new CommentsController(commentsService.Object, validationService.Object, logger.Object);
		}

		[TestMethod]
		public async Task GetAllCommentsAsync_ShouldReturnAllComments()
		{
			//Arrange
			CommentsController controller = Setup(_testData1);

			//Act
			IActionResult actionResult = await controller.Get();

			//Assert
			Assert.IsNotNull(actionResult);
			Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));

			object resultObject = ((OkObjectResult)actionResult).Value;
			Assert.IsInstanceOfType(resultObject, typeof(List<Comment>));

			List<Comment> comments = (List<Comment>)resultObject;
			Assert.AreEqual(comments.Count, _testData1.Count);
		}

		[TestMethod]
		public async Task GetCommentById_ShouldReturnBadRequest()
		{
			//Arrange
			CommentsController controller = Setup(_testData1);

			//Act
			IActionResult actionResult = await controller.Get(-1);

			//Assert
			Assert.IsNotNull(actionResult);
			Assert.IsInstanceOfType(actionResult, typeof(BadRequestObjectResult));

			object resultObject = ((BadRequestObjectResult)actionResult).Value;
			Assert.IsInstanceOfType(resultObject, typeof(string));

			string validationError = (string)resultObject;
			Assert.AreEqual(validationError, Resources.Validation.Id_Invalid);
		}

		///...
	}
}
