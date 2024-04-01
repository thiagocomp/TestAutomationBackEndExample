using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationExample.Domain.ItauCorretora
{
    public class QuotesValidation
    {
        public string TitleQuotes { get; protected set; }
        public string FindQuotes { get; protected set; }
        public string Stock { get; protected set; }
        public string Exchange { get; protected set; }
        public string High { get; protected set; }
        public string Low { get; protected set; }
        public string LargerVolumes { get; protected set; }

        public QuotesValidation(string _titleQuotes, string _findQuotes, string _stock, string _exchange,
            string _high, string _low, string _largeVolumes)
        {
            TitleQuotes = _titleQuotes;
            FindQuotes = _findQuotes;
            Stock = _stock;
            Exchange = _exchange;
            High = _high;
            Low = _low;
            LargerVolumes = _largeVolumes;
        }
    }
}
