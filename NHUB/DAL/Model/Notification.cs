using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Notification
    {
        public int SourceId { get; set; }
        public string SourceName { get; set; }
        public int Eventid { get; set; }
        public string EventName { get; set; }
        public int  ChannelId{ get; set; }
        public int ChannelName { get; set; }
        public bool Confidential { get; set; }
        public bool Mandetory { get; set; }
    }
}
