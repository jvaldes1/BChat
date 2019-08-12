using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using BChat.Data.EntityFramework;
using BChat.Data.Model;
using Microsoft.Extensions.Configuration;

namespace BChat.Data.Repositories
{
    public class Repository
    {
        public static string ConnectionString = "";
        private static int Limit = 50;
        public static List<Message> GetMessages()
        {
            using (var dbContext = new BasicContext(ConnectionString))
            {
                return dbContext.Messages.OrderByDescending(x=> x.Timestamp).Take(Limit).OrderBy( x => x.Timestamp).ToList();
            }
        }

        public static Result AddMessage(Message message)
        {
            try
            {
                using (var dbContext = new BasicContext(ConnectionString))
                {
                    dbContext.Messages.Add(message);
                    dbContext.SaveChanges();
                }
                
                return new Result(){ Status = true};
            }
            catch (Exception e)
            {
                return new Result()
                {
                    Status = false,
                    OutputMessage = e.Message
                };
            }
        }
    }
}
