using AngleSharp;
using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParserFisrtProgram
{
    class SearchData
    {
        internal string address = "";
        internal IEnumerable<string> data;
        internal async Task Data()
        {
            var config = Configuration.Default.WithDefaultLoader();
            var document = await BrowsingContext.New(config).OpenAsync(address);
            var cellSelector = "div.main.loaded";
            var cells = document.QuerySelectorAll(cellSelector);
            data = cells.Select(m => m.TextContent);
        }
    }
}
