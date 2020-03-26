using Capstone.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Capstone.Services
{
    public class SmsService : ISmsService
    {
        private readonly string Account_SID = Api_Keys.Account_SID;
        private readonly string AUTH_TOKEN = Api_Keys.AUTH_TOKEN;
        private readonly string TwilioPhoneNumber = Api_Keys.TwilioPhoneNumber;

        public SmsService()
        {

        }

        public async Task SendSMS(string receiver, string reminder)
        {
            TwilioClient.Init(Account_SID, AUTH_TOKEN);

            var message = await MessageResource.CreateAsync(
                body: reminder,
                from: new Twilio.Types.PhoneNumber(TwilioPhoneNumber),
                to: new Twilio.Types.PhoneNumber($"1{receiver}")
            );
        }
    }
}
