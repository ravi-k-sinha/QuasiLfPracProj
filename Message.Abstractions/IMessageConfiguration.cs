using System;
using System.Collections.Generic;
using System.Text;

namespace Message
{
    public interface IMessageConfiguration
    {
        string[] AllowedRoles { get; set; }
    }
}
