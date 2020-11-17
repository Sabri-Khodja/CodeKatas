using System.Text;

namespace WordWrap
{
    public static class Wrapper
    {
        public static string Wrap(string text, int column)
        {
            if (text.Length <= column)
            {
                return text;
            }

            StringBuilder formattedTextBuilder = new StringBuilder();
            var startSearchIndex = column - 1;
            var startSubstring = 0;
            var lenghtSubstring = 0;
            while (startSearchIndex < text.Length)
            {
                var indexOfLastSpace = text.LastIndexOf(" ", startSearchIndex, column);

                lenghtSubstring = indexOfLastSpace - ( startSearchIndex - column + 1);
                formattedTextBuilder.AppendLine(text.Substring(startSubstring, lenghtSubstring));
                startSubstring = indexOfLastSpace + 1;
                startSearchIndex = startSubstring + column - 1;
            }

            formattedTextBuilder.Append(text.Substring(startSubstring, text.Length - startSubstring));

            return formattedTextBuilder.ToString();
        }

    }
}
