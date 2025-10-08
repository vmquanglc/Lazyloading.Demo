using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Lazyloading.Demo.TodoTasks
{
    public class UploadFileDto : EntityDto<Guid>
    {
        public Guid TodoTaskId { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public long FileSize { get; set; }

    }
}
