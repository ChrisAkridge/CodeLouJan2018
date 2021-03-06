﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseCodeTranslator
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write(": ");
			string input = Console.ReadLine();

			string morse = MorseTranslator.ToMorse(input);
			Console.WriteLine(morse);

			string text = MorseTranslator.ToText(morse);
			Console.WriteLine(text);

			Console.ReadKey(intercept: true);
		}
	}
}
