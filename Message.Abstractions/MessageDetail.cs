using System;
using System.Collections.Generic;
using System.Text;
using LendFoundry.Foundation.Persistence;
using MongoDB.Bson.Serialization.Attributes;

namespace Message
{
    public class MessageDetail : Aggregate, IMessageDetail
    {
        public string MessageId { get; set; }

        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public DateTime SentOn { get; set; }
        public string Status { get; set; }
        public string SentBy { get; set; }
        public List<string> SentTo { get; set; }
    }
}
