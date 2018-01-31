using System;
using System.Collections.Generic;
using Message.Repository;
using Xunit;

namespace Message.Test
{
    public class RepositoryTests
    {
        [Fact]
        public void TestAddMessage()
        {
            MessageDetail message = new MessageDetail();

            message.MessageId = "1";
            message.Subject = "First Message";
            message.TenantId = "FirstTenant";
            message.SentBy = "user1";
            message.SentTo = new List<string>{"user2", "user3"};
            message.CreatedOn = DateTime.Now;
            message.LastModifiedOn = DateTime.Now;
            message.SentOn = DateTime.Now;
            message.Status = "DRAFT";

            var repository = new MessageMongoRepository();
            var result = repository.Add(message);

            result.Wait();
            Assert.True(result.Result);
        }
    }
}
