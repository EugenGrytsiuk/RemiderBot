using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ToLog
    {
        public async void WriteToLog(string data, object time, string username, int userId)
        {
            try
            {
                using (StreamWriter fstream = new StreamWriter(@"C:\Temp\log.txt",true, Encoding.Default))
                {
                    //char[] input = Convert.ToChar(data);

                    await fstream.WriteAsync($"recive {time} from {username} id {userId}: {data}\n");
                    //fstream.Write(data, 0, data.Length);
                    
                }
            }
            catch(Exception e)
            {
                using (StreamWriter fstream = new StreamWriter(@"C:\Temp\log.txt", true, Encoding.Default))
                {
                    await fstream.WriteAsync(e.Message);
                }
                  
            }
        }
    }
}
