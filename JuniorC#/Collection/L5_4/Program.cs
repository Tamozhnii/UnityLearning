using System;

namespace L5_4
{
  class Program
  {
    static void Main(string[] args)
    {
      const string CommandAddDossier = "1";
      const string CommandShowAllDossiers = "2";
      const string CommandRemoveDossier = "3";
      const string CommandExit = "4";

      bool isProgramOn = true;
      Dictionary<string, string> dossiers = new Dictionary<string, string>();

      while (isProgramOn)
      {
        Console.WriteLine("Здравствуйте! Выбирите нужную команду:");
        Console.WriteLine($"{CommandAddDossier}. Добавить новое досье");
        Console.WriteLine($"{CommandShowAllDossiers}. Показать все досье");
        Console.WriteLine($"{CommandRemoveDossier}. Удалить досье");
        Console.WriteLine($"{CommandExit}. Выйти");
        string userCommand = Console.ReadLine();

        switch (userCommand)
        {
          case CommandAddDossier:
            AddNewDossier(dossiers);
            break;

          case CommandShowAllDossiers:
            ShowAllDossiers(dossiers);
            break;

          case CommandRemoveDossier:
            RemoveDossier(dossiers);
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

    private static void AddNewDossier(Dictionary<string, string> dossiers)
    {
      Console.Write("\nВведите ФИО: ");
      string fullName = Console.ReadLine();
      Console.Write("Введите должность: ");
      string position = Console.ReadLine();

      if (dossiers.ContainsKey(fullName))
      {
        Console.WriteLine("Досье на данного пользователя уже существует");
      }
      else
      {
        dossiers.Add(fullName, position);
        Console.WriteLine("Досье добавлено");
      }

      Console.ReadKey();
    }

    private static void ShowAllDossiers(Dictionary<string, string> dossiers)
    {
      if (dossiers.Count > 0)
      {
        foreach (var dossier in dossiers)
        {
          Console.WriteLine($"{dossier.Key} - {dossier.Value}");
        }
      }
      else
      {
        Console.WriteLine("Список  пуст");
      }

      Console.ReadKey();
    }

    private static void RemoveDossier(Dictionary<string, string> dossiers)
    {
      Console.Write("\nУкажите ФИО, досье которого, вы хотите удалить: ");
      string fullName = Console.ReadLine();

      if (dossiers.ContainsKey(fullName))
      {
        dossiers.Remove(fullName);
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
