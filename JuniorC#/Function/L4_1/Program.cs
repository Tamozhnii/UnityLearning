const string CommandAddDossier = "1";
const string CommandShowAllDossiers = "2";
const string CommandRemoveDossier = "3";
const string CommandSearchDossier = "4";
const string CommandExit = "5";

string[] fullNamesArray = new string[] { };
string[] positionsArray = new string[] { };
bool isProgramOn = true;

void AddElementIntoArray(ref string[] array, string element)
{
  string[] tempArray = new string[array.Length + 1];

  for (int i = 0; i < array.Length; i++)
  {
    tempArray[i] = array[i];
  }

  tempArray[array.Length] = element;
  array = tempArray;
}

void AddNewDossier(string fullName, string position)
{
  Console.Write("\nВведите фамилию: ");
  string surname = Console.ReadLine();
  Console.Write("Введите имя: ");
  string name = Console.ReadLine();
  Console.Write("Введите отчество: ");
  string patronymic = Console.ReadLine();
  Console.Write("Введите должность: ");
  string position = Console.ReadLine();
  string fullName = $"{surname} {name} {patronymic}";
  AddElementIntoArray(ref fullNamesArray, fullName);
  AddElementIntoArray(ref positionsArray, position);
  Console.WriteLine("Досье добавлено");
  Console.ReadKey();
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
  Console.ReadKey();
}

void SearchDossier(string surname)
{
  Console.Write("\nКакую фамилию ищите?: ");
  string searchSurname = Console.ReadLine();

  if (fullNamesArray.Length > 0)
  {
    int surnameIndex = 0;

    for (int i = 0; i < fullNamesArray.Length; i++)
    {
      string currentSurname = fullNamesArray[i].Split(' ')[surnameIndex];

      if (currentSurname == surname)
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

  Console.ReadKey();
}

void RemoveElementIntoArray(ref string[] array, int index)
{
  string[] tempArray = new string[array.Length - 1];

  for (int i = 0; i < index; i++)
  {
    tempArray[i] = array[i];
  }

  for (int i = index + 1; i < array.Length; i++)
  {
    tempArray[i - 1] = array[i];
  }

  array = tempArray;
}

void RemoveDossier(int sequenceNumber)
{
  Console.Write("\nУкажите номер досье которое хотите удалить: ");
  int sequenceNumber = Convert.ToInt32(Console.ReadLine());

  if (fullNamesArray.Length >= sequenceNumber)
  {
    RemoveElementIntoArray(ref fullNamesArray, sequenceNumber - 1);
    RemoveElementIntoArray(ref positionsArray, sequenceNumber - 1);
    Console.WriteLine("Досье успешно удалено");
  }
  else
  {
    Console.WriteLine("Такого досье не существует");
  }

  Console.ReadKey();
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
      AddNewDossier(fullName, position);
      break;

    case CommandShowAllDossiers:
      ShowAllDossiers();
      break;

    case CommandRemoveDossier:
      RemoveDossier(sequenceNumber);
      break;

    case CommandSearchDossier:
      SearchDossier(searchSurname);
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
