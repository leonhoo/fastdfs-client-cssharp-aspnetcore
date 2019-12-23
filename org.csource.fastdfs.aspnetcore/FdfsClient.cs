using org.csource.fastdfs.common;

using System;

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
            return Proc(groupName, o =>
           {
               NameValuePair[] meta_list = null;
               string suffix = localFileName.Substring(localFileName.LastIndexOf('.'));
               string[] fileids = o.upload_file(localFileName, suffix, meta_list);
               return fileids;
           });
        }

        public string Upload(byte[] bytes, string suffix, string groupName = "group1")
        {
            return Proc(groupName, o =>
           {
               NameValuePair[] meta_list = null;
               string[] fileids = o.upload_file(bytes, suffix, meta_list);
               return fileids;
           });
        }

        private string Proc(string groupName, Func<StorageClient1, string[]> action)
        {
            TrackerServer ts = _trackerClient.getConnection();
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

                    string[] fileids = action.Invoke(sc1);
                    var fileid = fileids[1];
#if DEBUG
                    Console.WriteLine("Upload local file ok, fileid: " + fileid);
#endif
                    return fileid;
                }
            }
        }
    }
}
