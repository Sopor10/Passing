using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using Juggling;
using Juggling.Fixtures;
using Juggling.Juggler;
using Juggling.Types;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main(string[] args)
        {
//            while (true)
//            {
//                Console.Write("Input short Notation: \n");
//                var notation = Console.ReadLine();
//                if (new ScrambledVShortNotationConverter().Validate(notation))
//                {
//                    var pattern = new ScrambledVShortNotationConverter().GetLongNotationHtml(notation);
//                    using (var file = new System.IO.StreamWriter(@"Latex/test.tex"))
//                    {
//                        file.Write(pattern);
//                    }
//
//                    Console.Write(pattern);
//                    break;
//                }
//
//                Console.WriteLine("Dies ist keine gültige Scrambled V Notation\n");
//            }
            var notation = "sA iC cB";
            var pattern = new ScrambledVShortNotationConverter().GetLongNotationHtml(notation);
            Console.Write(pattern);
            using (var file = new System.IO.StreamWriter(@"Latex/test.html"))
            {
                file.Write(pattern);
            }
        }
    }
}