using System;
using System.Collections.Generic;
using System.Text;

namespace org.csource.fastdfs.aspnetcore
{
    public interface IFdfsClient
    {
        string Upload(string localFileName, string groupName = "group1");

        string Upload(byte[] bytes, string suffix, string groupName = "group1");
    }
}
