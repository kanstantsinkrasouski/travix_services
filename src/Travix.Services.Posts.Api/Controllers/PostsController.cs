using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Travix.Services.BusinessLogic.Validation;
using Travix.Services.Contracts.Posts;
using Travix.Services.Core.Formats;
using Travix.Services.Core.Routing;
using Travix.Services.Posts.BusinessLogic.Services;

namespace Travix.Services.Posts.Api.Controllers
{
	[Route(Routes.DefaultWithVersion)]
	[ApiVersion(Routes.Versioning.DefaultVersion)]
	[Produces(MediaTypes.Json)]
	[Consumes(MediaTypes.Json)]
	public class PostsController : Controller
	{
		private readonly IPostsService _postsService;
		private readonly IValidationService _validationService;

		public PostsController(IPostsService postsService, IValidationService validationService)
		{
			_postsService = postsService;
			_validationService = validationService;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			return Ok(await _postsService.GetAsync());
		}

		[HttpGet(Routes.Id)]
		public async Task<IActionResult> Get([Required]int id)
		{
			if (!_validationService.ValidateId(id, out object error))
			{
				return BadRequest(error);
			}

			Post post = await _postsService.GetAsync(id);
			if (post == null)
				return NotFound();

			return Ok(post);
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody]Post post)
		{
			if (!_validationService.ValidateModel(ModelState, out object error))
			{
				return BadRequest(error);
			}

			await _postsService.InsertAsync(post);
			return Ok();
		}

		[HttpPut(Routes.Id)]
		public async Task<IActionResult> Put([Required]int id, [FromBody]Post post)
		{
			if (!_validationService.ValidateId(id, out object error))
			{
				return BadRequest(error);
			}
			if (!_validationService.ValidateModel(ModelState, out object modelError))
			{
				return BadRequest(modelError);
			}
			if (await _postsService.GetAsync(id) == null)
			{
				return NotFound();
			}

			await _postsService.UpdateAsync(post);
			return Ok();
		}

		[HttpDelete(Routes.Id)]
		public async Task<IActionResult> Delete([Required]int id)
		{
			if (!_validationService.ValidateId(id, out object error))
			{
				return BadRequest(error);
			}
			if (await _postsService.GetAsync(id) == null)
			{
				return NotFound();
			}

			await _postsService.DeleteAsync(id);
			return Ok();
		}
	}
}