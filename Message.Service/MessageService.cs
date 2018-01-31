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
            return await Repository.Add(message);
        }

        public async Task<bool> Delete(string messageId)
        {
            return await Repository.Delete(messageId);
        }

        public async Task<IMessageDetail> Get(string messageId)
        {
            return await Repository.Get(messageId);
        }

        public async Task<IEnumerable<IMessageDetail>> GetAll()
        {
            return await Repository.GetAll();
        }

        public async Task<bool> MarkSent(string messageId)
        {
            return await Repository.MarkSent(messageId);
        }

        public async Task<bool> Update(string messageId, MessageDetail updatedMessage)
        {
            return await Repository.Update(messageId, updatedMessage);
        }
    }
}
