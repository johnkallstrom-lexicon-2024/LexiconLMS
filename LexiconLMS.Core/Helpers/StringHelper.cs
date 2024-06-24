using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconLMS.Core.Helpers
{
    public static class StringHelper
    {
        public static bool TryTruncate(string text, int wordLimit, out string truncatedText)
        {
            var words = text.Split(' ');
            if (words.Length <= wordLimit)
            {
                truncatedText = text;
                return false;
            }

            truncatedText = string.Join(' ', words.Take(wordLimit)) + "...";
            return true;
        }
    }
}
