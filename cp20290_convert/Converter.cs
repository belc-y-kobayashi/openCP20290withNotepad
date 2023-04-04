using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cp20290_convert
{
    internal class Converter
    {
        internal static string ReadSourceFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                var encoding = Encoding.GetEncoding("IBM290");
                using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                using var reader = new StreamReader(stream, encoding);
                return reader.ReadToEnd();
            }
            else throw new Exception("File Not Found");
        }
        internal static string[] SplitAt(string target, int num)
        {
            return Regex.Split(target, $"(.{{{num}}})").Where(s => s.Length == num).ToArray();
        }
    }
}
