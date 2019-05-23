using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoZadanie
{
    class Operations1
    {
        private int[] liczbaa;
        private int numerLosowania;
        private int day;
        private int month;
        private int year;
        public Operations1()
        {
            liczbaa = new int[6];
        }
        
        public int KtóryDzien
        {
            set
            {
                if (value != 0)
                    day = value;
            }
            get
            {
                return day;

            }
        }
        public int MiesiącKtóry
        {
            set
            {
                if (value != 0)
                {
                    month = value;
                }

            }
            get
            {
                return month;
            }
        }
        public int RokJaki
        {
            set
            {
                if (value != 0)
                {
                    year = value;
                }
            }
            get
            {
                return year;
            }

        }
        public int NumerLosowania
        {
            set
            {
                numerLosowania = value;
            }
            get
            {
                return numerLosowania;
            }
        }
        public int[] Lliczbaa
        {
            set
            {
                liczbaa = value;
            }
            get
            {
                return liczbaa;

            }

        }
        public void PokazNumery()
        {
            foreach (var pom in liczbaa)
            {
                Console.Write(pom + " ");
            }
        }
       

        public static void IleRazy(List<Operations1> list1, int[] TablicaLiczb1)
        {
            Array.Clear(TablicaLiczb1, 0, TablicaLiczb1.Length);
            Console.WriteLine(" ");
            foreach (var v in list1)
            {
                for (int i = 0; i < v.Lliczbaa.Length; i++)
                {
                    TablicaLiczb1[v.Lliczbaa[i] - 1]++;
                }
            }
            for (int i = 0; i < TablicaLiczb1.Length; i++)
            {
                Console.WriteLine("Numer: " + (i + 1) + " " + "wystąpił:" + TablicaLiczb1[i] + " razy.");


            }
        }
        public static void Najwiecej(List<Operations1> list1, int[] TablicaLiczb1)
        {
            int ile;

            ile = Array.IndexOf(TablicaLiczb1, TablicaLiczb1.Max()) + 1;
            Console.WriteLine("Numer: " + ile + " wystąpił najwiięcej razy ");

        }

        public static void N6ajmniej6(List<Operations1> list1, int[] TablicaLiczb1)
        {
            int n = TablicaLiczb1.Length;
            do
            {
                for (int i = 0; i < n - 1; i++)
                {
                    if (TablicaLiczb1[i] > TablicaLiczb1[i + 1])
                    {
                        int tmp = TablicaLiczb1[i];
                        TablicaLiczb1[i] = TablicaLiczb1[i + 1];
                        TablicaLiczb1[i + 1] = tmp;
                    }
                }
                n--;
            }
            while (n > 1);
            Console.WriteLine("Najmniej sześć razy ");
            for (int i = 0; i < TablicaLiczb1.Length; i++)
            {

            }

            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine(/*"Numer: " + (i + 1) + " " + "wystąpił:" + */       TablicaLiczb1[i]);
            }
            //to jest przydatne aby znowu mi numer 49 nie wyskakiwał po wybraniu największy
            Array.Clear(TablicaLiczb1, 0, TablicaLiczb1.Length);
            Console.WriteLine(" ");
            foreach (var v in list1)
            {
                for (int i = 0; i < v.Lliczbaa.Length; i++)
                {
                    TablicaLiczb1[v.Lliczbaa[i] - 1]++;
                }
            }
            for (int i = 0; i < TablicaLiczb1.Length; i++)
            {
               
            }
        }

        private static bool Porownaj(int[] liczbaa1, int[] liczbaa2)
        {
            throw new NotImplementedException();
        }
         public static void CzySiePowtarzaja(List<Operations1> list1, int[] TablicaLiczb1)
        {
             bool czyRowne = false;
             Operations1 sprawdzenie1 = new Operations1();
             Operations1 sprawdzenie2 = new Operations1();
             foreach(var linijka1 in list1)
             {
                 foreach (var linijka2 in list1)
                 {
                     if (linijka1 != linijka2)
                     {
                         czyRowne = Porownaj(linijka1.liczbaa, linijka2.liczbaa);
                         if (czyRowne == true)
                         {
                            sprawdzenie1 = linijka1;
                            sprawdzenie2 = linijka2;
                         }
                     }
                 }
                 if (czyRowne == true)
                     break;
             }
             Console.Clear();
            if (czyRowne == true)
            
            Console.WriteLine("Powtórzenie nastąpiło " + sprawdzenie1.KtóryDzien + " " + sprawdzenie1.MiesiącKtóry + " " + sprawdzenie1.RokJaki +
                 "ORAZ " + sprawdzenie2.KtóryDzien + " " + sprawdzenie2.MiesiącKtóry + " " + sprawdzenie2.RokJaki);
             
            else
                Console.WriteLine("Nie ma takich co są równe");
            
        }
        }
        }


/*int wynik = 0;
            for (int i = 0; i < TablicaLiczb1.Length; i++)
            {
                Console.WriteLine(" " + TablicaLiczb1[i]);
                if (TablicaLiczb1[i] == 1)
                {
                    wynik += 1;
                }
            }
            Console.WriteLine( wynik);*/
