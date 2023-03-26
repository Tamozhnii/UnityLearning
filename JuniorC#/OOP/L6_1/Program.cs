using System;

namespace L6_1
{
  class Program
  {
    static void Main(string[] args)
    {
      Player player1 = new Player();
      Player player2 = new Player("Aragorn", Race.Human, Specialty.Warrior);
      Console.WriteLine(player1.ToString());
      Console.WriteLine(player2.ToString());
    }
  }

  class Player
  {
    private string NickName;
    private Race Race;
    private Specialty Specialty;

    public Player()
    {
      NickName = "Murduk";
      Race = Race.Ork;
      Specialty = Specialty.Rogue;
    }

    public Player(string nickName, Race race, Specialty specialty)
    {
      NickName = nickName;
      Race = race;
      Specialty = specialty;
    }

    public override string ToString()
    {
      return $"{NickName} - раса: {Race}, класс: {Specialty}";
    }
  }

  enum Race
  {
    Elf,
    Human,
    Dwarf,
    Ork,
  }

  enum Specialty
  {
    Warrior,
    Magician,
    Rogue,
    Hunter,
  }
}