# fastdfs-client-cssharp-aspnetcore
fastdfs client extensions for asp.netcore

Please visit:
https://github.com/leonhoo/fastdfs-client-cssharp


1. install package 
```
Install-Package org.csource.fastdfs.aspnetcore -Version 1.28.0
```
2. append appsettings.json 
```
"Fastdfs": {
    "TrackerServers": [ "<SERVER IP>:<SERVER PORT>" ], //required, for example: ["192.168.1.100:22122","192.168.1.200:22122"]
    "ConnectTimeout": 2,
    "NetworkTimeout": 30,
    "Charset": "UTF-8",
    "AntiStealToken": false,
    "SecretKey": "FastDFS1234567890",
    "TrackerHttpPort": 8080,
    "ConnectionPoolEnabled": true,
    "ConnectionPoolMaxCountPerEntry": 500,
    "ConnectionPoolMaxIdleTime": 3600,
    "ConnectionPoolMaxWaitTime": 1000
},
```
3. add service
```
public void ConfigureServices(IServiceCollection services)
{
    // using org.csource.fastdfs.aspnetcore;
    services.AddFdfs(Configuration.GetSection("Fastdfs")); 

    //...
}
```
4. use
```
private readonly IFdfsClient _client;

public HomeController(IFdfsClient client)
{
    _client = client;
}

[HttpPost]
public string Upload(IFormFile file)
{
    using (var stream = new MemoryStream())
    {
        file.CopyTo(stream);
        var data = stream.ToArray();
        var url = _client.Upload(data, ".jpg");
        return url;
    }
}
```

