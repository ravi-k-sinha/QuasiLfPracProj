using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Message
{
    public interface IMessageRepository
    {
        Task<IEnumerable<IMessageDetail>> GetAll();
        Task<IMessageDetail> Get(string id);
        Task<bool> Add(MessageDetail item);
        Task<bool> Delete(string id);
        Task<bool> MarkSent(string id);
        Task<bool> Update(string id, MessageDetail updatedMessage);
    }
}
