using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Newtonsoft.Json;

namespace MemoMan2
{
    [JsonObject]
    public class ColorData
    {
        [JsonProperty("background")]
        public SolidColorBrush BackGroundColor { get; set; }
        
        [JsonProperty("foreground")]
        public SolidColorBrush ForeGroundColor { get; set; }

        public ColorData(Color bg, Color fg)
        {
            this.BackGroundColor = new SolidColorBrush(bg);
            this.ForeGroundColor = new SolidColorBrush(fg);
        }
    }
}
