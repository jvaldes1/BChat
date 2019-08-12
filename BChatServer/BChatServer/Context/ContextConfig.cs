using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BChat.Data.Repositories;
using Microsoft.Extensions.Configuration;

namespace BChatServer.Context
{
    public class ContextConfig
    {

        public static void RegisterContext(IConfiguration configuration)
        {
            Repository.ConnectionString = configuration.GetConnectionString("DataConnection");
        }
    }
}
