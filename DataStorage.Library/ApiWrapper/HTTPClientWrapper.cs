using DataStorage.Library.Application.Dtos;
using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DataStorage.Library.ApiWrapper
{
    public class HTTPClientWrapper
    {
        public HTTPClientWrapper()
        {

        }

        public async Task<IEnumerable<DataStoreDto>> Execute(IReadOnlyList<string> countryCodes)
        {
            try
            {
                var semaphoreSlim = new SemaphoreSlim(
                                  initialCount: 10,
                                  maxCount: 10);
                var responses = new ConcurrentBag<List<DataStoreDto>>();
                using (var httpClient = new HttpClient())
                {
                    var tasks = countryCodes.Select(async countryCode =>
                    {
                        await semaphoreSlim.WaitAsync();
                        try
                        {
                            var response = await httpClient.GetAsync($"https://date.nager.at/api/v3/publicholidays/2020/{ countryCode }");
                            response.EnsureSuccessStatusCode();
                            string responseBody = await response.Content.ReadAsStringAsync();
                            var json = JsonConvert.DeserializeObject<List<DataStoreDto>>(responseBody);
                            responses.Add(json);
                        }
                        finally
                        {
                            semaphoreSlim.Release();
                        }
                    });

                    await Task.WhenAll(tasks);
                }

                return responses.SelectMany(x => x).ToArray();
            }
            catch (System.Exception ex )
            {

                return null;
            }
            
        }
    }
}

