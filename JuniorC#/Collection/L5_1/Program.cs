using System;

namespace L5_1
{
  class Program
  {
    static void Main(string[] args)
    {
      Dictionary<string, string> fruits = new Dictionary<string, string>();
      fruits.Add("Арбуз", "это ягода");
      fruits.Add("Помидор", "это ягода");
      fruits.Add("Банан", "это ягода");
      TakeAnswer(fruits);
    }

    private static void TakeAnswer(Dictionary<string, string> dictionary)
    {
      const string CommandExit = "Выйти";
      const string CommandWatermelon = "Арбуз";
      const string CommandTomato = "Помидор";
      const string CommandBanana = "Банан";

      bool isAsking = true;

      while (isAsking)
      {
        Console.WriteLine("Введите название плода:");
        string userInput = Console.ReadLine();

        switch (userInput)
        {
          case CommandWatermelon:
          case CommandTomato:
          case CommandBanana:
            Console.WriteLine(dictionary[userInput]);
            break;

          case CommandExit:
            isAsking = false;
            break;

          default:
            Console.WriteLine("Такой плод не найден, попробуйте снова");
            break;
        }
      }
    }
  }
}
