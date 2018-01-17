using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseCodeTranslator
{
	static class MorseTranslator
	{
		private static Dictionary<char, string> textToMorse = new Dictionary<char, string>
		{
			{' ', "/"},
			{'A', ".-"},
			{'B', "-..."},
			{'C', "-.-."},
			{'D', "-.."},
			{'E', "."},
			{'F', "..-."},
			{'G', "--."},
			{'H', "...."},
			{'I', ".."},
			{'J', ".---"},
			{'K', "-.-"},
			{'L', ".-.."},
			{'M', "--"},
			{'N', "-."},
			{'O', "---"},
			{'P', ".--."},
			{'Q', "--.-"},
			{'R', ".-."},
			{'S', "..."},
			{'T', "-"},
			{'U', "..-"},
			{'V', "...-"},
			{'W', ".--"},
			{'X', "-..-"},
			{'Y', "-.--"},
			{'Z', "--.."},
			{'1', ".----"},
			{'2', "..---"},
			{'3', "...--"},
			{'4', "....-"},
			{'5', "....."},
			{'6', "-...."},
			{'7', "--..."},
			{'8', "---.."},
			{'9', "----."},
			{'0', "-----"},
			{',', "--..--"},
			{'.', ".-.-.-"},
			{'?', "..--.."},
			{';', "-.-.-."},
			{':', "---..."},
			{'/', "-..-."},
			{'-', "-....-"},
			{'\'', ".----."},
			{'"', ".-..-."},
			{'(', "-.--."},
			{')', "-.--.-"},
			{'=', "-...-"},
			{'+', ".-.-."},
			{'@', ".--.-."},
			{'!', "-.-.--"},
			{'Á', ".--.-"},
			{'É', "..-.."},
			{'Ö', "---."},
			{'Ä', ".-.-"},
			{'Ñ', "--.--"},
			{'Ü', "..--"}
		};

		private static Dictionary<string, char> morseToText = new Dictionary<string, char>();

		static MorseTranslator()
		{
			foreach (var kvp in textToMorse)
			{
				morseToText.Add(kvp.Value, kvp.Key);
			}
			morseToText.Add("!", '\uFFFD');
		}

		public static string ToMorse(string input)
		{
			List<string> output = new List<string>(input.Length);

			foreach (char c in input.ToUpperInvariant())
			{
				if (!textToMorse.ContainsKey(c))
				{
					output.Add("!");
				}
				else
				{
					output.Add(textToMorse[c]);
				}
			}

			return string.Join(" ", output);
		}

		public static string ToText(string morse)
		{
			var characters = morse.Split(' ');

			return string.Join("", characters.Select(c => morseToText[c]));
		}
	}
}
