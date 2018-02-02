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
        private IMessageConfiguration Configuration { get; }

        public MessageService(IMessageRepository repository, IIdentityService identityService, IMessageConfiguration configuration)
        {
            this.Repository = repository;
            this.IdentityService = identityService;
            this.Configuration = configuration;
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

        public Task<List<string>> GetConfiguration()
        {
            return Task.Run(() => Configuration.AllowedRoles.ToList());            
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
