using System.Text;

namespace PasswordGenerator
{
    public class PasswordGenerator
    {
        [Flags]
        public enum PasswordChars
        {
            Digits = 0b0001,
            Alphabet = 0b0010,
            Symbols = 0b0100
        }

        const int MIN_PASSWORD_LENGTH = 5;
        const int MAX_PASSWORD_LENGTH = 15;

        readonly Random rnd;
        readonly string DIGITS;
        readonly string ALPHABET;
        readonly string SPECIAL_SYMBOLS;

        public PasswordGenerator()
        {
            rnd = new Random();
            DIGITS = "0123456789";
            ALPHABET = "abcdefghijklmnopqrstuvwxyz";
            SPECIAL_SYMBOLS = " ~`@#$%^&*()_+-=[]{};'\\:\"|,./<>?";
        }

        public PasswordGenerator(string digits, string alphabet, string symbols): this()
        {
            DIGITS = digits;
            ALPHABET = alphabet;
            SPECIAL_SYMBOLS = symbols;
        }

        public string GeneratePassword(PasswordChars passwordChars, int passwordLength)
        {
            passwordLength = Math.Clamp(passwordLength, MIN_PASSWORD_LENGTH, MAX_PASSWORD_LENGTH);
            StringBuilder resultPassword = new StringBuilder(passwordLength);
            string passwordCharSet = string.Empty;

            if (passwordChars.HasFlag(PasswordChars.Alphabet))
            {
                passwordCharSet += ALPHABET + ALPHABET.ToUpper();
            }

            if (passwordChars.HasFlag(PasswordChars.Digits))
            {
                passwordCharSet += DIGITS;
            }

            if (passwordChars.HasFlag(PasswordChars.Symbols))
            {
                passwordCharSet += SPECIAL_SYMBOLS;
            }

            for (var i = 0; i < passwordLength; i++)
            {
                resultPassword.Append(passwordCharSet[rnd.Next(0, passwordCharSet.Length)]);
            }

            return resultPassword.ToString();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            PasswordGenerator password = new PasswordGenerator();
            PasswordGenerator.PasswordChars chars = PasswordGenerator.PasswordChars.Symbols | PasswordGenerator.PasswordChars.Digits;

            string rndPassword = password.GeneratePassword(chars, 10);
            Console.WriteLine(rndPassword + "\n");

            password = new PasswordGenerator("2617", "", "()[]{}<>+|^");
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine(password.GeneratePassword(chars, 7));
            }

            Console.ReadLine();
        }
    }
}