using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GroupMeHodor.GroupMe
{
    public interface IGroupMeMessenger
    {
        string BotId { get; }
        string BotName { get; }
        string[] IgnoreNames { get; }

        bool SendMessage(string message);
    }
}
