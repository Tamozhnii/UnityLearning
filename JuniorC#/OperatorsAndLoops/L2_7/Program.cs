Console.Write("Введите имя: ");
string userName = Console.ReadLine();
Console.Write("Укажите желаемый символ: ");
char symbol = Convert.ToChar(Console.ReadLine());
int pictureFrameLenght = userName.Length + 2;
string pictureFrame = "";

for (int i = 0; i < pictureFrameLenght; i++)
{
  pictureFrame += symbol;
}

Console.WriteLine($"\n{pictureFrame}");
Console.WriteLine($"{symbol}{userName}{symbol}");
Console.WriteLine($"{pictureFrame}");