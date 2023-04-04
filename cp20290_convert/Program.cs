using static System.Net.Mime.MediaTypeNames;

namespace cp20290_convert
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            var text = Converter.ReadSourceFile(args[0]);
            var splitted = Converter.SplitAt(text, 256);

            var tmpFile = Path.GetTempFileName();
            using (var sw = new StreamWriter(tmpFile))
            {
                sw.WriteLine(string.Join("\n", splitted));
            }
            System.Diagnostics.Process.Start("notepad.exe", tmpFile);
        }
    }
}