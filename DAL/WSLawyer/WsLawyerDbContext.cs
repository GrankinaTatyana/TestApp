using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.WSLawyer
{
    public partial class WsLawyerDbContext : DbContext
    {
        public WsLawyerDbContext()
        {
        }

        public WsLawyerDbContext(DbContextOptions<WsLawyerDbContext> options)
            : base(options)
        {
        }

     
        public virtual DbSet<Case> Case { get; set; }
     
        public virtual DbSet<ColumnList> ColumnList { get; set; }
      
        public virtual DbSet<Document> Document { get; set; }
       
        public virtual DbSet<DocumentCase> DocumentCase { get; set; }
      
      
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
       
        public virtual DbSet<SubjectCase> SubjectCase { get; set; }
       
        public virtual DbSet<Task> Task { get; set; }
       
        public virtual DbSet<User> User { get; set; }
       
        public virtual DbSet<UserRole> UserRole { get; set; }
      


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

  
            modelBuilder.Entity<Case>(entity =>
            {
               

                entity.HasIndex(e => new { e.StatusCategory,  e.UserIdleader})
                   ;

                entity.HasIndex(e => new { e.Id, e.FinansComeIntoForce})
                 ;

            
            });

     
  
            modelBuilder.Entity<ColumnList>(entity =>
            {
              

                entity.Property(e => e.ColumnName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);


                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TableName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

              
            });


            modelBuilder.Entity<Document>(entity =>
            {
              
                entity.HasIndex(e => new { e.Id, e.DateDoc, e.NumberDoc })
            ;
                
                entity.Property(e => e.NumberDoc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                   ;

             
            });


            modelBuilder.Entity<DocumentCase>(entity =>
            {


                entity.Property(e => e.DateCreate);
                   
                    

                entity.Property(e => e.DateUpdate)
                   
                  ;

               
            });


            modelBuilder.Entity<Role>(entity =>
            {
             

                entity.Property(e => e.Desc)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

        

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasIndex(e => new { e.ColumnListId, e.Value })
                   
                    .IsUnique();

                entity.HasIndex(e => new { e.Name, e.ColumnListId, e.Value })
                 
                    .IsUnique();

                entity.HasIndex(e => new { e.Name, e.NameSecond, e.NotEdited, e.NotVisible, e.RefValue, e.Value, e.ColumnListId })
                 ;


                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.NameSecond)
                    .HasMaxLength(500)
                    .IsUnicode(false);

              
            });

            modelBuilder.Entity<Subject>(entity =>
            {
             

                entity.Property(e => e.BirthDate);

                entity.Property(e => e.BirthPlace)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

              
              

                entity.Property(e => e.Inn)
                    .IsRequired()
                  
                    .HasMaxLength(20)
                    .IsUnicode(false)
                   ;

             
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Ogrn)
                    .IsRequired()
                    
                    .HasMaxLength(20)
                    .IsUnicode(false)
                  ;

               

                entity.Property(e => e.PassNumber)
                    .HasMaxLength(500)
                    .IsUnicode(false);

              

                entity.Property(e => e.Snils)
                  
                    .HasMaxLength(11)
                    .IsUnicode(false);

             ;

            
            });

           

           

            

               
      

           
          

            modelBuilder.Entity<Task>(entity =>
            {
                entity.HasIndex(e => e.CaseId);

                entity.HasIndex(e => new { e.CaseId})
                   ;

           

                entity.HasIndex(e => new { e.Id, e.StatusType, e.DateEndFact })
                   
                    .IsUnique();

                entity.HasIndex(e => new { e.Id, e.UserIdexecutor, e.Status, e.CaseId, e.StatusType, e.BeginDate, e.OnConfirmation })
                   ;

                entity.HasIndex(e => new { e.BeginDate, e.CaseId,  e.DateEndPlan, e.OnConfirmation, e.StatusType, e.UserIdexecutor, e.Status })
                   ;

                entity.HasIndex(e => new { e.BeginDate, e.DateCompletion, e.DateCreate, e.DateEndFact, e.DateEndPlan, e.DateUpdate,  e.Level, e.OnConfirmation, e.SpentTime, e.Status,  e.StatusType,e.TaskResult, e.TaskTarget, e.UserIdcreator, e.UserIdupdate, e.CaseId, e.UserIdexecutor })
                  ;

                entity.Property(e => e.Id);

                entity.Property(e => e.BeginDate);

                entity.Property(e => e.CaseId);

              

                entity.Property(e => e.DateCreate)
                  
                  ;

                entity.Property(e => e.DateEndFact)
                   
                    ;

                entity.Property(e => e.DateEndPlan)
                  
                   ;

                entity.Property(e => e.DateUpdate)
                   ;

             

                entity.Property(e => e.TaskResult)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                   ;

                entity.Property(e => e.TaskTarget)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);


                entity.HasOne(d => d.Case)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.CaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                  ;

             

            });


            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Login)
                  
                    .IsUnique();


               

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

              

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash).HasMaxLength(32);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

              

               
            });


            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasIndex(e => new { e.UserId, e.RoleId })
                   ;

                entity.Property(e => e.Id);

                entity.Property(e => e.RoleId);

                entity.Property(e => e.UserId);

                entity.HasOne(d => d.User)
                   ;
            });

        
        
           
        }
    }
}
