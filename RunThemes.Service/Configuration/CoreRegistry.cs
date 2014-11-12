using System.Configuration;
using AutoMapper;
using Microsoft.WindowsAzure.Storage;
using RunThemes.Data.Azure;
using RunThemes.Data.Azure.Base;
using RunThemes.Data.Dapper;
using RunThemes.Data.Repositories;
using StructureMap.Graph;

namespace RunThemes.Business.Configuration
{
    public class CoreRegistry : StructureMap.Configuration.DSL.Registry
    {
        public CoreRegistry()
        {
            Scan(s =>
            {
                s.TheCallingAssembly();
                s.AssembliesFromApplicationBaseDirectory(f => (f.FullName.Contains("RunThemes") || f.FullName.Contains("NearForums")));
                s.WithDefaultConventions();
            });

            if (ConfigurationManager.ConnectionStrings["StorageConnectionString"] != null)
                For<ICloudClientWrapper>().Use<CloudClientWrapper>().Ctor<CloudStorageAccount>("storageAccount").Is(CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString));
            For<IImageRepository>().Use<ImageBlobRepository>();
            For<IMappingEngine>().Use(x => Mapper.Engine);
            For<ITableStorageRepository<ImageInfo>>().Use<ImageInfoRepository>();
            For<IQueryManager>().Use<SqlQueryManager>();
        }
    }
}
