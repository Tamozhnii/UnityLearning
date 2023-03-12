int step = 7;
int beginValue = 5;
int maxValue = 100;

for (int i = beginValue; i < maxValue; i += step)
{
  Console.Write($"{i} ");
}

Console.ReadKey();
