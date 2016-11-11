using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA
{
    class MyClass
    {
        public class MyString
        {
            public static void Reverse(string txt)
            {
                if (String.IsNullOrEmpty(txt))
                {
                    Console.WriteLine("Text was empty!");
                    return;
                }

                char[] charArray = txt.ToCharArray();
                Array.Reverse(charArray);
                Console.WriteLine(new string(charArray));
            }

            public static void countVovel(string txt)
            {
                if (String.IsNullOrEmpty(txt))
                {
                    Console.WriteLine("Text was empty!");
                    return;
                }

                int countA = 0;
                int countE = 0;
                int countI = 0;
                int countU = 0;

                foreach (char symbol in txt)
                {
                       
                    if (symbol.Equals('a') || symbol.Equals('A'))
                        countA++;
                    if (symbol.Equals('e') || symbol.Equals('E'))
                        countE++;
                    if (symbol.Equals('i') || symbol.Equals('I'))
                        countI++;
                    if (symbol.Equals('u') || symbol.Equals('U'))
                        countU++;
                }

                if (countA > 0)
                    Console.WriteLine("Vovel a found: " + countA + " times.");
                if (countE > 0)
                    Console.WriteLine("Vovel e found: " + countE + " times.");
                if (countI > 0)
                    Console.WriteLine("Vovel i found: " + countI + " times.");
                if (countU > 0)
                    Console.WriteLine("Vovel u found: " + countU + " times.");
            }

            public static bool isPalindrom(string txt)
            {
                if (String.IsNullOrEmpty(txt))
                {
                    Console.WriteLine("Text was empty!");
                    return false;
                }

                for (int pos = 0; pos < txt.Length; pos++)
                    if (!txt[pos].Equals(txt[txt.Length - 1 - pos]))
                        return false;

                return true;
            }

            public static void countWords(string txt)
            { 
                
            }
        }
    }
}
