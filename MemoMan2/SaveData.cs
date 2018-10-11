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

        [JsonProperty("color")]
        public virtual ColorData WorldColor { get; set; } = ColorDatas.Black;

        //メモテキスト
        [JsonProperty("text")]
        public string Text { get; set; } = "";
    }

    [JsonObject]
    public class LoadData : SaveData
    {
        [JsonProperty("color")]
        public LoadColorData _WorldColor { get; set; }

        [JsonIgnore]
        private ColorData _color = null;
        [JsonIgnore]
        public override ColorData WorldColor
        {
            get
            {
                if(_color == null)
                {
                    _color = _WorldColor;
                }
                return _color;
            }
            set
            {
                _color = value;
            }
        }

    }
}
