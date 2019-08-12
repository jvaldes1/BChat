using System;
using System.Collections.Generic;
using System.Text;
using BChat.Data.Model;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace BChat.API.Proxies
{
    /// <summary>
    /// Class used to validate and parse a command
    /// </summary>
    public class CommandBuilder
    {
        private string _command;
        public CommandBuilder(string command)
        {
            _command = command;
        }

        /// <summary>
        /// Validates the command has the format: /stock=stock_code
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            var array = _command.Split("=");
            if (array.Length == 2 && array[0] == "/stock")
            {
                return true;
            }

            return false;
        }

        public Message GetMessage()
        {
            if (IsValid())
            {
                var array = _command.Split("=");
                return new Message()
                {
                    Content = array[1],
                    User = "Bot",
                    Timestamp = DateTime.Now
                };
            }

            throw new Exception("Invalid command");
            
        }


    }
}
