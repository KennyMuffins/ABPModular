using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Acme.IssueManagement.Samples
{
    public class SampleAppService : IssueManagementAppService, ISampleAppService
    {
        //Test
        private const string BaseUrl = "https://fd911d6d85ac.ngrok.io/api/content/cake/content/";
        private readonly HttpClient _client;

        public SampleAppService(HttpClient client)
        {
            _client = client;

            _client.DefaultRequestHeaders.Authorization
             = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJSUzI1NiIsImtpZCI6IlhBanZ4WElJbXQ2UFdPWG5XM3pOUmciLCJ0eXAiOiJhdCtqd3QifQ.eyJuYmYiOjE2MTA1ODQwNTYsImV4cCI6MTYxMzE3NjA1NiwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3QvaWRlbnRpdHktc2VydmVyIiwiY2xpZW50X2lkIjoiY2FrZTpkZWZhdWx0IiwianRpIjoiNjVFNTgzM0FFNjIwQjBGOEYyOTcyMDNCOUZFODFBNjIiLCJpYXQiOjE2MTA1ODQwNTYsInNjb3BlIjpbInNxdWlkZXgtYXBpIl19.rzexQaMqyyxxI-Btpu53W40H8k5aVR0uGDKMK-PazuIatFgFaGzwz2IQTDVNlRsF3EUhwuunDsLrd5q-ZbXd5zFiezZAcq6L4kPT1pyUdBn1bSCXNSBjjlCYXDKd337_iO2LThs8iHYHkLknj_Ajef_lxpOA0mEXT4zjud1N0efztm-CPj9lu6MUc0yAeZ-4rZ5OOegmJhTl3UnCsWbNSQbfUsc61ZSQj0QvZx8yuTYJ1xhATxy67zSCq6pccMoB8-eWi-MP-5dYhS_5GxI_tBnaIAZE5IZNQKxQZ5AT25Gnjfuty1fExFmO9dojCdbO46sUxwiTmThSFpU83xH9bg");
        }

        public async Task<List<Items>> GetAsync()
        {

            var httpResponse = await _client.GetAsync(BaseUrl);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve tasks");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            var tasks = JsonConvert.DeserializeObject<Response>(content);

            List<Items> allItems = tasks.items;


            return allItems;
        }

        public async Task<Items> GetAsyncById(string guid)
        {

            var url = BaseUrl + guid;

            var httpResponse = await _client.GetAsync(url);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve tasks");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            var item = JsonConvert.DeserializeObject<Items>(content);

            return item;
        }

        public async Task<PostResponse> CreateAsync(ContentDto contentDto)
        {
            var contentString = JsonConvert.SerializeObject(contentDto);

            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(BaseUrl + "?publish=true"),
                Content = new StringContent(contentString)
                {
                    Headers =
                    {
                        ContentType = new MediaTypeHeaderValue("application/json")
                    }
                }
            };

            using (var response = await _client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);

                var returnedJsonObj = JsonConvert.DeserializeObject<PostResponse>(body);

                return returnedJsonObj;
            }
        }

        public async Task<PostResponse> UpdateAsync(string guid)
        {
            //string contentId = "2ce433d3-2a03-4178-b8ce-be86f33e721f";

            string contentId = guid;

            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri(BaseUrl+ contentId),
                Content = new StringContent("{\"Id\": {\"iv\": 8},\"UserId\": {\"iv\": 8},\"Title\": {\"iv\": \"Kenny8Updated\"},\"IsCompleted\": {\"iv\": true}}")
                {
                    Headers =
                    {
                        ContentType = new MediaTypeHeaderValue("application/json")
                    }
                }
            };

            using (var response = await _client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);

                return JsonConvert.DeserializeObject<PostResponse>(body);
            }
        }

        [Authorize]
        public Task<Response> GetAuthorizedAsync()
        {
            //return Task.FromResult(
            //    new SampleDto
            //    {
            //        Id = 1,
            //        UserId = 2,
            //        Title = "Kenny",
            //        IsCompleted = false
            //    }
            //);
            throw new NotImplementedException();
        }
    }
}