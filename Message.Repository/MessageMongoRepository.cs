using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using LendFoundry.Foundation.Persistence.Mongo;
using LendFoundry.Tenant.Client;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Message.Repository
{
    public class MessageMongoRepository : MongoRepository<IMessageDetail, MessageDetail>, IMessageRepository
    {

        static MessageMongoRepository()
        {
            BsonClassMap.RegisterClassMap<MessageDetail>(map =>
            {
                map.AutoMap();
                var type = typeof(MessageDetail);
                map.SetDiscriminator($"{type.FullName}, {type.GetTypeInfo().Assembly.GetName().Name}");
                map.SetIsRootClass(true);
            });
        }

        public MessageMongoRepository(ITenantService tenantService, IMongoConfiguration mongoConfiguration) 
            : base(tenantService, mongoConfiguration, "messages")
        {
            CreateIndexIfNotExists("message-index", 
                Builders<IMessageDetail>.IndexKeys
                    .Ascending(i => i.MessageId)
                    .Ascending(i => i.SentBy));
        }

        public Task<bool> MarkSent(string id)
        {
            // TODO, if it is already marked as 'SENT', error should be thrown
            var updateDef = Builders<IMessageDetail>
                .Update
                .Set(x => x.Status, "SENT")
                .Set(x => x.LastModifiedOn, DateTime.Now);

            Collection.UpdateOne(x => x.MessageId == id, updateDef);

            return Task.FromResult<bool>(true);
        }
    }
}
