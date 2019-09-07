using System;
using System.Collections.Generic;
using System.Text;

namespace Physio.Service.Models
{
    public class EmailModel
    {
        public string Address { get; set; }
        public string MailFrom { get; set; }
        public string MailTo { get; set; }
        public string Description { get; set; }
        public string Subject { get; set; }
 
    }
}
