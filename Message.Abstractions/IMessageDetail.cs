using System;
using System.Collections.Generic;
using LendFoundry.Foundation.Persistence;

namespace Message
{
    public interface IMessageDetail : IAggregate
    {
        string MessageId { get; set; }

        string Subject { get; set; }
        string Body { get; set; }
        DateTime CreatedOn { get; set; }
        DateTime LastModifiedOn { get; set; }
        DateTime SentOn { get; set; }
        string Status { get; set; }
        string SentBy { get; set; }
        List<string> SentTo { get; set; }
    }
}
