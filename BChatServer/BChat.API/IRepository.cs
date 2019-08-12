using System;
using System.Collections.Generic;
using BChat.API.Proxies;
using BChat.Data.Model;

namespace BChat.API
{
    public interface IRepository
    {
        string GetCsvMessages();

        Result AddMessage(Message message);

        Result AddMessage(string command);

    }
}
