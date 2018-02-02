using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LendFoundry.Security.Identity.Client;
using System.Linq;

namespace Message.Service
{
    public class MessageService : IMessageService
    {

        IMessageRepository Repository;

        private IIdentityService IdentityService { get; }

        public MessageService(IMessageRepository repository, IIdentityService identityService)
        {
            this.Repository = repository;
            this.IdentityService = identityService;
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

        public async Task<List<string>> DummyUsers()
        {
            var users = await IdentityService.GetRoleMembers("UBSPortal");

            return users.Select(x => x.Name).ToList();
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
