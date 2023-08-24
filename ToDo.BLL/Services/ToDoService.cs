namespace ToDoTasks.BLL.Services
{
    using System.Linq.Expressions;
    using ToDoTasks.BLL.Interfaces;
    using ToDoTasks.DAL.Entities;
    using ToDoTasks.DAL.Repositories.Interfaces;

    public class ToDoService : IToDoService
    {
        private const string notFound = "Error: Nothing found";
        private const string notValid = "Error: Nor valid data";
        private readonly IToDoRepository _repository;

        public ToDoService(IToDoRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<ToDo> GetAll()
        {
            IEnumerable<ToDo> result = _repository.GetAll();
            if (result.Count() <= 0)
            {
                throw new Exception(notFound);
            }

            return result;
        }

        public async Task<ToDo> Get(Expression<Func<ToDo, bool>> filter)
        {
            ToDo todo = await _repository.Get(filter);
            if (todo == null)
            {
                throw new Exception(notFound);
            }

            return todo;
        }

        public async Task Create(ToDo entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(notValid);
            }

            ToDo obj = await _repository.Get(u => u.Id == id);
            if (obj == null)
            {
                throw new Exception(notFound);
            }

            await _repository.Delete(obj);
        }

        public async Task<ToDo> Update(int? id, ToDo newObj)
        {
            if (id == null)
            {
                throw new ArgumentNullException(notValid);
            }

            ToDo obj = await _repository.Get(u => u.Id == id);
            if (obj == null || newObj == null)
            {
                throw new Exception(notFound);
            }

            obj.Title = newObj.Title;
            obj.Description = newObj.Description;
            obj.ToDoState = newObj.ToDoState;

            await _repository.Update(obj);
            return obj;
        }
    }
}
