using System;

namespace L5_1
{
  class Program
  {
    static void Main(string[] args)
    {
      const string CommandExit = "Выйти";

      Dictionary<string, string> fruits = new Dictionary<string, string>();
      fruits.Add("Арбуз", "это ягода");
      fruits.Add("Помидор", "это ягода");
      fruits.Add("Банан", "это ягода");
      bool isAsking = true;

      while (isAsking)
      {
        Console.WriteLine("Введите название плода:");
        string userInput = Console.ReadLine();

        switch (userInput)
        {
          case CommandExit:
            isAsking = false;
            break;

          default:
            TakeAnswer(fruits, userInput);
            break;
        }
      }
    }

    private static void TakeAnswer(Dictionary<string, string> dictionary, string key)
    {
      if (dictionary.ContainsKey(key))
      {
        Console.WriteLine(dictionary[key]);
      }
      else
      {
        Console.WriteLine("Такой плод не найден, попробуйте снова");
      }
    }
  }
}
