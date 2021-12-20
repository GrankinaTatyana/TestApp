
using DAL.WSLawyer;
using DAL.WSLawyer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Task = System.Threading.Tasks.Task;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        //сюда добавляем все наши контексты из всех БД

        private readonly WsLawyerDbContext _wsLawyerDbContext;

        
        private readonly string _epApiHostBaseUrl;
       

        public UnitOfWork(WsLawyerDbContext wsLawyerDbContext
           )
        {
      
            _wsLawyerDbContext = wsLawyerDbContext;
         
        }
        //фабрика репозиториев

        
        public ICaseRepository CaseRepository => new CaseRepository(_wsLawyerDbContext);
      
        public ITaskRepository TaskRepository => new TaskRepository(_wsLawyerDbContext);
    
        public async Task SaveChangesAsync()
        {
            using (var tran = _wsLawyerDbContext.Database.BeginTransaction())
            {
                try
                {
                    await _wsLawyerDbContext.SaveChangesAsync();

                   
                    tran.Commit();
                }
                catch (Exception e)
                {
                    tran.Rollback();
                  
                  
                }
            }
        }

        public void SaveChanges()
        {
            //здесь надо понять,какой контекст главнее,и если что-то не сохранилось в главном,то и в другом откатывать

            using (var tran = _wsLawyerDbContext.Database.BeginTransaction())
            {
                try
                {
                    _wsLawyerDbContext.SaveChanges();

                    

                    tran.Commit();
                }
                catch (Exception e)
                {
                    tran.Rollback();
                   
                }
            }
        }

        public const int SqlServerViolationOfUniqueIndex = 2601;
        public const int SqlServerViolationOfUniqueConstraint = 2627;

       

        private static readonly Regex UniqueConstraintRegex =
            new Regex("'UniqueError_([a-zA-Z0-9]*)_([a-zA-Z0-9]*)'", RegexOptions.Compiled);

     

        #region destructor

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {

                //здесь может быть добавлен еще один контекст

                _wsLawyerDbContext?.Dispose();
            }

            _disposed = true;
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

        #endregion
    }
}
