Console.Write("Введите желаемое сообщение: ");
string userMessage = Console.ReadLine();
Console.Write("Сколько раз вывести данное сообщение?: ");
int cyclesCount = Convert.ToInt32(Console.ReadLine());
Console.WriteLine();

for (int i = 1; i <= cyclesCount; i++)
{
  Console.WriteLine($"{i}. {userMessage}");
}

Console.ReadKey();
