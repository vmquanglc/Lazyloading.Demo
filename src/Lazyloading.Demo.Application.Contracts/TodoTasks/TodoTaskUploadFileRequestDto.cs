using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Content;

namespace Lazyloading.Demo.TodoTasks
{
    public class TodoTaskUploadFileRequestDto
    {
        public Guid TodoTaskId { get; set; }
        public IRemoteStreamContent File { get; set; }
    }
}
