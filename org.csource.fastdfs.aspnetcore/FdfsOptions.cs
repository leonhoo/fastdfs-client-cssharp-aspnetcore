using System.Text;

namespace org.csource.fastdfs.aspnetcore
{
    public class FdfsOptions
    {
        /// <summary>
        /// connect timeout
        /// </summary>
        public int? ConnectTimeout { get; set; }
        /// <summary>
        /// network timeout
        /// </summary>
        public int? NetworkTimeout { get; set; }
        /// <summary>
        /// charset
        /// </summary>
        public string Charset { get; set; }
        /// <summary>
        /// anti steal token
        /// </summary>
        public bool? AntiStealToken { get; set; }
        /// <summary>
        /// token secret key
        /// </summary>
        public string SecretKey { get; set; }
        /// <summary>
        /// tracker http port
        /// </summary>
        public int? TrackerHttpPort { get; set; } = 80;
        /// <summary>
        /// FastDFS Tracker Servers, Required
        /// </summary>
        public string[] TrackerServers { get; set; }
    }
}
