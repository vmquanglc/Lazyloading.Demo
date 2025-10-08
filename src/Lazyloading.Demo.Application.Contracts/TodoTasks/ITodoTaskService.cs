using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;

namespace Lazyloading.Demo.TodoTasks
{
    public interface ITodoTaskService
    {
        Task<TodoTaskDetailDto> GetAsync(Guid id);
        Task<List<ListTodoTask>> GetListAsync();
        Task<TodoTaskUploadFileResultDto> UploadFileAsync(Guid todoTaskId, IRemoteStreamContent file);
        Task<IRemoteStreamContent> DownloadFileAsync(DownloadFileTodoTaskRequestDto input);
    }
}
