using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.Program;

namespace ConsoleApp1
{
    public partial class Service1 : ServiceBase
    {
        Main2 main2 = new Main2();
        SenderSheduler sheduler = new SenderSheduler();
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            sheduler.Star();
            main2.RunBot();
                   
        }


        protected override void OnStop()
        {
            main2.Stop();
        }
    }
}
