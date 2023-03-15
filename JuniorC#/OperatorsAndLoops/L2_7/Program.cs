Console.Write("Введите имя: ");
string userName = Console.ReadLine();
Console.Write("Укажите желаемый символ: ");
char symbol = Convert.ToChar(Console.Read());
string pictureFrame = "";

for (int i = 0; i < userName.Length; i++)
{
  pictureFrame += symbol;
}

string middleLine = $"{symbol}{userName}{symbol}";
string EdgeLine = $"{symbol}{pictureFrame}{symbol}";

Console.WriteLine($"\n{EdgeLine}");
Console.WriteLine(middleLine);
Console.WriteLine(EdgeLine);