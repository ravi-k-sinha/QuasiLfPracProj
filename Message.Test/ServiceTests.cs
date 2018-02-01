using System;
using System.Collections.Generic;
using System.Text;
using Message.Repository;
using Message.Service;
using Xunit;

namespace Message.Test
{
    public class ServiceTests
    {
        [Fact]
        public void TestAddMessage()
        {
            MessageDetail message = new MessageDetail
            {
                MessageId = "1",
                Subject = "First Message",
                Body = "Body for First Message",
                TenantId = "FirstTenant",
                SentBy = "user1",
                SentTo = new List<string> { "user2", "user3" },
                CreatedOn = DateTime.Now,
                LastModifiedOn = DateTime.Now,
                SentOn = DateTime.Now,
                Status = "DRAFT"
            };

            // Currently Dont know how the repository can be tested in LF framework
            //var repository = new MessageMongoRepository();
            //var service = new MessageService(repository);

            //var result = service.Add(message);

            //result.Wait();
            //Assert.True(result.Result);
        }
    }
}
