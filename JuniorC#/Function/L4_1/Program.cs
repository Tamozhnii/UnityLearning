using System;

namespace L4_1
{
  class Program
  {
    static void Main(string[] args)
    {
      const string CommandAddDossier = "1";
      const string CommandShowAllDossiers = "2";
      const string CommandRemoveDossier = "3";
      const string CommandSearchDossier = "4";
      const string CommandExit = "5";

      char separator = ' ';
      bool isProgramOn = true;
      string[] fullNamesArray = new string[] { };
      string[] positionsArray = new string[] { };

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
            AddNewDossier(ref fullNamesArray, ref positionsArray, separator);
            break;

          case CommandShowAllDossiers:
            ShowAllDossiers(fullNamesArray, positionsArray);
            break;

          case CommandRemoveDossier:
            RemoveDossier(ref fullNamesArray, ref positionsArray);
            break;

          case CommandSearchDossier:
            SearchDossier(fullNamesArray, positionsArray, separator);
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
    }

    private static string[] AddElementIntoArray(string[] array, string element)
    {
      string[] tempArray = new string[array.Length + 1];

      for (int i = 0; i < array.Length; i++)
      {
        tempArray[i] = array[i];
      }

      tempArray[array.Length] = element;
      array = tempArray;
      return array;
    }

    private static void AddNewDossier(ref string[] fullNamesArray, ref string[] positionsArray, char separator)
    {
      Console.Write("\nВведите фамилию: ");
      string surname = Console.ReadLine();
      Console.Write("Введите имя: ");
      string name = Console.ReadLine();
      Console.Write("Введите отчество: ");
      string patronymic = Console.ReadLine();
      Console.Write("Введите должность: ");
      string position = Console.ReadLine();
      string fullName = surname + separator + name + separator + patronymic;
      fullNamesArray = AddElementIntoArray(fullNamesArray, fullName);
      positionsArray = AddElementIntoArray(positionsArray, position);
      Console.WriteLine("Досье добавлено");
      Console.ReadKey();
    }

    private static void ShowAllDossiers(string[] fullNamesArray, string[] positionsArray)
    {
      if (fullNamesArray.Length > 0)
      {
        for (int i = 0; i < fullNamesArray.Length; i++)
        {
          int sequenceNumber = i + 1;
          Console.WriteLine($"{sequenceNumber}. {fullNamesArray[i]} - {positionsArray[i]}");
        }
      }
      else
      {
        Console.WriteLine("Список  пуст");
      }

      Console.ReadKey();
    }

    private static void SearchDossier(string[] fullNamesArray, string[] positionsArray, char separator)
    {
      Console.Write("\nКакую фамилию ищите?: ");
      string searchSurname = Console.ReadLine();

      if (fullNamesArray.Length > 0)
      {
        int surnameIndex = 0;
        bool isNotFound = true;

        for (int i = 0; i < fullNamesArray.Length; i++)
        {
          string currentSurname = fullNamesArray[i].Split(separator)[surnameIndex];

          if (currentSurname.ToLower() == searchSurname.ToLower())
          {
            isNotFound = false;
            int sequenceNumber = i + 1;
            Console.WriteLine($"{sequenceNumber}. {fullNamesArray[i]} - {positionsArray[i]}");
          }
        }

        if (isNotFound)
        {
          Console.WriteLine($"Досье по фамилии {searchSurname} не найдено");
        }
      }
      else
      {
        Console.WriteLine("Данные для поиска отсутствуют");
      }

      Console.ReadKey();
    }

    private static void RemoveElementIntoArray(ref string[] array, int index)
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

    private static void RemoveDossier(ref string[] fullNamesArray, ref string[] positionsArray)
    {
      int firstElementIndex = 0;
      Console.Write("\nУкажите номер досье которое хотите удалить: ");
      int sequenceNumber = Convert.ToInt32(Console.ReadLine());

      if (fullNamesArray.Length >= sequenceNumber && sequenceNumber > firstElementIndex)
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
  }
}
