using System;

namespace L4_3
{
  class Program
  {
    private static void Main(string[] args)
    {
      int convertedNumber = GetNumber();
      Console.WriteLine(convertedNumber);
    }

    private static int GetNumber()
    {
      string userInput = "";
      int number = 0;

      while (userInput != number.ToString())
      {
        Console.Write("Введите число: ");
        userInput = Console.ReadLine();
        int.TryParse(userInput, out number);
      }

      return number;
    }
  }
}
