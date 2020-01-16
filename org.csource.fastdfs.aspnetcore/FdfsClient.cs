using org.csource.fastdfs.common;

using System;
using System.IO;

namespace org.csource.fastdfs.aspnetcore
{
    public class FdfsClient : IFdfsClient
    {
        private readonly TrackerClient _trackerClient;
        public FdfsClient()
        {
            _trackerClient = new TrackerClient();
        }

        public string Upload(string localFileName, string groupName = "group1")
        {
            var client = GetStorageClient(groupName);
            NameValuePair[] meta_list = null;
            string suffix = localFileName.Substring(localFileName.LastIndexOf('.'));
            string[] fileids = client.upload_file(localFileName, suffix, meta_list);
            var fileid = fileids[1];

#if DEBUG
            Console.WriteLine("Upload local file ok, fileid: " + fileid);
#endif
            return fileid;
        }

        public string Upload(byte[] bytes, string suffix, string groupName = "group1")
        {
            var client = GetStorageClient(groupName);
            NameValuePair[] meta_list = null;
            string[] fileids = client.upload_file(bytes, suffix, meta_list);
            var fileid = fileids[1];

#if DEBUG
            Console.WriteLine("Upload local file ok, fileid: " + fileid);
#endif
            return fileid;
        }

        public bool Modify(byte[] bytes, string appenderFilename, string groupName = "group1")
        {
            var client = GetStorageClient(groupName);
            bool isSuccess = client.modify_file(groupName, appenderFilename, 0, bytes) == 0;
#if DEBUG
            Console.WriteLine("Modify file ok, result: " + (isSuccess ? "success" : "failed"));
#endif
            return isSuccess;
        }

        public bool Modify(string localFilename, string appenderFilename, string groupName = "group1")
        {
            var client = GetStorageClient(groupName);
            bool isSuccess = client.modify_file(groupName, appenderFilename, 0, localFilename) == 0;
#if DEBUG
            Console.WriteLine("Modify file ok, result: " + (isSuccess ? "success" : "failed"));
#endif
            return isSuccess;
        }

        public bool Delete(string remoteFilename, string groupName = "group1")
        {
            var client = GetStorageClient(groupName);
            bool isSuccess = client.delete_file(groupName, remoteFilename) == 0;
#if DEBUG
            Console.WriteLine("Delete file ok, result: " + (isSuccess ? "success" : "failed"));
#endif
            return isSuccess;
        }

        public StorageClient1 GetStorageClient(string groupName = "group1")
        {
            TrackerServer ts = _trackerClient.getTrackerServer();
            if (ts == null)
            {
                throw new Exception("getConnection return null");
            }
            else
            {
                StorageServer ss = _trackerClient.getStoreStorage(ts, groupName);
                if (ss == null)
                {
                    throw new Exception("getStoreStorage return null");
                }
                else
                {
                    StorageClient1 sc1 = new StorageClient1(ts, ss);
                    return sc1;
                }
            }
        }
    }
}
