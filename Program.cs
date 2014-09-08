using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        public static int recievedMoney; // För att kunna använda variabeln i try-catch-satsen
        public static uint fivehundredBills;
        public static uint onehundredBills;
        public static uint fiftyBills;
        public static uint twentyBills;
        public static uint tenCoins;
        public static uint fiveCoins;
        public static uint oneCoins;
        public static uint remainingSum;

        static void Main(string[] args)
        {
            Console.Title = ("Växelpengar - nivå A");

            // Deklarera variabler.
            uint total;                 // Att betala
            double subtotal;
            double roundingOffAmount;   // Öresavrundning
            string input;
            int moneyBack;    

            // Läs in värde från tangentbord.
            while (true)
            {
                Console.Write("Ange totalsumma:");
                input = Console.ReadLine();
                try
                {
                    subtotal = double.Parse(input);

                    if (subtotal >= 1)
                    {
                        break;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Totalsumman är för liten. Köpet kunde inte genomföras. Försök igen.");
                        Console.ResetColor();
                    }
                }
                catch (FormatException)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("FEL! Inmatat belopp är felaktigt. Försök igen");
                    Console.ResetColor();
                }
            }

            while (true)
            {
                Console.Write("Ange erhållet belopp:");
                input = Console.ReadLine();
                try
                {
                    recievedMoney = int.Parse(input);

                    if (recievedMoney >= subtotal)
                    {
                        break;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Erhållet belopp är för litet. Köpet kunde inte genomföras. Försök igen.");
                        Console.ResetColor();
                    }

                }
                catch (FormatException)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("FEL! Erhållet belopp felaktigt. Försök igen.");
                    Console.ResetColor();
                }
            }

            // Räkna ut växelpengar.
            total = (uint)Math.Round(subtotal);
            roundingOffAmount = total - subtotal;
            moneyBack = recievedMoney - (int)total;

            // Räkna ut valörer på växelpengar
            fivehundredBills = (uint)moneyBack / 500;
            remainingSum = (uint)moneyBack % 500;
            onehundredBills = remainingSum / 100;
            remainingSum = remainingSum % 100;
            fiftyBills = remainingSum / 50;
            remainingSum = remainingSum % 50;
            twentyBills = remainingSum / 20;
            remainingSum = remainingSum % 20;
            tenCoins = remainingSum / 10;
            remainingSum = remainingSum % 10;
            fiveCoins = remainingSum / 5;
            remainingSum = remainingSum % 5;
            oneCoins = remainingSum;

            // Skriv ut kvitto med beräknad växel.
            Console.WriteLine("");
            Console.WriteLine("KVITTO");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Totalt         :      {0,8:c}", subtotal);
            Console.WriteLine("Öresavrundning :      {0,8:c}", roundingOffAmount);
            Console.WriteLine("Att betala     :      {0,8:c0}", total);
            Console.WriteLine("Kontant        :      {0,8:c0}", recievedMoney);
            Console.WriteLine("Tillbaka       :      {0,8:c0}", moneyBack);
            Console.WriteLine("-----------------------------------------");
            if (recievedMoney > subtotal)
            {
                Console.WriteLine("Att ge tillbaka:");
                if (fivehundredBills > 0)
                {
                    Console.WriteLine("500-lappar \t: {0}", fivehundredBills);
                }
                if (onehundredBills > 0)
                {
                    Console.WriteLine("100-lappar \t: {0}", onehundredBills);
                }
                if (fiftyBills > 0)
                {
                    Console.WriteLine("50-lappar \t: {0}", fiftyBills);
                }
                if (twentyBills > 0)
                {
                    Console.WriteLine("20-lappar \t : \t {0}", twentyBills);
                }
                if (tenCoins > 0)
                {
                    Console.WriteLine("10-kronor \t : \t {0}", tenCoins);
                }
                if (fiveCoins > 0)
                {
                    Console.WriteLine("5-kronor \t : \t {0}", fiveCoins);
                }
                if (oneCoins > 0)
                {
                    Console.WriteLine("1-kronor \t : \t {0}", oneCoins);
                }
            }
        }
    }
}