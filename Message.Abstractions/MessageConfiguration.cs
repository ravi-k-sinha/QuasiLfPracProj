﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Message
{
    public class MessageConfiguration : IMessageConfiguration
    {
        public string[] AllowedRoles { get; set; }
    }
}
