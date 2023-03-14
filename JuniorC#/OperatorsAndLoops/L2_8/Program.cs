string sectretPassword = "password";
int attempts = 3;

for (int i = 0; i < attempts; i++)
{
  Console.Write("Введите пароль: ");
  string userPassword = Console.ReadLine();

  if (userPassword.ToLower() == sectretPassword)
  {
    Console.WriteLine("\nВас приветствует тайное общество!");
    Console.ReadKey();
    break;
  }
  else
  {
    if (i < 2)
    {
      Console.WriteLine("\nНеверный пароль");
    }
    else
    {
      Console.WriteLine("\nВам здесь не рады!");
    }

    Console.ReadKey();
  }

  Console.Clear();
}
