using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Message
{
    public interface IMessageService
    {
        Task<IEnumerable<IMessageDetail>> GetAll();
        Task<IMessageDetail> Get(string messageId);
        Task<bool> Add(MessageDetail message);
        Task<bool> Delete(string messageId);
        Task<bool> MarkSent(string messageId);
        Task<bool> Update(string messageId, MessageDetail updatedMessage);
        Task<List<string>> DummyUsers();
    }
}
