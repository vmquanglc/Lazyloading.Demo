using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Lazyloading.Demo.TodoTasks
{
    public class TodoTaskDetailDto : ListTodoTask
    {
        public string Description { get; set; }
        public IReadOnlyList<UploadFileDto> UploadFiles { get; set; } = new List<UploadFileDto>();
        public IReadOnlyList<ChecklistItemDto> ChecklistItems { get; set; } = new List<ChecklistItemDto>();

    }
}
