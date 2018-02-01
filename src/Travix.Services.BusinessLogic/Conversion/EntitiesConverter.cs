using AutoMapper;

namespace Travix.Services.BusinessLogic.Conversion
{
	public class EntitiesConverter : IEntitiesConverter
	{
		private readonly IMapper _mapper;

		public EntitiesConverter(IMapper mapper)
		{
			_mapper = mapper;
		}

		public TModel ConverBack<TObject, TModel>(TObject @object)
		{
			return _mapper.Map<TModel>(@object);
		}

		public TObject Convert<TModel, TObject>(TModel model)
		{
			return _mapper.Map<TObject>(model);
		}
	}
}
