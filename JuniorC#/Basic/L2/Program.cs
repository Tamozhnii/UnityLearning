namespace L2;
class Program
{
  static void Main(string[] args)
  {
    // Console.SetCursorPosition(1, 20);
    Console.WriteLine("Приветствую!");
    Console.WriteLine("\nКак тебя зовут?: ");
    string name = Console.ReadLine();
    Console.WriteLine("\nСколько тебе лет?: ");
    int age = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("\nГде ты работаешь?: ");
    string workPlace = Console.ReadLine();
    Console.WriteLine("\nКакой твой знак зодиака?: ");
    string zodiacSign = Console.ReadLine();
    Console.WriteLine($"\n\nТебя зовут {name}, тебе {age} лет, твой знак - {zodiacSign} и ты работаешь в/на {workPlace}!");

    Console.ReadKey();
  }
}
