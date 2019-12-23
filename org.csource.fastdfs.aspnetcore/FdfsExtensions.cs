using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;

namespace org.csource.fastdfs.aspnetcore
{
    /// <summary>
    /// 
    /// </summary>
    public static class FdfsExtensions
    {
        /// <summary>
        /// 添加FASTDFS
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddFdfs(this IServiceCollection services, IConfiguration section)
        {
            var options = section.Get<FdfsOptions>();
            FdfsBuilder.Init(options);
            services.AddSingleton<IFdfsClient, FdfsClient>();
            return services;
        }
    }
}
