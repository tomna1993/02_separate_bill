using System;
using System.Data;
using System.Reflection.Metadata;

namespace SeparateBill
{
    static class Constant
    {
        public const Int32 EXIT_SUCCESS = 1;
        public const Int32 EXIT_FAILURE = -1;
    }

    class SeparateBill
    {
        static Int32 Main()
        {
            Double bill = GetValueFromUser("Bill before tax and tip: ");

            if (bill == Constant.EXIT_FAILURE) { return Constant.EXIT_FAILURE; }

            Double taxPercent = GetValueFromUser("Sale tax percent: ");

            if (taxPercent == Constant.EXIT_FAILURE) { return Constant.EXIT_FAILURE; }

            Double tipPercent = GetValueFromUser("Tip percent: ");
            
            if (tipPercent == Constant.EXIT_FAILURE) { return Constant.EXIT_FAILURE; }



            return Constant.EXIT_SUCCESS;       
        }

        static Double GetValueFromUser(string message)
        {
            Double value = 0.0d;
            Int32 tryes = 10;

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
    }
}
