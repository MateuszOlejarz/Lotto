using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace LottoZadanie
{
    class Program
    {
        static List<string> Lista = new List<string>() { "ZliczenieWystąpieniaKażdejZLiczb", "NajwięcejRazy", "SześćNajmniej", "CzyByłoPowtórzenie" };
        public static List<Operations1> LosowanieLotto = new List<Operations1>();
        public static int[] tablicaLiczb = new int[49];
        static void Main(string[] args)
        {
         
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader("dl.txt"))
                {
                    string line;
                    // Read and display lines from the file until the end of 
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        Operations1 operacjaDzielenia = new Operations1();
                        string[] share = line.Split(new string[] { ".", " ", "," }, StringSplitOptions.None);

                        operacjaDzielenia.NumerLosowania = Int32.Parse(share[0]);
                        operacjaDzielenia.KtóryDzien = Int32.Parse(share[2]);
                        operacjaDzielenia.MiesiącKtóry = Int32.Parse(share[3]);
                        operacjaDzielenia.RokJaki = Int32.Parse(share[4]);
                        for (int i = 5, lo = 0; i < 11; i++, lo++)
                        {
                            operacjaDzielenia.Lliczbaa[lo] = Int32.Parse(share[i]);
                        }
                        LosowanieLotto.Add(operacjaDzielenia);
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            Operations1.IleRazy(LosowanieLotto, tablicaLiczb);
            
            int szerokosc = 0;
            int wysokosc = 0;
            int wybieranie = 0;
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            Console.CursorVisible = false;
            do
            {

                while (Console.KeyAvailable)
                {
                    Console.ReadKey(false);
                }
                Console.Clear();
                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (wybieranie > Lista.Count - 2)
                            wybieranie = 0;
                        else
                            wybieranie++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (wybieranie - 1 < 0)
                            wybieranie = Lista.Count - 1;
                        else
                            wybieranie--;
                        break;
                    case ConsoleKey.Enter:
                        Open_Options(wybieranie);
                        break;
                    default:
                        Console.BackgroundColor = ConsoleColor.Red;
                        break;
                }

                for (int i = 0; i < Lista.Count; i++)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    if (Lista[i].Length > szerokosc)
                    {
                        szerokosc = Lista[i].Length;
                    }
                    Console.CursorLeft = (Console.WindowWidth / 2) - Lista[i].Length / 2;
                    Console.CursorTop = (Console.WindowHeight / 2) - Lista.Count / 2;
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + i);
                    if (i == wybieranie)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine(Lista[i]);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.CursorLeft = (Console.WindowWidth / 2) - szerokosc / 2 - 1;
                Console.CursorTop = (Console.WindowHeight / 2) - Lista.Count / 2 - 1;
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                Console.Write("\u250C");
                for (int i = 0; i < szerokosc; i++)
                {
                    Console.Write("\u2500");
                }
                Console.Write("\u2510");

                for (int i = 0; i < Lista.Count; i++)
                {
                    Console.CursorTop = (Console.WindowHeight / 2) - Lista.Count / 2;
                    Console.SetCursorPosition(Console.CursorLeft - szerokosc - 2, Console.CursorTop + i);
                    Console.Write("\u2502");
                    Console.CursorLeft = (Console.WindowWidth / 2) - szerokosc / 2 + 2;
                    Console.SetCursorPosition(Console.CursorLeft + szerokosc - 2, Console.CursorTop);
                    Console.Write("\u2502");
                }
                Console.CursorLeft = (Console.WindowWidth / 2) - szerokosc / 2 - 1;
                Console.CursorTop = (Console.WindowHeight / 2) - Lista.Count / 2;
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + Lista.Count);
                Console.Write("\u2514");
                for (int i = 0; i < szerokosc; i++)
                {
                    Console.Write("\u2500");
                }
                Console.Write("\u2518");

                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.UpArrow && key.Key != ConsoleKey.DownArrow && key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape)
                {
                    Console.Beep(500, 500);
                    string error0 = "Error!!!!!!!!! Not This key";
                    Console.CursorLeft = (Console.WindowWidth / 2) - error0.Length / 2 - 1;
                    Console.CursorTop = (Console.WindowHeight / 2) - 1;
                    for (int i = 0; i < 3; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Print_Options(ConsoleColor.White, error0, Console.CursorLeft, Console.CursorTop);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Print_Options(ConsoleColor.Red, error0, Console.CursorLeft, Console.CursorTop);
                        Console.ForegroundColor = ConsoleColor.White;
                        Print_Options(ConsoleColor.Black, error0, Console.CursorLeft, Console.CursorTop);
                    }

                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Clear();
                }

            } while (key.Key != ConsoleKey.Escape);

        }
        public static void Open_Options(int You_Choose)
        {
            string wybór;
            wybór = Lista[You_Choose];
            switch (wybór)
            {
                case "ZliczenieWystąpieniaKażdejZLiczb":
                    Operations1.IleRazy(LosowanieLotto, tablicaLiczb);
                    Console.ReadKey();
                    break;
                case "NajwięcejRazy":
                    Operations1.Najwiecej(LosowanieLotto, tablicaLiczb);
                    Console.ReadKey();
                    break;
                case "SześćNajmniej":
                    Operations1.N6ajmniej6(LosowanieLotto, tablicaLiczb);
                    //Console.ReadLine();
                    Console.ReadKey();
                    break;
                case "CzyPowtorzeniaByły":
                    Operations1.CzySiePowtarzaja(LosowanieLotto, tablicaLiczb);
                    Console.ReadKey(); 
                    break;
                default:
                    break;
            }
            Print_Options(ConsoleColor.Black, wybór, Console.CursorLeft, Console.CursorTop);
            
        }

        private static void Print_Options(ConsoleColor Our_COlor , String error,int Position_Widht, int Position_Hight)
        {
            Console.BackgroundColor = Our_COlor;
            Console.Clear();
            Console.SetCursorPosition(Position_Widht, Position_Hight);
            
            Thread.Sleep(100);
        }
        // Console.ReadKey();

    }
}

