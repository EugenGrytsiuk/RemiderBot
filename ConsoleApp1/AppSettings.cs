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

            string friendListFileName = ConfigurationManager.AppSettings["FriendList.FileNeme"] ;
            FriendListPath = Path.Combine(Apppath, friendListFileName);

            string savedUserMess = ConfigurationManager.AppSettings["SavedMessages.FileName"];
            SavedMessagesPath = Path.Combine(Apppath, savedUserMess);

            var phJson = System.IO.File.ReadAllText(System.IO.Path.Combine(Apppath, "phrases.json"));
            Phrases = JsonConvert.DeserializeObject<BotPhrases>(phJson);

        }
        public static string BotToken { get; internal set; } = ConfigurationManager.AppSettings["BotToken"];

        public static string FriendListPath { get; private set; }

        public static string SavedMessagesPath { get; private set; }

        public static BotPhrases Phrases { get; }

    }
}
