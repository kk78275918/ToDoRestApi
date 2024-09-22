namespace ToDoRestApi.Model
{
	public class ToDoItem : BaseEntity
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public bool IsCompleted { get; set; }
	}
}
