Console.Write("Введите строку для проверки: ");
string userValue = Console.ReadLine();
int deep = 0;
int counter = 0;

foreach (var symbol in userValue)
{
  if (symbol == '(')
  {
    counter++;
  }
  else if (symbol == ')')
  {
    counter--;
  }

  if (deep < counter)
  {
    deep = counter;
  }

  if (counter < 0)
  {
    break;
  }
}

if (counter == 0)
{
  Console.WriteLine($"Строка корректная, глубина равняется {deep}");
}
else
{
  Console.WriteLine($"Строка не корректная");
}
