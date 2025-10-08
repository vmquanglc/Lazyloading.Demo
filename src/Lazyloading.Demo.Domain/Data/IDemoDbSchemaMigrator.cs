using System.Threading.Tasks;

namespace Lazyloading.Demo.Data;

public interface IDemoDbSchemaMigrator
{
    Task MigrateAsync();
}
