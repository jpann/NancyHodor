﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GroupMeHodor.GroupMe
{
    public class GroupMeMessage
    {
        public string name { get; set; }
        public string user_id { get; set; }
        public string text { get; set; }
        public string group_id { get; set; }
        public string id { get; set; }
        public string source_guid { get; set; }
        public double created_at { get; set; }
        public string avatar_url { get; set; }
        public bool system { get; set; }

        public DateTime created_date
        {
            get
            {
                DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                DateTime created_date = origin.AddSeconds(this.created_at);

                return created_date;
            }
        }
    }
}
