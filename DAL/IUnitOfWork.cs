

using DAL.WSLawyer.Repositories;
using System;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUnitOfWork : IDisposable
    {
             
        ICaseRepository CaseRepository { get; }
        ITaskRepository TaskRepository { get; }
      
        Task SaveChangesAsync();
        void SaveChanges();
    }
}
