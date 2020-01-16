using org.csource.fastdfs.common;
using System;
using System.Collections.Generic;
using System.Text;

namespace org.csource.fastdfs.aspnetcore
{
    public interface IFdfsClient
    {
        string Upload(string localFileName, string groupName = "group1");
        string Upload(byte[] bytes, string suffix, string groupName = "group1");
        bool Modify(byte[] bytes, string appenderFilename, string groupName = "group1");
        bool Modify(string localFilename, string appenderFilename, string groupName = "group1");
        bool Delete(string remoteFilename, string groupName = "group1");

        StorageClient1 GetStorageClient(string groupName = "group1");
    }
}
