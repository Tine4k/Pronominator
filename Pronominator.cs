namespace Pronominator;
static class Pronominator
{
    static Pronominator()
    {
        var pronounsByLanguage = new Dictionary<string, HashSet<string>>();

        foreach (string fileName in Directory.GetFiles("pronouns"))
        {
            string language = Path.GetFileNameWithoutExtension(fileName);
            pronounsByLanguage.Add(language, new HashSet<string>(File.ReadAllLines(fileName)));
        }

        pronouns = new Dictionary<string, HashSet<string>>();
        foreach (var kv in pronounsByLanguage)
        {
            foreach (string word in kv.Value)
            {
                if (!pronouns.ContainsKey(word))
                {
                    pronouns[word] = new HashSet<string>();
                }
                pronouns[word].Add(kv.Key);
            }
        }
    }
    public static string? FindPronouns(string remainingWord, List<string>? usedPronouns = null)
    {
        usedPronouns ??= new List<string>();
        if (remainingWord == "")
        {
            if (usedPronouns.Count <= 4)
            {
                string resultPronouns = String.Empty;
                foreach (string pronoun in usedPronouns)
                {
                    resultPronouns += $"{pronoun} ({String.Join(", ", pronouns[pronoun])})\n";
                }
                return resultPronouns;
            }
            return null;
        }

        foreach (string pronoun in pronouns.Keys)
        {
            if (remainingWord.StartsWith(pronoun) && !usedPronouns.Contains(pronoun))
            {
                usedPronouns.Add(pronoun);
                string? result = FindPronouns(remainingWord.Substring(pronoun.Length), usedPronouns);
                if (result is not null) return result;
                usedPronouns.Remove(pronoun);
            }
        }
        return null;
    }
    static Dictionary<string, HashSet<string>> pronouns;
}