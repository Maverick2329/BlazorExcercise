using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BalzorPokedex.Models;

namespace BalzorPokedex.Services
{
    public interface IPokeApiClient
    {
        Task<ResultObject> GetAllPokemons(PaginationParameters paginationParameters);
        Task<Pokemon> GetPokemon(string name);
    }
}
