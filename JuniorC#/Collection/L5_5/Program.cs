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
      List<string> uniqArray = new List<string>();
      AddArray(array1, uniqArray);
      AddArray(array2, uniqArray);
      ShowArray(uniqArray);
    }

    private static void AddArray(string[] array, List<string> list)
    {
      for (int i = 0; i < array.Length; i++)
      {
        if (list.Contains(array[i]) == false)
        {
          list.Add(array[i]);
        }
      }
    }

    private static void ShowArray(List<string> array)
    {
      Console.Write("[ ");

      foreach (string value in array)
      {
        Console.Write($"{value} ");
      }

      Console.Write("]");
    }
  }
}