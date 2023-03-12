string userCommand = "";

Console.WriteLine("Добро пожаловать в VIM");

while (userCommand.ToLower() != "exit")
{
  Console.Write("Введите команду: ");
  userCommand = Console.ReadLine();
}
