namespace ToDoTasks.BLL.Interfaces
{
    using System.Linq.Expressions;
    using ToDoTasks.DAL.Entities;

    public interface IToDoService
    {
        IEnumerable<ToDo> GetAll();

        Task<ToDo> Get(Expression<Func<ToDo, bool>> filter);

        Task Create(ToDo entity);

        Task Delete(int? id);

        Task<ToDo> Update(int? id, ToDo newObj);
    }
}
