
using org.csource.fastdfs.encapsulation;

using System;
using System.Text;

namespace org.csource.fastdfs.aspnetcore
{
    public class FdfsBuilder
    {
        public static void Init(FdfsOptions options)
        {
            if (options.TrackerServers == null || options.TrackerServers.Length < 1)
            {
                throw new Exception("trackerservers option error");
            }

            FdfsConfig fdfsConfig = new FdfsConfig();
            fdfsConfig.TrackerServers = options.TrackerServers;

            if (options.AntiStealToken != null)
                fdfsConfig.AntiStealToken = options.AntiStealToken.Value;

            if (!string.IsNullOrWhiteSpace(options.Charset))
                fdfsConfig.Charset = Encoding.GetEncoding(options.Charset);

            if (options.ConnectTimeout != null)
                fdfsConfig.ConnectTimeout = options.ConnectTimeout.Value;

            if (options.NetworkTimeout != null)
                fdfsConfig.NetworkTimeout = options.NetworkTimeout.Value;

            if (options.SecretKey != null)
                fdfsConfig.SecretKey = options.SecretKey;

            if (options.TrackerHttpPort != null)
                fdfsConfig.TrackerHttpPort = options.TrackerHttpPort.Value;

            ClientGlobal.init(fdfsConfig);
        }
    }
}
