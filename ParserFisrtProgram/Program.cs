using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.XPath;

namespace ParserFisrtProgram
{
    class Program
    {

        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var config = Configuration.Default.WithDefaultLoader();
            // Устанавливаем адрес страницы сайта
            var address = "http://page.if.ua/article/6/";
            // загружаем страницу и разбираем её
            var document = await BrowsingContext.New(config).OpenAsync(address);
            // Используем CSS селектор для получения строк таблицы с классом  и выбрать из этой строки 3 колонку 
            var cellSelector = "table.tbl_afisha td:nth-child(4)";
            // Получим все ячейки
            var cells = document.QuerySelectorAll(cellSelector);
            //Выделим из ячеек текстовое содержимое
            var titles = cells.Select(m => m.TextContent);

            foreach (var item in titles)
            {
                Console.WriteLine(item);
            }
        }
    }
}
