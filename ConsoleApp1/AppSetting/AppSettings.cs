using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    public static class AppSettings
    {
        
        static AppSettings()
        {   
            string Apppath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        }
        public static string BotToken { get; internal set; } = ConfigurationManager.AppSettings["BotToken"];

        //public static string FriendListPath { get; private set; }

        //public static string SavedMessagesPath { get; private set; }

      

    }
}
