﻿const string CommandViewBalance = "1";
const string CommandConvertRUBToBYN = "2";
const string CommandConvertBYNToRUB = "3";
const string CommandConvertRUBToCNH = "4";
const string CommandConvertCNHToRUB = "5";
const string CommandConvertBYNToCNH = "6";
const string CommandConvertCNHToBYN = "7";
const string CommandExit = "8";

float ExchangeRateBYNToRUB = 30f;
float ExchangeRateRUBToBYN = 0.025f;
float ExchangeRateCNHToRUB = 9f;
float ExchangeRateRUBToCNH = 0.09f;
float ExchangeRateBYNToCNH = 3f;
float ExchangeRateCNHToBYN = 0.3f;
bool isOpen = true;
float balanceInRUB = 1000f;
float balanceInBYN = 100f;
float balanceInCNH = 0;

while (isOpen)
{
  float userInputNumber = 0;
  Console.WriteLine("Вас приветствует обменный пункт!\n");
  Console.WriteLine("Курс валют: (Покупка / Продажа)");
  Console.WriteLine($"RUB/BYN - {ExchangeRateRUBToBYN} / {ExchangeRateBYNToRUB}");
  Console.WriteLine($"RUB/CNH - {ExchangeRateRUBToCNH} / {ExchangeRateCNHToRUB}");
  Console.WriteLine($"BYN/CNH - {ExchangeRateBYNToCNH} / {ExchangeRateCNHToBYN}");
  Console.WriteLine("\n\nВозможные операции:");
  Console.WriteLine("1. Посмотреть текущий баланс");
  Console.WriteLine("2. Купить BYN");
  Console.WriteLine("3. Продать BYN");
  Console.WriteLine("4. Купить CNH");
  Console.WriteLine("5. Продать CNH");
  Console.WriteLine("6. Купить CNH за BYN");
  Console.WriteLine("7. Купить BYN за CNH");
  Console.WriteLine("8. Завершить работу");
  Console.Write("\nВведите команду: ");
  string userCommand = Console.ReadLine();

  switch (userCommand)
  {
    case CommandViewBalance:
      Console.WriteLine($"\nВаш баланс составляет: RUB - {balanceInRUB}, BYN - {balanceInBYN}, CNH - {balanceInCNH}");
      break;

    case CommandConvertRUBToBYN:
      Console.WriteLine("\nСколько вы желаете поменять: ");
      userInputNumber = Convert.ToInt32(Console.ReadLine());

      if (userInputNumber <= balanceInRUB)
      {
        balanceInRUB -= userInputNumber;
        balanceInBYN += userInputNumber * ExchangeRateRUBToBYN;
        Console.WriteLine($"\nВаш баланс составляет: RUB - {balanceInRUB}, BYN - {balanceInBYN}, CNH - {balanceInCNH}");
      }
      else
      {
        Console.WriteLine("\nНедостаточно стредств");
      }

      break;

    case CommandConvertBYNToRUB:
      Console.WriteLine("\nСколько вы желаете продать: ");
      userInputNumber = Convert.ToInt32(Console.ReadLine());

      if (userInputNumber <= balanceInBYN)
      {
        balanceInBYN -= userInputNumber;
        balanceInRUB += userInputNumber * ExchangeRateBYNToRUB;
        Console.WriteLine($"\nВаш баланс составляет: RUB - {balanceInRUB}, BYN - {balanceInBYN}, CNH - {balanceInCNH}");
      }
      else
      {
        Console.WriteLine("\nНедостаточно стредств");
      }

      break;

    case CommandConvertRUBToCNH:
      Console.WriteLine("\nСколько вы желаете поменять: ");
      userInputNumber = Convert.ToInt32(Console.ReadLine());

      if (userInputNumber <= balanceInRUB)
      {
        balanceInRUB -= userInputNumber;
        balanceInCNH += userInputNumber * ExchangeRateRUBToCNH;
        Console.WriteLine($"\nВаш баланс составляет: RUB - {balanceInRUB}, BYN - {balanceInBYN}, CNH - {balanceInCNH}");
      }
      else
      {
        Console.WriteLine("\nНедостаточно стредств");
      }

      break;

    case CommandConvertCNHToRUB:
      Console.WriteLine("\nСколько вы желаете продать: ");
      userInputNumber = Convert.ToInt32(Console.ReadLine());

      if (userInputNumber <= balanceInCNH)
      {
        balanceInCNH -= userInputNumber;
        balanceInRUB += userInputNumber * ExchangeRateCNHToRUB;
        Console.WriteLine($"\nВаш баланс составляет: RUB - {balanceInRUB}, BYN - {balanceInBYN}, CNH - {balanceInCNH}");
      }
      else
      {
        Console.WriteLine("\nНедостаточно стредств");
      }

      break;

    case CommandConvertBYNToCNH:
      Console.WriteLine("\nСколько вы желаете продать: ");
      userInputNumber = Convert.ToInt32(Console.ReadLine());

      if (userInputNumber <= balanceInBYN)
      {
        balanceInBYN -= userInputNumber;
        balanceInCNH += userInputNumber * ExchangeRateBYNToCNH;
        Console.WriteLine($"\nВаш баланс составляет: RUB - {balanceInRUB}, BYN - {balanceInBYN}, CNH - {balanceInCNH}");
      }
      else
      {
        Console.WriteLine("\nНедостаточно стредств");
      }

      break;

    case CommandConvertCNHToBYN:
      Console.WriteLine("\nСколько вы желаете продать: ");
      userInputNumber = Convert.ToInt32(Console.ReadLine());

      if (userInputNumber <= balanceInCNH)
      {
        balanceInCNH -= userInputNumber;
        balanceInBYN += userInputNumber * ExchangeRateCNHToBYN;
        Console.WriteLine($"\nВаш баланс составляет: RUB - {balanceInRUB}, BYN - {balanceInBYN}, CNH - {balanceInCNH}");
      }
      else
      {
        Console.WriteLine("\nНедостаточно стредств");
      }

      break;

    case CommandExit:
      isOpen = false;
      Console.WriteLine("\nПриходите снова");
      break;

    default:
      Console.WriteLine("\nДанной команды не существует, попробуйте снова");
      break;
  }

  Console.Write("\nНажмите любую клавишу...");
  Console.ReadKey();
  Console.Clear();
}
