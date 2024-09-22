using ToDoRestApi.Model;

namespace ToDoRestApi.Repository
{
	
	public interface ToDoIRepository<T> where T : BaseEntity
	{
		T GetById(int id);
		IEnumerable<T> GetAll();
		void Insert(T entity);
		void Update(T entity);
		void Delete(int id);
	}
}
