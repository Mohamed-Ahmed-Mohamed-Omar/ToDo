using ToDo_Zaher.Data.Entity;
using ToDo_Zaher.Model;

namespace ToDo_Zaher.Services
{
    public interface IToDoRep
    {
        Task<IQueryable<ToDoVM>> Get();
        Task<ToDoVM> GetById(int id);
        Task Add(ToDoVM toDoVM);
        Task Update(ToDoVM toDoVM);
        Task Delete(ToDoVM data);
    }
}
