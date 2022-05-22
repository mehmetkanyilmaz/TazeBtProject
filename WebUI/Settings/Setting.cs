using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace WebUI.Settings
{
    public class Setting
    {
        private IConfiguration _config;
        public static string BaseUrl { get; set; }
        public Setting()
        {
            _config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
        }

        public void GetSetting()
        {
            BaseUrl = _config.GetSection("BaseUrl").Get<string>();
        }
    }
}
