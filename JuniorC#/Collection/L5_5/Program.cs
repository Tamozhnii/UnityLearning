using System;

namespace L5_5
{
  class Program
  {
    static void Main(string[] args)
    {
      string[] array1 = { "1", "2", "1" };
      string[] array2 = { "3", "2", "3", "4" };
      ConcatToUniqArray(array1, array2);
    }

    private static void ConcatToUniqArray(string[] array1, string[] array2)
    {
      Dictionary<string, string> uniqArray = new Dictionary<string, string>();
      AddArray(array1, uniqArray);
      AddArray(array2, uniqArray);
      ShowArray(uniqArray);
    }

    private static void AddArray(string[] array, Dictionary<string, string> dictionary)
    {
      for (int i = 0; i < array.Length; i++)
      {
        if (!dictionary.ContainsKey(array[i]))
        {
          dictionary.Add(array[i], array[i]);
        }
      }
    }

    private static void ShowArray(Dictionary<string, string> dictionary)
    {
      Console.Write("[ ");

      foreach (var el in dictionary)
      {
        Console.Write($"{el.Value} ");
      }

      Console.Write("]");
    }
  }
}