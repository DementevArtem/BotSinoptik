using AngleSharp;
using System;
using System.Linq;

namespace ParserFisrtProgram
{
    class SearchData
    {
        internal async System.Threading.Tasks.Task GetData(string linkOfSite)
        {
            var config = Configuration.Default.WithDefaultLoader();
            var document = await BrowsingContext.New(config).OpenAsync(linkOfSite);
            var cellSelector = "div.main.loaded";
            var cells = document.QuerySelectorAll(cellSelector);
            var titles = cells.Select(m => m.TextContent);

            foreach (var item in titles)
            {
                Console.WriteLine(item);
            }
        }
    }
}
