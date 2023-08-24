namespace ToDoTasks.DAL.Repositories
{
    using ToDoTasks.DAL.Entities;
    using ToDoTasks.DAL.Persistence;
    using ToDoTasks.DAL.Repositories.Interfaces;

    public class ToDoRepository : Repository<ToDo>, IToDoRepository
    {
        public ToDoRepository(ToDoDbContext context)
        : base(context)
        {
        }
    }
}
