
using Lazyloading.Demo.TodoTasks;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace Lazyloading.Demo
{
    public class TodoTaskDataSeederContributor
    : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<TodoTask, Guid> _todoTaskRepository;

        public TodoTaskDataSeederContributor(IRepository<TodoTask, Guid> bookRepository)
        {
            _todoTaskRepository = bookRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            var tasks = new List<TodoTask>();

            if (await _todoTaskRepository.GetCountAsync() > 0) return;
            var random = new Random();
            var statuses = Enum.GetValues<TodoTaskStatus>();
            int indexStartMaster = 1;
            int maxTodoTask = random.Next(15, 20); ;
            while (indexStartMaster <= maxTodoTask) // 30 tasks
            {
                var startDate = DateTime.Now.AddDays(random.Next(-10, 0));
                var endDate = startDate.AddDays(random.Next(1, 10));

                var task = new TodoTask(
                    id: Guid.NewGuid(),
                    title: $"Công việc số {indexStartMaster}",
                    description: $"Mô tả cho công việc {indexStartMaster}",
                    status: statuses[random.Next(statuses.Length)],
                    startDate: startDate,
                    endDate: endDate
                );

                // checklist 10-20 items
                int checklistCount = random.Next(10, 15);
                int indexStartDetail = 1;
                while (indexStartDetail <= checklistCount)
                {
                    task.AddChecklistItem(new ChecklistItem(
                        id: Guid.NewGuid(),
                        task.Id,
                        $"Check list cần làm số {indexStartDetail}",
                        random.NextDouble() > 0.5
                    ));
                    indexStartDetail++;
                }

                indexStartMaster++;
                tasks.Add(task);
            }
            await _todoTaskRepository.InsertManyAsync(tasks, autoSave: true);
        }
    }
}
