using BalzorPokedex.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BalzorPokedex.Services
{
    public class PokeApiClient : IPokeApiClient
    {
        private readonly HttpClient _httpClient;
        public PokeApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResultObject> GetAllPokemons(PaginationParameters paginationParameters)
        {
           return JsonConvert.DeserializeObject<ResultObject>(
            await _httpClient.GetStringAsync($"pokemon?limit={paginationParameters.PageSize}&offset={paginationParameters.Offset}"));        

        }

        public async Task<Pokemon> GetPokemon(string name)
        {
            return JsonConvert.DeserializeObject<Pokemon>(
                await _httpClient.GetStringAsync($"pokemon/{name}"));
        }
    }
}
