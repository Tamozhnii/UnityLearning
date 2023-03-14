const string CommandViewProfile = "ViewProfile";
const string CommandSetName = "SetName";
const string CommandSetSurname = "SetSurname";
const string CommandSetAge = "SetAge";
const string CommandPublishProfile = "Publish";
const string CommandDeleteProfile = "Delete";
const string CommandExit = "Exit";

bool isProgramWork = true;
string userName = null;
string userSurname = null;
int userAge = 0;

while (isProgramWork)
{
  Console.WriteLine("Добро пожаловать!\n");
  Console.WriteLine("Доступные команды:");
  Console.WriteLine($"Просмотреть профиль - {CommandViewProfile}");
  Console.WriteLine($"Ввести имя - {CommandSetName}");
  Console.WriteLine($"Ввести фамилию - {CommandSetSurname}");
  Console.WriteLine($"Ввести возраст - {CommandSetAge}");
  Console.WriteLine($"Опубликовать профиль - {CommandPublishProfile}");
  Console.WriteLine($"Удалить профиль и очистить поля - {CommandDeleteProfile}");
  Console.WriteLine($"Выйти из программы - {CommandExit}");
  Console.Write("\nВведите команду: ");
  string userCommand = Console.ReadLine();

  switch (userCommand)
  {
    case CommandViewProfile:
      if (userName != null && userSurname != null && userAge != 0)
      {
        Console.WriteLine($"\nИмя - {userName}, фамилия - {userSurname}, возраст - {userAge}");
      }
      else
      {
        Console.WriteLine($"\nЗаполните анкету!");
      }

      Console.ReadKey();
      Console.Clear();
      break;

    case CommandSetName:
      Console.Write("\nВведите свое имя: ");
      userName = Console.ReadLine();
      Console.Clear();
      break;

    case CommandSetSurname:
      Console.Write("\nВведите свою фамилию: ");
      userSurname = Console.ReadLine();
      Console.Clear();
      break;

    case CommandSetAge:
      Console.Write("\nВведите свой возраст: ");
      userAge = Convert.ToInt32(Console.ReadLine());
      Console.Clear();
      break;

    case CommandPublishProfile:
      if (userName != null && userSurname != null && userAge != 0)
      {
        Console.Write("\nВаш профиль был успешно опубликован!");
      }
      else
      {
        Console.WriteLine($"\nЗаполните анкету!");
      }

      Console.ReadKey();
      Console.Clear();
      break;

    case CommandDeleteProfile:
      userName = null;
      userSurname = null;
      userAge = 0;
      Console.Write("\nВаш профиль был удален!");
      Console.ReadKey();
      Console.Clear();
      break;

    case CommandExit:
      isProgramWork = false;
      break;

    default:
      Console.Write("\nНеизвестная команда, попробуйте снова");
      Console.ReadKey();
      Console.Clear();
      break;
  }
}
