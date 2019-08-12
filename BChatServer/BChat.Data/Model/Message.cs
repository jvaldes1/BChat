using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Newtonsoft.Json;

namespace BChat.Data.Model
{
    public class Message
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty()]
        public int Id { get; set; }
        [JsonProperty()]
        public string Content { get; set; }
        [JsonProperty()]
        public DateTime Timestamp { get; set; }
        [JsonProperty()]
        public string User { get; set; }
    }
}
