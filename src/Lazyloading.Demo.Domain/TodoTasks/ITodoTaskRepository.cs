using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Content;

namespace Lazyloading.Demo.TodoTasks
{
    public interface ITodoTaskRepository
    {
        Task<UploadFile> GetUploadFile(Guid todoTaskId, Guid uploadFileId);
        Task<TodoTask> GetTodoTask(Guid id);
        Task<List<ListTodoTask>> GetListTodoTask();
        Task<bool> AddUploadFileTotoTask(Guid todoTaskId, string fileName, string fileType, long fileSize, byte[] content);

    }
}
