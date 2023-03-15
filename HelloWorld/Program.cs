using System;

namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // //byte 8-bit
            // //short 16-bit


            // //Largest / smallest sbyte (signed byte)
            // sbyte mySbyte = 127;
            // sbyte mySecondSbyte = -128;

            // //Largest / smallest byte 
            // byte myByte = 255;
            // byte mySecondByte = 0;

            // //Largest / smallest short / ushort
            // short myShort = -32768;
            // ushort myUshort = 65535;

            // //Largest / smallest int (32-bit)
            // int myInt = 2147483647;

            // // Longs
            // long myLong = -9223372036854775808;

            // //Decimals 
            // //Note the f is mandatory for floats (8 bit)
            // float myFloat = 0.751f;
            // float mySecondFloat = 0.751f;

            // //Doubles 16-bit
            // double myDouble = 0.751;
            // double mySecondDouble = 0.751d; //d is not necessary

            // //Decimal 
            // decimal myDecimal = 0.751m;
            // decimal mySecondDecimal = 0.751m;

            // //Decimal is good for accuracy

            // Console.WriteLine(myFloat - mySecondFloat);
            // Console.WriteLine(myDouble - mySecondDouble);
            // Console.WriteLine(myDecimal - mySecondDecimal);

            // bool myBool = true;

            // // Arrays:

            // //This is an array, arrays have set lengths and don't grow
            // string[] myGroceryArray = new string[2];

            // myGroceryArray[0] = "Guac";

            // Console.WriteLine(myGroceryArray[0]);
            // Console.WriteLine(myGroceryArray[1]);

            // string[] mySecondGroceryArray = {"Oranges", "Apples"};

            // Console.WriteLine(mySecondGroceryArray[0]);
            // Console.WriteLine(mySecondGroceryArray[1]);

            // //Lists: 

            // List<string> myGroceryList = new List<string>();

            // myGroceryList.Add("Oranges");

            // Console.WriteLine(myGroceryList[0]);
            
            // //Allegedly IEnumerables are faster
            // IEnumerable<string> myGrocerIEnumerable = myGroceryList;

            // //2D Arrays
            // int[,] sudoku = new int[,]{
            //     {1,2,3,4,5,6,7,8,9},
            //     {1,2,3,4,5,6,7,8,9}
            // };

            // Console.WriteLine(sudoku[1,2]);

            //Dictionary - basically your hash
            Dictionary<string, string[]> myGroceryDictionary = new Dictionary<string, string[]>{
                {"Dairy", new string[]{"Cheese", "Eggs"}}
            };

            Console.WriteLine(myGroceryDictionary["Dairy"][0]);

        }
    }
}