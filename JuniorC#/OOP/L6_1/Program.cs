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
    private string _nickName;
    private Race _race;
    private Specialty _specialty;

    public Player()
    {
      _nickName = "Murduk";
      _race = Race.Ork;
      _specialty = Specialty.Rogue;
    }

    public Player(string nickName, Race race, Specialty specialty)
    {
      _nickName = nickName;
      _race = race;
      _specialty = specialty;
    }

    public override string ToString()
    {
      return $"{_nickName} - раса: {_race}, класс: {_specialty}";
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