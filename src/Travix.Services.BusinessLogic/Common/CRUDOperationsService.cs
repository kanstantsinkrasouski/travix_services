using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travix.Services.BusinessLogic.Conversion;
using Travix.Services.Contracts;
using Travix.Services.DataAccess.Models;
using Travix.Services.DataAccess.Repository;

namespace Travix.Services.BusinessLogic.Common
{
	public class CRUDOperationsService<TObject, TModel> : ICRUDOperationsService<TObject, TModel>
		where TObject : class, IDataObject, new()
		where TModel : class, IEntity, new()
	{
		protected readonly IEntitiesConverter _converter;
		protected readonly IRepository<TModel> _repository;

		public CRUDOperationsService(IEntitiesConverter entitiesConverter, IRepository<TModel> repository)
		{
			_converter = entitiesConverter;
			_repository = repository;
		}

		public void Delete(int id)
		{
			_repository.Delete(id);
		}

		public async Task DeleteAsync(int id)
		{
			await _repository.DeleteAsync(id);
		}

		public List<TObject> Get()
		{
			List<TModel> model = _repository.Get();
			return model.Select(m => _converter.Convert<TModel, TObject>(m)).ToList();
		}

		public TObject Get(int id)
		{
			TModel model = _repository.Get(id);
			return _converter.Convert<TModel, TObject>(model);
		}

		public async Task<List<TObject>> GetAsync()
		{
			List<TModel> model = await _repository.GetAsync();
			return model.Select(m => _converter.Convert<TModel, TObject>(m)).ToList();
		}

		public async Task<TObject> GetAsync(int id)
		{
			TModel model = await _repository.GetAsync(id);
			return _converter.Convert<TModel, TObject>(model);
		}

		public void Insert(TObject item)
		{
			TModel model = _converter.ConverBack<TObject, TModel>(item);
			_repository.Insert(model);
		}

		public async Task InsertAsync(TObject item)
		{
			TModel model = _converter.ConverBack<TObject, TModel>(item);
			await _repository.InsertAsync(model);
		}

		public void Update(TObject item)
		{
			TModel model = _converter.ConverBack<TObject, TModel>(item);
			_repository.Update(model);
		}

		public async Task UpdateAsync(TObject item)
		{
			TModel model = _converter.ConverBack<TObject, TModel>(item);
			await _repository.UpdateAsync(model);
		}
	}
}
