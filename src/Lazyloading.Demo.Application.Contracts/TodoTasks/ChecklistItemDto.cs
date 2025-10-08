using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Lazyloading.Demo.TodoTasks
{
    public class ChecklistItemDto : EntityDto<Guid>
    {
        public string Content { get; set; }
        public bool IsCompleted { get; set; }
    }
}
