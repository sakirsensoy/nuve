﻿using System.Collections.Generic;
using System.IO;

namespace Nuve.Stemming
{
    internal static class StemDictionaryGenerator
    {
        private const string Header =
            "# This file is generated by Nuve, a Natural Language Processing Library in C# for Turkic Languages\n" +
            "# https://github.com/hrzafer/nuve\n" +
            "# Harun Reşit Zafer harunzafer@gmail.com\n";

        public static void Generate(IEnumerable<string> words, IStemmer stemmer, string file)
        {
            var lines = new List<string> {Header};

            foreach (string word in words)
            {
                string stem = stemmer.GetStem(word);
                if (stem != word)
                {
                    lines.Add(word + "\t" + stem);
                }
            }

            lines.Sort();

            File.WriteAllLines(file, lines);
        }
    }
}