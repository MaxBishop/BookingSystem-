using Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalServices
{
    public class MockEmailsender : IEmailSender

    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(MockEmailsender));

        public void SendTextEmail(string text)
        {
            Log.Warn("email sent");
        }
    }
}
