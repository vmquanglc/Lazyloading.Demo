using AutoMapper.Internal.Mappers;
using Lazyloading.Demo.EntityFrameworkCore;
using Lazyloading.Demo.TodoTasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Lazyloading.Demo.TodoTaskRepo
{
    public class TodoTaskRepository : EfCoreRepository<DemoDbContext, TodoTask, Guid>, ITodoTaskRepository
    {
        public TodoTaskRepository(
            IDbContextProvider<DemoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        public async Task<bool> AddUploadFileTotoTask(Guid todoTaskId, string fileName, string fileType, long fileSize, byte[] content)
        {
            var queryable = await GetQueryableAsync();
            var todoTask = queryable
                .Where(t => t.Id == todoTaskId).FirstOrDefault();
            if (todoTask == null) return false;
            todoTask.AddUploadFile(fileName, fileType, fileSize, content);
            // Lưu thay đổi vào DB
            //var dbContext = await GetDbContextAsync();
            //await dbContext.SaveChangesAsync();
            return true;

        }
        public async Task<List<ListTodoTask>> GetListTodoTask()
        {
            //var result = new List<ListTodoTask>();
            //var queryable = await GetQueryableAsync();
            //var todoTasks = await AsyncExecuter.ToListAsync(queryable);
            //foreach (var todo in todoTasks)
            //{
            //    result.Add(new ListTodoTask()
            //    {
            //        Id = todo.Id,
            //        Title = todo.Title,
            //        Status = todo.Status,
            //        StartDate = todo.StartDate,
            //        ChecklistCount = todo.ChecklistItems.Count,
            //        UploadFileCount = todo.UploadFiles.Count
            //    });
            //}
            //return result;


            var queryable = await GetQueryableAsync();
            return await AsyncExecuter.ToListAsync(
                queryable
                .Select(t => new ListTodoTask()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Status = t.Status,
                    StartDate = t.StartDate,
                    ChecklistCount = t.ChecklistItems.Count,
                    UploadFileCount = t.UploadFiles.Count
                })
            );
        }

        public async Task<TodoTask> GetTodoTask(Guid id)
        {
            var queryable = await GetQueryableAsync();
            var todoTaskDetail = queryable
                .Where(t => t.Id == id)
                .Include(t => t.UploadFiles)
                .Include (t => t.ChecklistItems).FirstOrDefault();
            return todoTaskDetail;
        }

        public async Task<UploadFile> GetUploadFile(Guid todoTaskId, Guid uploadFileId)
        {
            var query = await GetQueryableAsync();
            var todoTask = await query.Include(t => t.UploadFiles)   // Eager load UploadFiles
            .FirstOrDefaultAsync(t => t.Id == todoTaskId);
            if (todoTask == null) return null;

            var file = todoTask.UploadFiles.FirstOrDefault(_ => _.Id == uploadFileId);
            return file;
        }
    }
}
