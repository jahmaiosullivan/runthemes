using System.Configuration;
using AutoMapper;
using Microsoft.WindowsAzure.Storage;
using WhiteLabel.Data.Azure;
using WhiteLabel.Data.Azure.Base;
using WhiteLabel.Data.Dapper;
using WhiteLabel.Data.Repositories;

namespace WhiteLabel.Business.Configuration
{
    public class CoreRegistry : StructureMap.Configuration.DSL.Registry
    {
        public CoreRegistry()
        {
            Scan(s =>
            {
                s.TheCallingAssembly();
                s.AssembliesFromApplicationBaseDirectory(f => (f.FullName.Contains("RunThemes")));
                s.WithDefaultConventions();
            });

            if (ConfigurationManager.ConnectionStrings["StorageConnectionString"] != null)
                For<ICloudClientWrapper>().Use<CloudClientWrapper>().Ctor<CloudStorageAccount>("storageAccount").Is(CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString));
            For<IImageRepository>().Use<ImageBlobRepository>();
            For<IMappingEngine>().Use(x => Mapper.Engine);
            For<ITableStorageRepository<ImageInfo>>().Use<ImageInfoRepository>();
            For<ITableStorageRepository<BetaUser>>().Use<BetaUserRepository>();
            For<IQueryManager>().Use<SqlQueryManager>();
        }
    }
}
