const string CommandAddDossier = "1";
const string CommandShowAllDossiers = "2";
const string CommandRemoveDossier = "3";
const string CommandSearchDossier = "4";
const string CommandExit = "5";

string[] fullNamesArray = new string[] { };
string[] positionsArray = new string[] { };
bool isProgramOn = true;

void AddNewDossier(string fullName, string position)
{
  string[] tempFullNamesArray = new string[fullNamesArray.Length + 1];
  string[] tempPositionsArray = new string[positionsArray.Length + 1];

  for (int i = 0; i < fullNamesArray.Length; i++)
  {
    tempFullNamesArray[i] = fullNamesArray[i];
  }

  for (int i = 0; i < positionsArray.Length; i++)
  {
    tempPositionsArray[i] = positionsArray[i];
  }

  tempFullNamesArray[fullNamesArray.Length] = fullName;
  tempPositionsArray[positionsArray.Length] = position;
  fullNamesArray = tempFullNamesArray;
  positionsArray = tempPositionsArray;
  Console.WriteLine("Досье добавлено");
}

void ShowAllDossiers()
{
  if (fullNamesArray.Length > 0)
  {
    for (int i = 0; i < fullNamesArray.Length; i++)
    {
      Console.WriteLine($"{i + 1}. {fullNamesArray[i]} - {positionsArray[i]}");
    }
  }
  else
  {
    Console.WriteLine("Список  пуст");
  }
}

void SearchDossier(string surname)
{
  if (fullNamesArray.Length > 0)
  {
    for (int i = 0; i < fullNamesArray.Length; i++)
    {
      if (fullNamesArray[i].Contains(surname))
      {
        Console.WriteLine($"{i + 1}. {fullNamesArray[i]} - {positionsArray[i]}");
      }
      else
      {
        Console.WriteLine($"Досье по фамилии {surname} не найдено");
      }
    }
  }
  else
  {
    Console.WriteLine("Данные для поиска отсутствуют");
  }
}

void RemoveDossier(int sequenceNumber)
{
  if (fullNamesArray.Length >= sequenceNumber)
  {
    string[] tempFullNamesArray = new string[fullNamesArray.Length - 1];
    string[] tempPositionsArray = new string[positionsArray.Length - 1];

    for (int i = 0; i < fullNamesArray.Length; i++)
    {
      if (i != sequenceNumber - 1)
      {
        if (i > sequenceNumber - 1)
        {
          tempFullNamesArray[i - 1] = fullNamesArray[i];
        }
        else
        {
          tempFullNamesArray[i] = fullNamesArray[i];
        }
      }
    }

    for (int j = 0; j < positionsArray.Length; j++)
    {
      if (j != sequenceNumber - 1)
      {
        if (j > sequenceNumber - 1)
        {
          tempPositionsArray[j - 1] = positionsArray[j];
        }
        else
        {
          tempPositionsArray[j] = positionsArray[j];
        }
      }
    }

    fullNamesArray = tempFullNamesArray;
    positionsArray = tempPositionsArray;
    Console.WriteLine("Досье успешно удалено");
  }
  else
  {
    Console.WriteLine("Такого досье не существует");
  }
}

while (isProgramOn)
{
  Console.WriteLine("Здравствуйте! Выбирите нужную команду:");
  Console.WriteLine($"{CommandAddDossier}. Добавить новое досье");
  Console.WriteLine($"{CommandShowAllDossiers}. Показать все досье");
  Console.WriteLine($"{CommandRemoveDossier}. Удалить досье");
  Console.WriteLine($"{CommandSearchDossier}. Найти досье по фамилии");
  Console.WriteLine($"{CommandExit}. Выйти");
  string userCommand = Console.ReadLine();

  switch (userCommand)
  {
    case CommandAddDossier:
      Console.Write("\nВведите фамилию: ");
      string surname = Console.ReadLine();
      Console.Write("Введите имя: ");
      string name = Console.ReadLine();
      Console.Write("Введите отчество: ");
      string patronymic = Console.ReadLine();
      Console.Write("Введите должность: ");
      string position = Console.ReadLine();
      string fullName = $"{surname} {name} {patronymic}";
      AddNewDossier(fullName, position);
      Console.ReadKey();
      break;

    case CommandShowAllDossiers:
      ShowAllDossiers();
      Console.ReadKey();
      break;

    case CommandRemoveDossier:
      Console.Write("\nУкажите номер досье которое хотите удалить: ");
      int sequenceNumber = Convert.ToInt32(Console.ReadLine());
      RemoveDossier(sequenceNumber);
      Console.ReadKey();
      break;

    case CommandSearchDossier:
      Console.Write("\nКакую фамилию ищите?: ");
      string searchSurname = Console.ReadLine();
      SearchDossier(searchSurname);
      Console.ReadKey();
      break;

    case CommandExit:
      isProgramOn = false;
      break;

    default:
      Console.WriteLine("Неверная команда");
      break;
  }

  Console.Clear();
}
