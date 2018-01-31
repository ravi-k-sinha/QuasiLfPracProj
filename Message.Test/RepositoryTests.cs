using System;
using System.Collections.Generic;
using Message.Repository;
using Xunit;

namespace Message.Test
{
    public class RepositoryTests
    {

        MessageMongoRepository repository;

        public RepositoryTests()
        {
            repository = new MessageMongoRepository();
        }

        [Fact]
        public void TestAddMessage()
        {
            MessageDetail message = new MessageDetail
            {
                MessageId = "1",
                Subject = "First Message",
                TenantId = "FirstTenant",
                SentBy = "user1",
                SentTo = new List<string> { "user2", "user3" },
                CreatedOn = DateTime.Now,
                LastModifiedOn = DateTime.Now,
                SentOn = DateTime.Now,
                Status = "DRAFT"
            };

            var result = repository.Add(message);

            result.Wait();
            Assert.True(result.Result);
        }

        [Fact]
        public void TestDeleteMessage()
        {
            var result = repository.Delete("1");
            result.Wait();
            Assert.True(result.Result);
        }
    }
}
