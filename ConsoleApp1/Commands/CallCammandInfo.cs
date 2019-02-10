namespace ConsoleApp1.Commands
{
    public class CallCammandInfo
    {
        public string Command { get; set; }
        public string CommandDescription { get; set; }

        public CallCammandInfo(string command)
        {
            Command = command;
        }
        public CallCammandInfo(string command, string commandDescription)
        {
            Command = command;
            CommandDescription = commandDescription;
        }

    }
}