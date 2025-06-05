using TMPro; // WICHTIG für TextMeshPro
using UnityEngine;
using System.Text.RegularExpressions;
using System.Linq;
public class RegexScript : MonoBehaviour
{
    public TMP_InputField input1, input2, input3, input4, input5;
    public TMP_Text output1, output2, output3, output4, output5;

    public void CheckRegex()
    {
        // 1) Zähle alle Großbuchstaben A
        string text1 = input1.text;
        int countA = Regex.Matches(text1, "A").Count;
        output1.text = $"Anzahl A: {countA}";

        // 2) Alle Dateinamen mit "Projekt1"
        string text2 = input2.text;
        string[] filenames = text2.Split(',');
        var filtered = filenames.Where(name => Regex.IsMatch(name.Trim(), "Projekt1"));
        output2.text = filtered.Any() ? string.Join("\n", filtered) : "Keine Treffer";

        // 3) E-Mail-Adressen extrahieren
        string text3 = input3.text;
        MatchCollection emails = Regex.Matches(text3, @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}");
        output3.text = emails.Count > 0 ? string.Join("\n", emails.Cast<Match>().Select(m => m.Value)) : "Keine E-Mail gefunden";

        // 4) Nur Zahlen extrahieren
        string text4 = input4.text;
        MatchCollection numbers = Regex.Matches(text4, @"\d+");
        output4.text = numbers.Count > 0 ? string.Join(", ", numbers.Cast<Match>().Select(m => m.Value)) : "Keine Zahlen gefunden";

        // 5) Wörter, die mit „M“ beginnen
        string text5 = input5.text;
        MatchCollection mWords = Regex.Matches(text5, @"\bM\w*");
        output5.text = mWords.Count > 0 ? string.Join(", ", mWords.Cast<Match>().Select(m => m.Value)) : "Keine Wörter mit M";
    }
}
