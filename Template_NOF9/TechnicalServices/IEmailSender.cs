﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalServices
{
   public interface IEmailSender
    {
        void SendTextEmail( string text, string Email);
    }
}
