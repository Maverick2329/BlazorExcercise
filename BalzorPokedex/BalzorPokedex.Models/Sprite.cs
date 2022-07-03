using Newtonsoft.Json;

namespace BalzorPokedex.Models
{
    public class Sprite
    {
        [JsonProperty("front_default")]
        public string Front { get; set; }

        [JsonProperty("back_default")]
        public string Back { get; set; }
    }
}