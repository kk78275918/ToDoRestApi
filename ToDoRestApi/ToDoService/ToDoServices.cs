using ToDoRestApi.Model;
using ToDoRestApi.Repository;

namespace ToDoRestApi.ToDoService
{
	public class ToDoServices
	{
		private readonly IUnitOfWork _unitOfWork;

		public ToDoServices(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public IEnumerable<ToDoItem> GetAll(int pageIndex, int pageSize)
		{
			return _unitOfWork.ToDoRepository.GetAll()
				.Skip((pageIndex - 1) * pageSize)
				.Take(pageSize);
		}

		public ToDoItem GetById(int id)
		{
			return _unitOfWork.ToDoRepository.GetById(id);
		}

		public void Add(ToDoItem todo)
		{
			_unitOfWork.ToDoRepository.Insert(todo);
			_unitOfWork.Save();
		}

		public void Update(ToDoItem todo)
		{
			_unitOfWork.ToDoRepository.Update(todo);
			_unitOfWork.Save();
		}

		public void Delete(int id)
		{
			_unitOfWork.ToDoRepository.Delete(id);
			_unitOfWork.Save();
		}
	}
}
