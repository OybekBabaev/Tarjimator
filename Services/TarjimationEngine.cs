using System.Text.RegularExpressions;

namespace Tarjimator.Services;

public class TarjimationEngine
{
    private Dictionary<string, string> transliterationLookup;

    public TarjimationEngine()
    {
        transliterationLookup = new() 
        {
            {"shch", "щ"}, {"SHCH", "Щ"}, {"Shch", "Щ"},
            {"sh", "ш"}, {"SH", "Ш"}, {"Sh", "Ш"},
            {"ch", "ч"}, {"CH", "Ч"}, {"Ch", "Ч"},
            {"jo", "ё"}, {"JO", "Ё"}, {"Jo", "Ё"},
            {"je", "э"}, {"JE", "Э"}, {"Je", "Э"},
            {"zh", "ж"}, {"ZH", "Ж"}, {"Zh", "Ж"},
            {"ju", "ю"}, {"JU", "Ю"}, {"Ju", "Ю"},
            {"ja", "я"}, {"JA", "Я"}, {"Ja", "Я"},
            {"a", "а"}, {"A", "А"},
            {"b", "б"}, {"B", "Б"},
            {"c", "ц"}, {"C", "Ц"},
            {"d", "д"}, {"D", "Д"},
            {"e", "е"}, {"E", "Е"},
            {"f", "ф"}, {"F", "Ф"},
            {"g", "г"}, {"G", "Г"},
            {"h", "х"}, {"H", "Х"},
            {"i", "и"}, {"I", "И"},
            {"j", "й"}, {"J", "Й"},
            {"k", "к"}, {"K", "К"},
            {"q", "к"}, {"Q", "К"},
            {"l", "л"}, {"L", "Л"},
            {"m", "м"}, {"M", "М"},
            {"n", "н"}, {"N", "Н"},
            {"o", "о"}, {"O", "О"},
            {"p", "п"}, {"P", "П"},
            {"r", "р"}, {"R", "Р"},
            {"s", "с"}, {"S", "С"},
            {"x", "х"}, {"X", "Х"},
            {"t", "т"}, {"T", "Т"},
            {"u", "у"}, {"U", "У"},
            {"v", "в"}, {"V", "В"},
            {"w", "в"}, {"W", "В"},
            {"y", "ы"}, {"*:", "ъ"}, {"::", "ь"},
            {"z", "з"}, {"Z", "З"},
        };
    }

    public string Transliterate(string text)
    {
        if (String.IsNullOrEmpty(text)) return "";

        string processedText = text;

        var matches = Regex.Matches(text, @"<!--[\p{P}|\w|\s]*-->");
        foreach (Match m in matches) processedText = processedText.Replace(m.Value, "<!->");

        foreach (var k in transliterationLookup) processedText = processedText.Replace(k.Key, k.Value);

        foreach (Match m in matches)
        {
            var rgx = new Regex("<!->");
            processedText = rgx.Replace(processedText, m.Value[4..^3], 1);
        }
        
        return processedText;
    }

    public Dictionary<string, string> GetLookup() => transliterationLookup;
}