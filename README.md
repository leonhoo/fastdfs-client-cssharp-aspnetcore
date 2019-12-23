# fastdfs-client-cssharp-aspnetcore
fastdfs client extensions for asp.netcore

1. append appsettings.json 
```
"Fastdfs": {
  "TrackerServers": ["<SERVER IP1>:<SERVER PORT1>","<SERVER IP2>:<SERVER PORT2>"], //required, for example: ["192.168.1.100:22122"]
  "ConnectTimeout": null,
  "NetworkTimeout": null,
  "Charset": null,
  "AntiStealToken": null,
  "SecretKey": null,
  "TrackerHttpPort": null
},
```
2. add service
```
public void ConfigureServices(IServiceCollection services)
{
    // using org.csource.fastdfs.aspnetcore;
    services.AddFdfs(Configuration.GetSection("Fastdfs")); 

    //...
}
```
3. use
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

