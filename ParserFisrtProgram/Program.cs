using AngleSharp;
using System;
using System.Linq;

namespace ParserFisrtProgram
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var address = "https://ua.sinoptik.ua/%D0%BF%D0%BE%D0%B3%D0%BE%D0%B4%D0%B0-%D1%96%D0%B2%D0%B0%D0%BD%D0%BE-%D1%84%D1%80%D0%B0%D0%BD%D0%BA%D1%96%D0%B2%D1%81%D1%8C%D0%BA";
            var serchData = new SearchData();
            await serchData.GetData(address);
        }
    }
}
