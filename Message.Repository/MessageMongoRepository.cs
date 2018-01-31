using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Message.Repository
{
    public class MessageMongoRepository : IMessageRepository
    {

        MessageMongoContext ctx;

        public MessageMongoRepository()
        {
            ctx = new MessageMongoContext();
        }

        public Task<bool> Add(MessageDetail message)
        {
            ctx.Messages.InsertOne(message);
            return Task.FromResult<bool>(true);
        }

        public Task<bool> Delete(string id)
        {
            ctx.Messages.DeleteOne(x => x.MessageId == id);
            return Task.FromResult<bool>(true);
        }

        public Task<IMessageDetail> Get(string id)
        {
            var result = ctx.Messages.Find(i => i.MessageId == id).First();

            return Task.FromResult<IMessageDetail>(result);
        }

        public Task<IEnumerable<IMessageDetail>> GetAll()
        {
            var result = ctx.Messages.Find(_ => true).ToList();

            return Task.FromResult<IEnumerable<IMessageDetail>>(result);
        }

        public Task<bool> MarkSent(string id)
        {
            // TODO, if it is already marked as 'SENT', error should be thrown
            var updateDef = Builders<MessageDetail>
                .Update
                .Set(x => x.Status, "SENT")
                .Set(x => x.LastModifiedOn, DateTime.Now);

            ctx.Messages.UpdateOne(x => x.MessageId == id, updateDef);

            return Task.FromResult<bool>(true);
        }

        public Task<bool> Update(string id, MessageDetail updatedMessage)
        {
            ctx.Messages.ReplaceOne(x => x.MessageId == id, updatedMessage);
            return Task.FromResult<bool>(true);
        }
    }
}
