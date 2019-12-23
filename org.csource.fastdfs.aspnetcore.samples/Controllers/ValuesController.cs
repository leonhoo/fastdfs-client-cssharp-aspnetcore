using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace org.csource.fastdfs.aspnetcore.samples.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        // 3
        private readonly IFdfsClient _fdfsClient;

        public ValuesController(IFdfsClient fdfsClient)
        {
            _fdfsClient = fdfsClient;
        }

        [HttpPost]
        public string Post()
        {
            IFormFile file = null;
            if (Request.HasFormContentType)
            {
                file = Request.Form.Files.FirstOrDefault();
            }

            if (file != null)
            {
                byte[] data;
                using (var stream = new MemoryStream())
                {
                    file.CopyTo(stream);
                    data = stream.ToArray();
                }
                // 4
                return _fdfsClient.Upload(data, ".jpg");
            }
            return null;
        }
    }
}
