using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travix.Services.BusinessLogic.Validation;
using Travix.Services.Contracts.Posts;
using Travix.Services.Posts.Api.Controllers;
using Travix.Services.Posts.BusinessLogic.Services;

namespace Travix.Services.Posts.Api.Tests
{
	[TestClass]
	public sealed class PostsControllerTests
	{
		private List<Post> _testData1;

		[TestInitialize]
		public void Initialize()
		{
			_testData1 = new List<Post>()
			{
				new Post(1, "post1", 1, DateTime.Now),
				new Post(2, "post2", 2, DateTime.Now),
				new Post(3, "post3", 3, DateTime.Now)
			};
		}

		private PostsController Setup(List<Post> data)
		{
			Mock<IPostsService> postsService = new Mock<IPostsService>();

			postsService.
				Setup(service => service.GetAsync()).
				ReturnsAsync(data);

			postsService.
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

			return new PostsController(postsService.Object, validationService.Object);
		}

		[TestMethod]
		public async Task GetPostById_ShouldReturnNotFound()
		{
			//Arrange
			PostsController controller = Setup(_testData1);

			//Act
			IActionResult actionResult = await controller.Get(4);

			//Assert
			Assert.IsNotNull(actionResult);
			Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
		}

		[TestMethod]
		public async Task GetPostById_ShouldReturnPost()
		{
			const int id = 1;

			//Arrange
			PostsController controller = Setup(_testData1);

			//Act
			IActionResult actionResult = await controller.Get(id);

			//Assert
			Assert.IsNotNull(actionResult);
			Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));

			object resultObject = ((OkObjectResult)actionResult).Value;
			Assert.IsInstanceOfType(resultObject, typeof(Post));

			Post post = (Post)resultObject;
			Assert.AreEqual(post, _testData1.FirstOrDefault(p => p.Id == id));
		}

		///...
	}
}
