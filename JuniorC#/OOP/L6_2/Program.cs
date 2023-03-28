using System;

namespace L6_1
{
  class Program
  {
    static void Main(string[] args)
    {
      Player player1 = new Player("Tom", '$', 4, 8);
      Player player2 = new Player();
      Drawer drawer = new Drawer();
      drawer.Draw(player1);
      drawer.Draw(player2);
      Console.ReadKey();
    }
  }

  class Player
  {
    public Player()
    {
      Name = "Unknown";
      Symbol = '†';
      PositionX = 5;
      PositionY = 5;
    }

    public Player(string name, char symbol, int positionX, int positionY)
    {
      Name = name;
      Symbol = symbol;
      PositionX = positionX;
      PositionY = positionY;
    }

    public int PositionX { get; private set; }
    public int PositionY { get; private set; }
    public string Name { get; private set; }
    public char Symbol { get; private set; }
  }

  class Drawer
  {
    public void Draw(Player player)
    {
      Console.SetCursorPosition(player.PositionY, player.PositionX);
      Console.WriteLine(player.Symbol);
    }
  }
}