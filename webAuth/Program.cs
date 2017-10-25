using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Server.HttpSys;

namespace webAuth
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var env = Environment.GetEnvironmentVariable("WEB_SERVER");
      if (env == "httpsys")
      {
        BuildHttpSysHost(args).Run();
      }
      else
      {
        BuildWebHost(args).Run();
      }
    }

    public static IWebHost BuildHttpSysHost(string[] args) =>
       WebHost.CreateDefaultBuilder(args)
           .UseStartup<Startup>()
           .UseHttpSys(options =>
           {
             options.Authentication.Schemes = AuthenticationSchemes.Negotiate | AuthenticationSchemes.NTLM;
             options.Authentication.AllowAnonymous = true;
             options.UrlPrefixes.Add("http://+:80/");
           })
           .Build();

    public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .UseIISIntegration()
            .Build();
  }
}
