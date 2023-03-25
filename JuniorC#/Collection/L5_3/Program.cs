using System;

namespace L5_2
{
  class Program
  {
    static void Main(string[] args)
    {
      const string CommandSum = "Sum";
      const string CommandExit = "Exit";

      bool isWork = true;
      List<int> numbers = new List<int>();
      Console.WriteLine("Введите число или команду:");

      while (isWork)
      {
        string userInput = Console.ReadLine();

        switch (userInput)
        {
          case CommandSum:
            GetSum(numbers);
            break;

          case CommandExit:
            isWork = false;
            break;

          default:
            AddNumber(numbers, userInput);
            break;
        }
      }
    }

    static void GetSum(List<int> numbers)
    {
      int result = 0;

      foreach (int number in numbers)
      {
        result += number;
      }

      Console.WriteLine($"Сумма: {result}\n");
    }

    static void AddNumber(List<int> numbers, string input)
    {
      int number = 0;

      if (int.TryParse(input, out number))
      {
        numbers.Add(number);
      }
      else
      {
        Console.WriteLine("Введите целое число");
      }
    }
  }
}