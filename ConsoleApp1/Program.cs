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
            while (true)
            {
                Console.Write("Input short Notation: \n");
                Console.Write("For Example cB sC iC\n");
                var notation = Console.ReadLine();
                if (new ScrambledVShortNotationConverter().Validate(notation))
                {
                    var pattern = new ScrambledVShortNotationConverter().GetLongNotationLatex(notation);

                    Console.Write(pattern);
                    break;
                }

                Console.WriteLine("Dies ist keine gültige Scrambled V Notation\n");
            }

        }
    }
}