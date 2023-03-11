namespace L2;
class Program
{
  static void Main(string[] args)
  {
    // Console.SetCursorPosition(1, 20);
    Console.WriteLine("Приветствую!");
    Console.WriteLine("\nКак тебя зовут?: ");
    var name = Console.ReadLine();
    Console.WriteLine("\nСколько тебе лет?: ");
    var age = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("\nГде ты работаешь?: ");
    var workPlace = Console.ReadLine();
    Console.WriteLine("\nКакой твой знак зодиака?: ");
    var zodiac = Console.ReadLine();
    Console.WriteLine($"\n\nТебя зовут {name}, тебе {age} лет, твой знак - {zodiac} и ты работаешь в/на {workPlace}!");

    Console.ReadKey();
  }
}
