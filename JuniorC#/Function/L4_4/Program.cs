using System;
using System.IO;

namespace L4_4
{
  class Program
  {
    private static void Main(string[] args)
    {
      Console.CursorVisible = false;
      bool isGameOn = true;
      char playerSymbol = '@';
      char wallHorizontalSymbol = '_';
      char wallVerticalSymbol = '|';
      char emptySymbol = ' ';
      char coinSymbol = '$';
      int maxCoins = 5;
      int coinsCounter = 0;
      int playerX = 0, playerY = 0, directionVertical = 0, directionHorizontal = 0;
      string fileName = "map";
      char[,] map = ReadMap(fileName, playerSymbol, ref playerX, ref playerY);
      DrawMap(map);

      while (isGameOn)
      {
        if (Console.KeyAvailable)
        {
          ConsoleKeyInfo key = Console.ReadKey(true);

          switch (key.Key)
          {
            case ConsoleKey.UpArrow:
              directionVertical = -1;
              directionHorizontal = 0;
              break;
            case ConsoleKey.DownArrow:
              directionVertical = 1;
              directionHorizontal = 0;
              break;
            case ConsoleKey.LeftArrow:
              directionVertical = 0;
              directionHorizontal = -1;
              break;
            case ConsoleKey.RightArrow:
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

        TakeCoins(ref coinsCounter, ref map, playerX, playerY, coinSymbol, emptySymbol);

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
      int dirV,
      int dirH,
      char emptySymbol,
      char playerSymbol
    )
    {
      Console.SetCursorPosition(y, x);
      Console.Write(emptySymbol);
      x += dirV;
      y += dirH;
      Console.SetCursorPosition(y, x);
      Console.Write(playerSymbol);
    }

    private static void TakeCoins(ref int counter, ref char[,] map, int x, int y, char coin, char empty)
    {
      int counterX = 5, counterY = 15;

      if (map[x, y] == coin)
      {
        map[x, y] = empty;
        counter++;
      }

      Console.SetCursorPosition(counterX, counterY);
      Console.Write($"Coins: {counter}");
    }

  }
}