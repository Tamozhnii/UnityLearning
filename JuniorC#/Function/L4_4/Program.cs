using System;
using System.IO;

namespace L4_4
{
  class Program
  {
    private static void Main(string[] args)
    {
      const ConsoleKey Up = ConsoleKey.UpArrow;
      const ConsoleKey Down = ConsoleKey.DownArrow;
      const ConsoleKey Left = ConsoleKey.LeftArrow;
      const ConsoleKey Right = ConsoleKey.RightArrow;

      Console.CursorVisible = false;
      bool isGameOn = true;
      string fileName = "map";
      char playerSymbol = '@';
      char wallHorizontalSymbol = '_';
      char wallVerticalSymbol = '|';
      char emptySymbol = ' ';
      char coinSymbol = '$';
      int maxCoins = 5;
      int coinsCounter = 0;
      int playerX = 0;
      int playerY = 0;
      int directionVertical = 0;
      int directionHorizontal = 0;
      int counterX = 5;
      int counterY = 15;
      char[,] map = ReadMap(fileName, playerSymbol, ref playerX, ref playerY);
      DrawMap(map);

      while (isGameOn)
      {
        if (Console.KeyAvailable)
        {
          ConsoleKeyInfo key = Console.ReadKey(true);

          switch (key.Key)
          {
            case Up:
              directionVertical = -1;
              directionHorizontal = 0;
              break;

            case Down:
              directionVertical = 1;
              directionHorizontal = 0;
              break;

            case Left:
              directionVertical = 0;
              directionHorizontal = -1;
              break;

            case Right:
              directionVertical = 0;
              directionHorizontal = 1;
              break;
          }
        }

        char newPosition = map[playerX + directionVertical, playerY + directionHorizontal];

        if (newPosition != wallHorizontalSymbol && newPosition != wallVerticalSymbol)
        {
          Move(ref playerX, ref playerY, directionVertical, directionHorizontal, emptySymbol, playerSymbol);
        }

        coinsCounter = TakeCoins(coinsCounter, map, playerX, playerY, coinSymbol, emptySymbol);
        Console.SetCursorPosition(counterX, counterY);
        Console.Write($"Coins: {coinsCounter}");

        if (coinsCounter == maxCoins)
        {
          isGameOn = false;
        }

        System.Threading.Thread.Sleep(150);
      }
    }

    private static char[,] ReadMap(string mapName, char playerSymbol, ref int playerX, ref int playerY)
    {
      string[] newFile = File.ReadAllLines($"Maps/{mapName}.txt");
      char[,] map = new char[newFile.Length, newFile[0].Length];

      for (int i = 0; i < map.GetLength(0); i++)
      {
        for (int j = 0; j < map.GetLength(1); j++)
        {
          map[i, j] = newFile[i][j];

          if (newFile[i][j] == playerSymbol)
          {
            playerX = i;
            playerY = j;
          }
        }
      }

      return map;
    }

    private static void DrawMap(char[,] map)
    {
      Console.Clear();

      for (int i = 0; i < map.GetLength(0); i++)
      {
        for (int j = 0; j < map.GetLength(1); j++)
        {
          Console.Write(map[i, j]);
        }

        Console.WriteLine();
      }
    }

    private static void Move(
      ref int x,
      ref int y,
      int directionVertical,
      int directionHorizontal,
      char emptySymbol,
      char playerSymbol
    )
    {
      Console.SetCursorPosition(y, x);
      Console.Write(emptySymbol);
      x += directionVertical;
      y += directionHorizontal;
      Console.SetCursorPosition(y, x);
      Console.Write(playerSymbol);
    }

    private static int TakeCoins(int counter, char[,] map, int x, int y, char coin, char empty)
    {
      if (map[x, y] == coin)
      {
        map[x, y] = empty;
        counter++;
      }

      return counter;
    }
  }
}