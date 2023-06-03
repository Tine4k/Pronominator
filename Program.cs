namespace Pronominator;
class Program
{
    public static void Main(string[] args)
    {
        if (args.Length > 0) {Console.WriteLine(Pronominator.FindPronouns(args[0])); Console.ReadKey();}
        if (!File.Exists("words.md"))
        {
            while (true)
            {
                string? word = Console.ReadLine();
                OutputPronounCombination(word);
                
            }

        }
        string[] words = File.ReadAllLines("words.md");
        foreach (string word in words) 
        {
            OutputPronounCombination(word);
        }
        Console.WriteLine("Finished!");
        Console.ReadKey();
    }
    static void OutputPronounCombination(string? word)
    {
        if (word is null) return;
        string? pronouns = Pronominator.FindPronouns(word.ToLower());
        if (pronouns is null) return;
        if (File.Exists("output.md"))
        {
            File.WriteAllText("output.md", word + ":\n"+ pronouns);
        }
        Console.WriteLine(word + ":\n"+ pronouns);
    }
}