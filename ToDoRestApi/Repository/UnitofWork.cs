using ToDoRestApi.DataContext;
using ToDoRestApi.Model;

namespace ToDoRestApi.Repository
{
	
	public interface IUnitOfWork : IDisposable
	{
		ToDoIRepository<ToDoItem> ToDoRepository { get; }
		void Save();
	}
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ToDoDbContext _context;
		private ToDoIRepository<ToDoItem> _toDoRepository;

		public UnitOfWork(ToDoDbContext context)
		{
			_context = context;
		}

		public ToDoIRepository<ToDoItem> ToDoRepository
		{
			get
			{
				return _toDoRepository ??= new ToDoRepository<ToDoItem>(_context);
			}
		}

		public void Save()
		{
			_context.SaveChanges();
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}
