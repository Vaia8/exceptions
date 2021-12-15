using System;
using System.IO;

namespace exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] lines = ReadFile("C:\\texty\\seznam.txt");
                PrintLine(lines);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Soubor nebyl nalezen.");
            }
        }

        static string[] ReadLines(TextReader reader)
        {
            string[] lines = new string[10];
            int count = 0;
            string line = reader.ReadLine();

            while (line != null)
            {
                if (count >= lines.Length)
                {
                    Array.Resize(ref lines, count + 10);
                }
                lines[count] = line;
                line = reader.ReadLine();
                count++;
            }
            Array.Resize(ref lines, count);
            return lines;
        }
        static string[] ReadFile(string fileName)
        {
            using (TextReader reader = new StreamReader(fileName))
            {
                return ReadLines(reader);
            }
        }
        static void WriteLine(string[] lines, int index)
        {
            Console.WriteLine(lines[index]);
        }
        static void WriteLines(string[] lines)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                Console.WriteLine(lines[i]);
            }
        }
        static bool TryReadInteger(out int result)
        {
            try
            {
                Console.WriteLine("Zadejte cislo radku nebo 0 pro ukonceni: ");
                string s = Console.ReadLine();
                result = Int32.Parse(s);
                return true;
            }
            catch (FormatException)
            {
                result = 0;
                Console.Write("Chybne zadani. ");
                return false;
            }
        }
        static int ReadInteger()
        {
            bool success;
            int number;
            do
            {
                success = TryReadInteger(out number);
            }
            while (!success);
            return number;
        }
        static void PrintLine(string[] lines)
        {
            int number;
            while ((number = ReadInteger()) != 0 )
            {
                try
                {
                    Console.WriteLine(lines[number - 1]);
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Spatne zadani, napiste cislo od 1 do " + lines.Length);
                }
            }
        }
    }
}
