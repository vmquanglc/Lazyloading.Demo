using Lazyloading.Demo.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Lazyloading.Demo.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(DemoEntityFrameworkCoreModule),
    typeof(DemoApplicationContractsModule)
)]
public class DemoDbMigratorModule : AbpModule
{
}
