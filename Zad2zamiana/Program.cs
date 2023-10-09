using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("C:/test/PracaWork.txt");
            string filePath = Console.ReadLine();

            if (File.Exists(filePath))
            {
                string originalContent = File.ReadAllText(filePath);
                string modifiedContent = ReplaceAndCountOccurrences(originalContent);

                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
                string fileExtension = Path.GetExtension(filePath);
                string currentDate = DateTime.Now.ToString("yyyyMMddHHmm");
                string newFileName = $"{fileNameWithoutExtension}_changed_{currentDate}{fileExtension}";

                File.WriteAllText(newFileName, modifiedContent);

                Console.WriteLine($"Plik został zapisany jako {newFileName}");
            }
            else
            {
                Console.WriteLine("Podany plik nie istnieje.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd: {ex.Message}");
        }
    }

    static string ReplaceAndCountOccurrences(string input)
    {
        string pattern = @"\bpraca\b"; // Wyszukujemy "praca" jako oddzielne słowo
        string replacement = "job";
        int replaceCount = 0;

        string modifiedContent = Regex.Replace(input, pattern, match =>
        {
            replaceCount++;
            return replacement;
        });

        Console.WriteLine($"Znaleziono i zamieniono {replaceCount} wystąpień 'praca' na 'job'.");

        return modifiedContent;
    }
}
