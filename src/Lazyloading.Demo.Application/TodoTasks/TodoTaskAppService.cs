using Lazyloading.Demo.Permissions;
using Lazyloading.Demo.TodoTasks;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace Lazyloading.Demo.Books;

public class TodoTaskAppService : ApplicationService, ITodoTaskService
{

    private readonly ITodoTaskRepository _todoTaskRepo;
    public TodoTaskAppService(ITodoTaskRepository todoTaskRepo)
    {
        _todoTaskRepo = todoTaskRepo;
    }
    public async Task<TodoTaskUploadFileResultDto> UploadFileAsync(Guid todoTaskId, IRemoteStreamContent file)
    {
        using var memoryStream = new MemoryStream();
        using Stream fs = file.GetStream();
        fs.CopyTo(memoryStream);
        var data = memoryStream.ToArray();

        var isOk = await _todoTaskRepo.AddUploadFileTotoTask(todoTaskId, file.FileName, file.ContentType, memoryStream.Length, memoryStream.ToArray());
        return new TodoTaskUploadFileResultDto()
        {
            FileName = file.FileName,
            FileType = file.ContentType,
            FileSize = memoryStream.Length
        };
    }
    public async Task<IRemoteStreamContent> DownloadFileAsync(DownloadFileTodoTaskRequestDto input)
    {
        var file = await _todoTaskRepo.GetUploadFile(input.todoTaskId, input.todoTaskUploadFileId);
        if (file == null) return null;
        var stream = new MemoryStream(file.Content);

        return new RemoteStreamContent(stream, file.FileName, file.FileType);
    }
    public async Task<TodoTaskDetailDto> GetAsync(Guid id)
    {

        var todoTask = await _todoTaskRepo.GetTodoTask(id);
        if (todoTask == null) return null;
        return new TodoTaskDetailDto()
        {
            Id = todoTask.Id,
            Title = todoTask.Title,
            Status = todoTask.Status,
            StartDate = todoTask.StartDate,
            EndDate = todoTask.EndDate,
            Description = todoTask.Description,
            ChecklistItems = todoTask.ChecklistItems
                    .Select(c => new ChecklistItemDto { Id = c.Id, Content = c.Content, IsCompleted = c.IsCompleted })
                    .ToList(),
            UploadFiles = todoTask.UploadFiles
                    .Select(f => new UploadFileDto { Id = f.Id, FileName = f.FileName, FileType = f.FileType, FileSize = f.FileSize })
                    .ToList()
        };
    }
    public async Task<List<ListTodoTask>> GetListAsync()
    {

        return await _todoTaskRepo.GetListTodoTask() ?? new List<ListTodoTask>();
        //AutoMapper.AutoMapperMappingException: 'Missing type map configuration or unsupported mapping.'
        //return new PagedResultDto<ListTodoTask>(
        //    todoTask.Count,
        //    ObjectMapper.Map<List<TodoTask>, List<ListTodoTask>>(todoTask)
        //);
    }
 
}

