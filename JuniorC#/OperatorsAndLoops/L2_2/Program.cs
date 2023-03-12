string exitCommand = "exit";
string userCommand = "";

Console.WriteLine("Добро пожаловать в VIM\n");

while (userCommand.ToLower() != exitCommand)
{
  Console.Write("Введите команду: ");
  userCommand = Console.ReadLine();
}
