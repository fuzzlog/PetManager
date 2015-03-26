using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetManager.Managers;

namespace PetManager.Models
{
    public class ReturnMessage
    {
        public string MessageStatus { get; set; }
        public object Message { get; set; }
    }
}
