using EmailSender.API.Data.Interfaces;
using EmailSender.API.Domain.Entities;
using RestSharp;
using RestSharp.Authenticators;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;

namespace EmailSender.API.Data.Services
{
    public class EmailService : IEmailService
    {
        //private readonly string API_KEY = Environment.GetEnvironmentVariable("API_KEY");
        //private readonly string DOMAIN = Environment.GetEnvironmentVariable("DOMAIN");

        public void SendEmail(EmailEntity email)
        {   RestClient client = new RestClient();

            client.BaseUrl = new Uri("https://api.mailgun.net/v3/");
            client.Authenticator = new HttpBasicAuthenticator("api", "b080e4ea58187ed0343fbb9790021488-ed54d65c-63c7ca3d");

            var request = new RestRequest();

            request.AddParameter("domain", "sandbox13dfa4de0ffb4cf98dc40ea9ccf65664.mailgun.org", ParameterType.UrlSegment);

            request.Resource = "/messages";
            request.AddParameter("from", "IBNT");
            request.AddParameter("to", $"{email.ReceiverEmailAddress}");
            request.AddParameter("subject", "TESTE");
            request.AddParameter("text", $"{email.EmailContent}");

            request.Method = Method.POST;
            var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = response.Content;
                Console.WriteLine(responseContent);
            }
        }
    }
}