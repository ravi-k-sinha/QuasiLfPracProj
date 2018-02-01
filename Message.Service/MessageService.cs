using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Message.Service
{
    public class MessageService : IMessageService
    {

        IMessageRepository Repository;

        public MessageService(IMessageRepository repository)
        {
            this.Repository = repository;
        }

        public async Task<bool> Add(MessageDetail message)
        {
            await Task.Run(() => Repository.Add(message));
            return true;
        }

        public async Task<bool> Delete(string messageId)
        {
            var message = await Get(messageId);
            await Task.Run(() => Repository.Remove(message));
            return true;
        }

        public async Task<IMessageDetail> Get(string messageId)
        {
            return await Repository.Get(messageId);
        }

        public async Task<IEnumerable<IMessageDetail>> GetAll()
        {
            return await Repository.All(x => x.MessageId != null);
        }

        public async Task<bool> MarkSent(string messageId)
        {
            return await Repository.MarkSent(messageId);
        }

        public async Task<bool> Update(string messageId, MessageDetail updatedMessage)
        {
            await Task.Run(() => Repository.Update(updatedMessage));
            return true;
        }
    }
}
