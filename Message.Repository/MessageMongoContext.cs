using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace Message.Repository
{
    class MessageMongoContext
    {
        public IMongoDatabase _db;
        private string localMongoUrl = "mongodb://localhost:27017";

        public MessageMongoContext()
        {
            var client = new MongoClient(localMongoUrl);
            if (client != null)
            {
                _db = client.GetDatabase("Message1Db");
            }
        }

        public IMongoCollection<MessageDetail> Items
        {
            get
            {
                return _db.GetCollection<MessageDetail>("messages");
            }
        }
    }
}
