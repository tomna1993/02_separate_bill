using System;
using System.Data;
using System.Reflection.Metadata;

namespace SeparateBill
{
    static class Constant
    {
        public const int EXIT_SUCCESS = 1;
        public const int EXIT_FAILURE = -1;
    }

    class SeparateBill
    {
        static int Main()
        {
            double bill = GetValueFromUser("Bill before tax and tip: ");

            if (bill == Constant.EXIT_FAILURE) { return Constant.EXIT_FAILURE; }

            double taxPercent = GetValueFromUser("Sale tax percent: ");

            if (taxPercent == Constant.EXIT_FAILURE) { return Constant.EXIT_FAILURE; }

            double tipPercent = GetValueFromUser("Tip percent: ");
            
            if (tipPercent == Constant.EXIT_FAILURE) { return Constant.EXIT_FAILURE; }

            Console.WriteLine($"You will owe ${SeparateBillBetweenPersons(bill, taxPercent, tipPercent, 2):F2} each!");

            return Constant.EXIT_SUCCESS;       
        }

        static double GetValueFromUser(string message)
        {
            double value = 0.0d;
            int tryes = 10;

            do
            {
                Console.Write(message);

                try
                {
                    value = Convert.ToDouble(Console.ReadLine());
                }
                catch (FormatException exceptionMessage) 
                { 
                    Console.WriteLine(exceptionMessage);
                }

                --tryes;

            } while (value <= 0.0d && tryes > 0);

            if (tryes == 0) { return Constant.EXIT_FAILURE; }

            return value;
        }

        static double SeparateBillBetweenPersons(double bill, double taxPercent, double tipPercent, int numberOfPersons) 
        {
            bill += bill * (taxPercent / 100.0f);

            bill += bill * (tipPercent / 100.0f);

            return bill / numberOfPersons;
        } 
    }
}
