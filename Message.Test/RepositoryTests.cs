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
            // Currently Dont know how to create tests in LF framework
            //repository = new MessageMongoRepository();
        }

        [Fact]
        public void TestAddMessage()
        {
            repository.Add(GetDefaultMessage());
            
            Assert.True(true);
        }

        [Fact]
        public void TestDeleteMessage()
        {
            repository.Remove(GetDefaultMessage());
            Assert.True(true);
        }

        MessageDetail GetDefaultMessage()
        {
            return new MessageDetail
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
        }
    }
}
