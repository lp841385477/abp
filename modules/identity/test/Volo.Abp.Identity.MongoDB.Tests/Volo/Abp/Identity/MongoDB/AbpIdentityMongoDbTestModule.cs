﻿using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.MongoDB;

namespace Volo.Abp.Identity.MongoDB
{
    [DependsOn(
        typeof(AbpIdentityTestBaseModule),
        typeof(AbpPermissionManagementMongoDbModule),
        typeof(AbpIdentityMongoDbModule)
        )]
    public class AbpIdentityMongoDbTestModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var connectionString = MongoDbFixture.ConnectionString.EnsureEndsWith('/') +
                                   "Db_" +
                                    Guid.NewGuid().ToString("N");

            Configure<AbpDbConnectionOptions>(options =>
            {
                options.ConnectionStrings.Default = connectionString;
            });
        }
    }
}
