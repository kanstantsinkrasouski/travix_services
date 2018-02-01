using AutoMapper;
using DAL = Travix.Services.DataAccess;
using DTO = Travix.Services.Contracts;

namespace Travix.Services.Posts.Api
{
	public class DefaultConversionProfile : Profile
	{
		public DefaultConversionProfile()
			: base()
		{
			CreateMap<DTO.Posts.Post, DAL.Models.Post>();
			CreateMap<DTO.Comments.Comment, DAL.Models.Comment>();
			CreateMap<DAL.Models.Post, DTO.Posts.Post>();
			CreateMap<DAL.Models.Comment, DTO.Comments.Comment>();
		}
	}
}
