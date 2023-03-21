using System;

namespace L4_3
{
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      Console.WriteLine(program.ConvertToInt());
    }

    private int ConvertToInt()
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
