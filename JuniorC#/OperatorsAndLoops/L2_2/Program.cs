string exitCommand = "exit";
string userCommand = "";

Console.WriteLine("Добро пожаловать в VIM\n");

while (userCommand.ToLower() != "exit")
{
  Console.Write("Введите команду: ");
  userCommand = Console.ReadLine();
}
