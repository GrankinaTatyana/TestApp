using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace DAL.WSLawyer.Repositories
{
    public interface ITaskRepository
    {
        System.Threading.Tasks.Task AddAsync(Task entity);
        Task GetTaskById(long taskId);
        long? GetTaskExecutor(int taskid);
        string GetTaskResultByTaskId(int taskid);
        DateTime? GetDateExecution(int taskId);
     
    
      
     
      
        Task<Status> GetTaskByName(string name);
      
    }

    public class TaskRepository : Repository<Task>, ITaskRepository
    {
        private WsLawyerDbContext _lawyerDbContext;

        public TaskRepository(WsLawyerDbContext context) : base(context)
        {
            _lawyerDbContext = context;
        }

        public Task GetTaskById(long taskId)
        {
            return _lawyerDbContext.Task.FirstOrDefault(x => x.Id == taskId);
        }

        public long? GetTaskExecutor(int taskid)
        {
            return _lawyerDbContext.Task.FirstOrDefault(x => x.Id == taskid).UserIdexecutor;
        }

        public string GetTaskResultByTaskId(int taskid)
        {
            var task = _lawyerDbContext.Task.FirstOrDefault(x => x.Id == taskid);
            if (task != null)
                return task.TaskResult;
            return null;
        }

        public async Task<Status> GetTaskByName(string name)
        {
            var task = await _lawyerDbContext.Status
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ColumnListId == 202 && x.Name.Contains(name));
            return task;
        }


        public DateTime? GetDateExecution(int taskId)
        {

            return _lawyerDbContext.Task.FirstOrDefault(x => x.Id == taskId).DateCompletion;
        }

       
    }
}
