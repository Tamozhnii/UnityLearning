Console.Write("Введите имя: ");
string userName = Console.ReadLine();
Console.Write("Укажите желаемый символ: ");
char symbol = Convert.ToChar(Console.Read());
string pictureFrame = "";

for (int i = 0; i <= userName.Length + 1; i++)
{
  pictureFrame += symbol;
}

string picture = $"\n{pictureFrame}\n{symbol}{userName}{symbol}\n{pictureFrame}";

Console.WriteLine(picture);