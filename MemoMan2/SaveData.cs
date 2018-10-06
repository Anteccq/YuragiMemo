using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MemoMan2
{
    [JsonObject]
    public class SaveData
    {
        //座標
        [JsonProperty("left")]
        public double Left { get; set; } = 50.0;
        [JsonProperty("top")]
        public double Top { get; set; } = 20.0;

        //メモテキスト
        [JsonProperty("text")]
        public string Text { get; set; } = "";
    }
}
