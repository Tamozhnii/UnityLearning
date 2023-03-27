using System;

namespace L6_1
{
  class Program
  {
    static void Main(string[] args)
    {
      Player player1 = new Player("Tom", '$', 4, 8);
      Player player2 = new Player();
      Drower drower = new Drower();
      drower.Drow(player1);
      drower.Drow(player2);
      Console.ReadKey();
    }
  }

  class Player
  {
    public int X { get; private set; }
    public int Y { get; private set; }
    public string Name { get; private set; }
    public char Symbol { get; private set; }

    public Player()
    {
      Name = "Unknown";
      Symbol = '†';
      X = 5;
      Y = 5;
    }

    public Player(string name, char symbol, int x, int y)
    {
      Name = name;
      Symbol = symbol;
      X = x;
      Y = y;
    }
  }

  class Drower
  {
    public void Drow(Player player)
    {
      Console.SetCursorPosition(player.Y, player.X);
      Console.WriteLine(player.Symbol);
    }
  }
}