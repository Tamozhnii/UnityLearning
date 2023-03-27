using System;

namespace L6_1
{
  class Program
  {
    static void Main(string[] args)
    {
      Player player1 = new Player();
      Player player2 = new Player("Aragorn", Races.Human, Specialties.Warrior);
      Console.WriteLine(player1.ToString());
      Console.WriteLine(player2.ToString());
    }
  }

  class Player
  {
    private string _nickName;
    private Races _race;
    private Specialties _specialty;

    public Player()
    {
      _nickName = "Murduk";
      _race = Races.Ork;
      _specialty = Specialties.Rogue;
    }

    public Player(string nickName, Races race, Specialties specialty)
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

  enum Races
  {
    Elf,
    Human,
    Dwarf,
    Ork,
  }

  enum Specialties
  {
    Warrior,
    Magician,
    Rogue,
    Hunter,
  }
}