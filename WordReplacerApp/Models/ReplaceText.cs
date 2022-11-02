using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordReplacerApp.Models
{
    public class ReplaceText
    {
        public string FromText { get; set; }
        public string ToText { get; set; }
        public ReplaceText(string fromText, string toText)
        {
            FromText = fromText;
            ToText = toText;
        }

    }
}
