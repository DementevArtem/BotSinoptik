using AngleSharp;
using ParserFisrtProgram.BotTelegram;
using System;
using System.Linq;

namespace ParserFisrtProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionBot = new Connection();
            connectionBot.InfoAtribut();

            Console.ReadLine();
        }
    }
}
