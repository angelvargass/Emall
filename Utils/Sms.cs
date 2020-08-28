using System;
using System.Collections.Generic;
using System.Text;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Utils {
    public static class Sms {
        public static void Enviar(string telefono, string mensaje) {
            try {
                const string accountSid = "<YOUR-ACCOUNT-ID>";
                const string authToken = "<YOUR-TOKEN>";

                TwilioClient.Init(accountSid, authToken);

                var message = MessageResource.Create(
                    body: mensaje,
                    from: new Twilio.Types.PhoneNumber("12058097956"),
                    to: new Twilio.Types.PhoneNumber(telefono)
                );
            } catch (Exception ex) { 
            }
        }
    }
}
