using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Message.Repository
{
    public class MessageMongoRepository : IMessageRepository
    {
        public Task<bool> Add(MessageDetail item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IMessageDetail> Get(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IMessageDetail>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> MarkSent(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(string id, MessageDetail updatedMessage)
        {
            throw new NotImplementedException();
        }
    }
}
