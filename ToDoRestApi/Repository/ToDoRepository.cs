using Microsoft.EntityFrameworkCore;
using ToDoRestApi.DataContext;
using ToDoRestApi.Model;

namespace ToDoRestApi.Repository
{
	
	public class ToDoRepository<T> : ToDoIRepository<T> where T : BaseEntity
	{
		private readonly ToDoDbContext _context;
		private DbSet<T> entities;

		public ToDoRepository(ToDoDbContext context)
		{
			_context = context;
			entities = _context.Set<T>();
		}

		public T GetById(int id)
		{
			return entities.Find(id);
		}

		public IEnumerable<T> GetAll()
		{
			return entities.ToList();
		}

		public void Insert(T entity)
		{
			entities.Add(entity);
			_context.SaveChanges();
		}

		public void Update(T entity)
		{
			entities.Update(entity);
			_context.SaveChanges();
		}

		public void Delete(int id)
		{
			var entity = entities.Find(id);
			if (entity != null)
			{
				entities.Remove(entity);
				_context.SaveChanges();
			}
		}
	}
}