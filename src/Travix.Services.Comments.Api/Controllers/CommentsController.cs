using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Travix.Services.BusinessLogic.Validation;
using Travix.Services.Comments.BusinessLogic;
using Travix.Services.Contracts.Comments;
using Travix.Services.Core.Formats;
using Travix.Services.Core.Routing;

namespace Travix.Services.Comments.Api.Controllers
{
	[Route(Routes.DefaultWithVersion)]
	[ApiVersion(Routes.Versioning.DefaultVersion)]
	[Produces(MediaTypes.Json)]
	[Consumes(MediaTypes.Json)]
	public class CommentsController : Controller
	{
		private readonly ICommentsService _commentsService;
		private readonly IValidationService _validationService;
		private readonly ILogger<CommentsController> _logger;

		public CommentsController(ICommentsService commentsService, IValidationService validationService, ILogger<CommentsController> logger)
		{
			_commentsService = commentsService;
			_validationService = validationService;
			_logger = logger;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			_logger.LogInformation("Get All Items");

			return Ok(await _commentsService.GetAsync());
		}

		[HttpGet(Routes.Id)]
		public async Task<IActionResult> Get([Required]int id)
		{
			_logger.LogInformation("Getting item {0}", id);

			if (!_validationService.ValidateId(id, out object error))
			{
				_logger.LogWarning("Identifier {0} is not valid", id);
				return BadRequest(error);
			}

			Comment comment = await _commentsService.GetAsync(id);
			if (comment == null)
			{
				_logger.LogWarning("Item with ID = {0} not found", id);
				return NotFound();
			}


			return Ok(comment);
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody]Comment comment)
		{
			if (!_validationService.ValidateModel(ModelState, out object error))
			{
				return BadRequest(error);
			}

			await _commentsService.InsertAsync(comment);
			return Ok();
		}

		[HttpPut(Routes.Id)]
		public async Task<IActionResult> Put([Required]int id, [FromBody]Comment comment)
		{
			if (!_validationService.ValidateId(id, out object error))
			{
				return BadRequest(error);
			}
			if (!_validationService.ValidateModel(ModelState, out object modelError))
			{
				return BadRequest(modelError);
			}
			if (await _commentsService.GetAsync(id) == null)
			{
				return NotFound();
			}

			await _commentsService.UpdateAsync(comment);
			return Ok();
		}

		[HttpDelete(Routes.Id)]
		public async Task<IActionResult> Delete([Required]int id)
		{
			if (!_validationService.ValidateId(id, out object error))
			{
				return BadRequest(error);
			}
			if (await _commentsService.GetAsync(id) == null)
			{
				return NotFound();
			}

			await _commentsService.DeleteAsync(id);
			return Ok();
		}
	}
}
