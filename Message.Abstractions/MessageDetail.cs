using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;

namespace Message
{
    public class MessageDetail : IMessageDetail
    {
        [BsonId]
        public string MessageId { get; set; }

        public string tenantId { get; set; }
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
