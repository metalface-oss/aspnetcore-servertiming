<p align="center">
  <img alt="" src="https://user-images.githubusercontent.com/102076/52376950-23627380-2a6c-11e9-83d3-86085c3b3653.png"/>
</p>
<h1 align="center">Server-Timing response header<br/>for ASP.NET Core</h1>
<p align="center">
  Enables a server to communicate performance metrics about the request-response cycle to the user agent using<br/>Server-Timing response header as specified in https://www.w3.org/TR/server-timing
</p>
<p align="center">
      <img alt="" src="https://travis-ci.org/metalface-oss/aspnetcore-servertiming.svg?branch=master"/>
</p>
<div align="center">
  <sub>Built with ❤︎ by 
  <a href="https://www.metalface.com">Metalface</a> and
  <a href="https://github.com/metalface-oss/aspnetcore-servertiming/graphs/contributors">
    contributors
  </a>
  </sub>
  <br/><br/>
</div>
  
## Table of Contents
[Overview](#overview)    
[Getting Started](#getting-started)    
[Basic Usage](#basic-usage)    
[Advanced Usage](#advanced-usage)    
[Integrations](#integrations)    
[License](#license)    

## Overview
Sometimes we need to know how long does it take to generate a page or API response, or we are interested in learning how much time are we spending in a heavy process such as complex database query or connecting to an external server. Few of us may even remember the ```This page was generated in 0.112358 seconds``` text, proudly displayed at the bottom of the page.
Now, in 2019, we are doing that in more advanced way, because we want to:    

⚡&nbsp; See server-side metrics in [Chrome DevTools Timing](https://developers.google.com/web/tools/chrome-devtools/network-performance/resource-loading#view_network_timing) tab in addition to client-side metrics.    
⚡&nbsp; Use server timings in [Postman tests](https://learning.getpostman.com/docs/postman/scripts/test_scripts) instead of response times, which are affected by network.    
⚡&nbsp; Pass server timings to web analytics service, like Google Analytics.    
⚡&nbsp; Display the ```This page was generated in 0.112358 seconds``` text on your website. Just kidding (or not really?).

<br/>

![image](https://user-images.githubusercontent.com/102076/52399644-83393880-2ac5-11e9-9b0b-42b713e5fea1.png)

![image](https://user-images.githubusercontent.com/102076/52399698-a7951500-2ac5-11e9-9269-d01a0ce2b8ed.png)

## Getting Started
You can install the library as a [Nuget package](https://www.nuget.org/packages/Metalface.AspNetCore.ServerTiming) into your project from Visual Studio editor by searching for ```Metalface.AspNetCore.ServerTiming``` package or by using .NET CLI:

```batchfile
dotnet add package Metalface.AspNetCore.ServerTiming
```

## Basic Usage
If you are just starting, you only need to register a middleware in your project's ```Startup.cs``` file:

```csharp
using Metalface.AspNetCore.ServerTiming;
```
```csharp
public IServiceProvider ConfigureServices(IServiceCollection services)
{
  services.AddServerTiming(); 
  ...
}

public void Configure(IApplicationBuilder app)
{
  app.UseServerTiming(); 
  ...
}
```

That's all you need to do for the ```Total``` metric to show up in Chrome DevTools.

## Advanced Usage
If the ```Total``` metric is not enough, it is easy to return more custom metrics to the client.
The recorder, responsible for creating custom metrics, may be injected in your controller:

```csharp
using Metalface.AspNetCore.ServerTiming;
```
```csharp
public class HomeController : Controller
{
   private readonly IServerTimingRecorder recorder;
   
   public HomeController(IServerTimingRecorder recorder)
   {
     this.recorder = recorder;
   }
   
   public IActionResult Index()
   {
     this.recorder.BeginRecord("my-custom-metric");
     ...
     this.recorder.EndRecord();
     
     return this.View();
   }
}
```

The recorder will measure execution time of any code, placed between ```BeginRecord``` and ```EndRecord``` methods and return it as a  metric to the client:

![image](https://user-images.githubusercontent.com/102076/52399547-48cf9b80-2ac5-11e9-883f-88b392409c2a.png)

## Integrations
Postman test:
```js
pm.test('Server performance is acceptable', () => {
    let header = postman.getResponseHeader('Server-Timing');
    pm.expect(header).not.eql(undefined);
    
    let pattern = /total;(?:desc=[^;]*;)?dur=([\d]+)/i;
    let duration = parseFloat(header.match(pattern)[1]);
    pm.expect(duration).to.be.below(200);
});
```

## License
This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.


[Scroll back to top](#js-repo-pjax-container) and star us ★ - it helps! ❤︎
