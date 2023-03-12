int step = 7;
int beginValue = 5;
int maxValue = 96;

for (int i = beginValue; i <= maxValue; i += step)
{
  Console.Write($"{i} ");
}

Console.ReadKey();
