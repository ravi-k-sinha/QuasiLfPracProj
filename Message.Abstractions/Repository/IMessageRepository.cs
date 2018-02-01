using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LendFoundry.Foundation.Persistence;

namespace Message
{
    public interface IMessageRepository : IRepository<IMessageDetail>
    {
        Task<bool> MarkSent(string id);        
    }
}
