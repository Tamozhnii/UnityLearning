using System;

namespace L4_5
{
  class Program
  {
    private static void Main(string[] args)
    {
      int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
      ShowArray(numbers);
      ShuffleArray(numbers);
      ShowArray(numbers);
    }

    private static void ShuffleArray(int[] array)
    {
      Random random = new Random();

      for (int i = 0; i < array.Length; i++)
      {
        int newIndex = random.Next(array.Length);
        int temp = array[newIndex];
        array[newIndex] = array[i];
        array[i] = temp;
      }
    }

    private static void ShowArray(int[] array)
    {
      Console.Write("[ ");

      for (int i = 0; i < array.Length; i++)
      {
        Console.Write($"{array[i]} ");
      }

      Console.Write("]\n");
    }
  }
}