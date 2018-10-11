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
        public virtual Brush BackGroundColor { get; set; }
        
        [JsonProperty("foreground")]
        public virtual Brush ForeGroundColor { get; set; }

        public ColorData() { }

        public ColorData(Color bg, Color fg)
        {
            this.BackGroundColor = new SolidColorBrush(bg);
            this.ForeGroundColor = new SolidColorBrush(fg);
        }
    }

    [JsonObject]
    public class LoadColorData : ColorData
    {
        [JsonProperty("background")]
        public string StringBackColor { get; set; }
        [JsonProperty("foreground")]
        public string StringForeColor { get; set; }

        [JsonIgnore]
        private Brush _bgcolor = null;
        [JsonIgnore]
        public override Brush BackGroundColor
        {
            get
            {
                if(_bgcolor == null)
                {
                    _bgcolor =  new SolidColorBrush((Color)ColorConverter.ConvertFromString(StringBackColor));
                }
                return _bgcolor;
            }
            set
            {
                _bgcolor = value;
            }
        }

        [JsonIgnore]
        private Brush _fgcolor = null;
        [JsonIgnore]
        public override Brush ForeGroundColor
        {
            get
            {
                if (_fgcolor == null)
                {
                    _fgcolor = new SolidColorBrush((Color)ColorConverter.ConvertFromString(StringForeColor));
                }
                return _fgcolor;
            }
            set
            {
                _fgcolor = value;
            }
        }
    }
}