char leftBracket = '(';
char rightBracket = ')';
Console.Write("Введите строку для проверки: ");
string userValue = Console.ReadLine();
int normalState = 0;
int deep = 0;
int counter = 0;

foreach (var symbol in userValue)
{
  if (symbol == leftBracket)
  {
    counter++;
  }
  else if (symbol == rightBracket)
  {
    counter--;
  }

  if (deep < counter)
  {
    deep = counter;
  }

  if (counter < normalState)
  {
    break;
  }
}

if (counter == normalState)
{
  Console.WriteLine($"Строка корректная, глубина равняется {deep}");
}
else
{
  Console.WriteLine($"Строка не корректная");
}
