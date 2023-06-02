namespace Pronominator;
class Program
{
    public static void Main()
    {
        

        string input = Console.ReadLine() ?? throw new Exception();
        Console.WriteLine(Pronominator.FindPronouns(input) ?? "Not found!");
    }

}