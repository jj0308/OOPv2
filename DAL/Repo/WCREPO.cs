using DAL.Model;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class WCREPO : IWCREPO
    {

        private Task<List<T>> GetDataAsync<T>(string url)
        {
            return Task.Run(() =>
            {
                var apiClient = new RestClient(url);
                var result = apiClient.Execute(new RestRequest());
                return JsonConvert.DeserializeObject<List<T>>(result.Content);
            });
        }




        public async Task<List<Countries>> GetAllCountries(string baseUrl)
        {
            var apiClient = new RestClient(baseUrl);
            var request = new RestRequest(baseUrl, Method.Get);
            var response = await apiClient.ExecuteAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<List<Countries>>(response.Content);
            }
            else
            {
                throw new Exception($"Error fetching countries: {response.StatusCode} - {response.ErrorMessage}");
            }
        }




        public async Task<List<SoccerMatch>> GetAllTeamPlayers(string baseUrl)
        {

            var apiClient = new RestClient(baseUrl);
            var request = new RestRequest(baseUrl, Method.Get);
            var response = await apiClient.ExecuteAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<List<SoccerMatch>>(response.Content);
            }
            else
            {
                throw new Exception($"{baseUrl} fetching players: {response.StatusCode} - {response.ErrorMessage}");
            }
        }


        public Task<List<SoccerMatch>> GetStats(string fifaCodeUrl)
        {
            return GetDataAsync<SoccerMatch>(fifaCodeUrl);
        }
    }
}
