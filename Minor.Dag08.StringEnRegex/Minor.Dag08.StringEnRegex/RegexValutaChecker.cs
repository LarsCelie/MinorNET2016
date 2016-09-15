using System;
using System.Text.RegularExpressions;

namespace Minor.Dag08.StringEnRegex
{
    public class RegexValutaChecker
    {
        private static Regex pattern = new Regex(@"^-?\d{1,3}(,\d{3})*\.\d{2}$");

        public bool Check(string input)
        {
            return pattern.IsMatch(input);
        }
    }

}