﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalzorPokedex.Models
{
    public class ResultObject
    {
        [JsonProperty("results")]
        public IEnumerable<Pokemon> Pokemons { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
