using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using RecipeFinder.Logic.Model;
using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Client;
using sib_api_v3_sdk.Model;
using System.Diagnostics;


namespace RecipeFinder.Logic
{
    public class EmailObject
    {


        private readonly static string senderEmail = "cspam1961@gmail.com";

        public EmailObject(string apiKey)
        {
            Configuration.Default.AddApiKey("api-key", apiKey);
        }

        public EmailObject(IConfiguration configuration)
        {
            string apiKey = configuration["BrevoKey"] ?? throw new System.InvalidOperationException("SendInBlueKey missing");
            Configuration.Default.AddApiKey("api-key", apiKey);

        }

        public async Task<string> GetAllContacts(){

            var apiInstance = new ContactsApi();
            long? listId = 2;
            string? modifiedSince = "2020-10-20T19:20:30+05:30";
            long? limit = 50;
            long? offset = 0;
            GetContacts result = await apiInstance.GetContactsFromListAsync(listId, modifiedSince, limit, offset);
            return result.ToJson();

        }

        public async void AddContact(string firstname, string lastname, string email)
        {

            var apiInstance = new ContactsApi();

            JObject attributes = new()
            {
                { "FIRSTNAME", firstname },
                { "LASTNAME", lastname },
                { "EMAIL", email }
            };
            List<long?> listIds = new()
            {
                2
            };
            bool emailBlacklisted = false;
            bool smsBlacklisted = false;
            bool updateEnabled = false;
            List<string> smtpBlacklistSender = new List<string>
            {
                "example@example.com"
            };
            try
            {
                var createContact = new CreateContact(email, attributes, emailBlacklisted, smsBlacklisted, listIds, updateEnabled, smtpBlacklistSender);
                CreateUpdateContactModel result = await apiInstance.CreateContactAsync(createContact);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Console.WriteLine(e.Message);
            }

        }

        public async void SendEmail(string to, string subject, string body)
        {
            var apiInstance = new TransactionalEmailsApi();

            var sendSmtpEmail = new SendSmtpEmail(
                sender: new SendSmtpEmailSender("Recipe Finder",senderEmail),
                to: new List<SendSmtpEmailTo> { new SendSmtpEmailTo(to) },
                subject: subject,
                htmlContent: body);

            try
            {
                CreateSmtpEmail result = await apiInstance.SendTransacEmailAsync(sendSmtpEmail);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Console.WriteLine(e.Message);
            }
        }



    }
}
