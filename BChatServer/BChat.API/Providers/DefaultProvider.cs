using System;
using System.Collections.Generic;
using System.Text;
using BChat.API.Proxies;

namespace BChat.API.Providers
{
    public class DefaultProvider
    {
        public static IRepository GetDefaultRepository()
        {
            return new ProxyRepository();
        }

    }
}
