

// A script that simply takes in a password and analyzes its strength.
using System.Diagnostics.Metrics;

class PasswordChecker
{
    public static void Main(String[] args)
    {
        Console.WriteLine("Enter your password and we will check its strength: ");
        string? password = Console.ReadLine();

        if (password == null)
        {
            Console.WriteLine("Error: null input");
            return;
        }

        password = password.Replace(" ", "");
        Console.Write("Checking strength of: " + password);
        Console.WriteLine("\n");

        int overallStrength = 0;
        overallStrength += CheckPasswordLength(password);
        overallStrength += CheckForCommonPhrases(password);
        overallStrength += CheckForLettersNumbersAndSymbols(password);

        DisplayOverallStrength(overallStrength);
    }

    private static int CheckPasswordLength(string password)
    {
        if (password.Length < 9)
        {
            Console.WriteLine("Password way too short.\n");
            return -1;
        }
        else if (password.Length < 12)
        {
            Console.WriteLine("Password is a little short.\n");
            return 0;
        }
        else if (password.Length < 16)
        {
            Console.WriteLine("Password is an okay length\n");
            return 1;
        }
        else
        {
            Console.WriteLine("Password is a great length!\n");
            return 4;
        }

    }

    private static int CheckForCommonPhrases(string password)
    {
        string[] commonPhrases = { "abc", "123", "password", "qwerty" };
        int strengthDeductions = 0;
        foreach (string phrase in commonPhrases)
        {
            if (password.ToLower().Contains(phrase))
            {
                Console.WriteLine("Your password contains the common phrase: " + phrase + "\n");
                strengthDeductions -= 4;
            }
        }

        return strengthDeductions;
    }

    private static int CheckForLettersNumbersAndSymbols(string originalPassword)
    {
        int overallStrength = 0;
        string password = originalPassword.ToLower();

        // Check that password contains letters.
        string[] letters = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        bool containsLetters = false;
        foreach (string letter in letters)
        {
            if (password.Contains(letter))
            {
                containsLetters = true;
                password = password.Replace(letter, "");
            }
        }

        if (containsLetters)
        {
            overallStrength += 1;

            // Check that password contains upper case and lower case letters.
            if (originalPassword.ToLower() == originalPassword)
            {
                Console.WriteLine("Passwords should contain both uppercase and lowercase letters.");
            }
            else
            {
                overallStrength += 1;
            }
        }
        else
        {
            Console.WriteLine("Password does not contain any letters.");
            overallStrength -= 1;
        }

        // Check that password contains numbers.
        string[] numbers = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        bool containsNumbers = false;
        foreach(string number in numbers)
        {
            if (password.Contains(number))
            {
                containsNumbers = true;
                password = password.Replace(number, "");
            }
        }

        if (containsNumbers)
        {
            overallStrength += 1;
        }
        else
        {
            Console.WriteLine("Password does not contain any numbers.");
            overallStrength -= 1;
        }

        // Check that password contains special characters.
        if (password.Length > 0)
        {
            overallStrength += 1;
        }
        else
        {
            Console.WriteLine("Password does not contain any special characters.");
            overallStrength -= 1;
        }

        return overallStrength;
    }

    private static void DisplayOverallStrength(int overallStrength)
    {
        Console.WriteLine("\nOverall password ranking:");
        if (overallStrength < 3)
        {
            Console.WriteLine("Your password is very weak");
        }
        else if (overallStrength < 5)
        {
            Console.WriteLine("Your password is a little weak");
        }
        else if (overallStrength < 7)
        {
            Console.WriteLine("Your password is okay");
        }
        else
        {
            Console.WriteLine("Your password is super strong!");
        }
    }
}
