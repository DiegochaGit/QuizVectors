using Vectors.Logic;

try
{
    Console.WriteLine("Hello, Arrays!");
    int option;
    MyArray myArray = new(10);
    myArray.Fill();
    do
    {
        option = Menu();
        switch (option)
        {
            case 1:
                Console.Write("\nEnter the number of elements: ");
                var nString = Console.ReadLine();
                int n = 10;
                int.TryParse(nString, out n);
                myArray = new(n);
                myArray.Fill();
                break;
            case 2:
                Console.WriteLine("\nVector:");
                Console.WriteLine(myArray);
                break;
            case 3:
                Console.WriteLine("\nVector:");
                Console.WriteLine(myArray);
                Console.WriteLine("Vector of Even numbers:");
                Console.WriteLine(myArray.GetEven());
                break;
            case 4:
                Console.WriteLine("\nVector:");
                Console.WriteLine(myArray);
                Console.WriteLine("Vector of Odd numbers:");
                Console.WriteLine(myArray.GetOdd());
                break;
            case 5:
                Console.WriteLine("\nVector:");
                Console.WriteLine(myArray);
                Console.WriteLine("Vector of Prime numbers:");
                Console.WriteLine(myArray.GetPrimes());
                break;
            case 6:
                Console.WriteLine("\nVector:");
                Console.WriteLine(myArray);
                Console.WriteLine("Vector of Non-repeated numbers:");
                Console.WriteLine(myArray.GetNonRepeated());
                break;
            case 7:
                Console.WriteLine("\nVector:");
                Console.WriteLine(myArray);
                Console.WriteLine("Vector of Most repeated numbers:");
                Console.WriteLine(myArray.GetMostRepeated());
                break;
            case 8:
                Console.WriteLine("\nVector:");
                Console.WriteLine(myArray);
                Console.WriteLine("Inverted vector:");
                Console.WriteLine(myArray.InvertedArray());
                break;
            case 9:
                Console.WriteLine("\nVector:");
                Console.WriteLine(myArray);
                Console.WriteLine("The sum of the vector is: ");
                Console.WriteLine(myArray.SumArray());
                break;
            case 10:
                Console.WriteLine("\nVector:");
                Console.WriteLine(myArray);
                Console.WriteLine("The average of the vector is: ");
                Console.WriteLine(myArray.MeanArray());
                break;
            case 11:
                Console.WriteLine("\nVector of Fibonacci numbers:");
                Console.WriteLine(myArray.FillFibonacciArray());
                break;
            case 12:
                bool sortDesc = false;
                Console.WriteLine("\nVector:");
                Console.WriteLine(myArray);
                myArray.Sort(sortDesc);
                Console.WriteLine("Vector sorted ascendingly:");
                Console.WriteLine(myArray);
                break;
            case 13:
                bool sortDescending = true;
                Console.WriteLine("\nVector:");
                Console.WriteLine(myArray);
                myArray.Sort(sortDescending);
                Console.WriteLine("Vector sorted descendingly:");
                Console.WriteLine(myArray);
                break;
            case 0:
                Console.WriteLine("\nThe program has been over!!!!");
                option = 0;
                break;
            default:
                Console.WriteLine("\nFuck you. The option doesn't exist!!!!");
                break;
        }
    } while (option != 0);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

int Menu()
{
    Console.WriteLine("\n_____________________________________________");
    Console.WriteLine("OPTION MENU");
    Console.WriteLine("1. Define vector size");
    Console.WriteLine("2. Show vector");
    Console.WriteLine("3. Show even numbers");
    Console.WriteLine("4. Show odd numbers");
    Console.WriteLine("5. Show prime numbers");
    Console.WriteLine("6. Show non-repeated numbers");
    Console.WriteLine("7. Show most repeated numbers");
    Console.WriteLine("8. Inverted vector");
    Console.WriteLine("9. Sum of the vector");
    Console.WriteLine("10. Average of the vector");
    Console.WriteLine("11. Fill vector with fibonacci series");
    Console.WriteLine("12. Sort vector ascendingly");
    Console.WriteLine("13. Sort vector descendingly");
    Console.WriteLine("0. Exit");
    bool isValid = false;
    int option = 0;

    do
    {
        Console.WriteLine("____________________");
        Console.Write("Type your option: ");
        var optionString = Console.ReadLine();
        if (!int.TryParse(optionString, out option))
        {
            Console.WriteLine("\nInvalid option!!!  (only use numbers from 0 to 13).");
            isValid = false;
        }
        else
        {
            isValid = true;
        }
    } while (!isValid);
    return option;
}