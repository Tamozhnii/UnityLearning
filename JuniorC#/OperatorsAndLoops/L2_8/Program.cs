string secretPassword = "password";
int attempts = 3;

for (int i = 1; i <= attempts; i++)
{
  Console.Write("Введите пароль: ");
  string userPassword = Console.ReadLine();

  if (userPassword == secretPassword)
  {
    Console.WriteLine("\nВас приветствует тайное общество!");
    Console.ReadKey();
    break;
  }

  if (i < attempts)
  {
    Console.WriteLine("\nНеверный пароль");
  }
  else
  {
    Console.WriteLine("\nВам здесь не рады!");
  }

  Console.ReadKey();
  Console.Clear();
}
