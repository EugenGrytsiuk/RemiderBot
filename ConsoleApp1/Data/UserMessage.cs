using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1
{
    public class UserMessage
    {
        [Key]
        public int Id { get; set; }
        public int TelegramId { get; set; }
        public string UserMessages  { get; set; }
        public int MessageId { get; set; }
    }
}
