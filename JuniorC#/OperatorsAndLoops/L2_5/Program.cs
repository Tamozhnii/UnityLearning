bool isOpen = true;
float exchangeRateBYNToRUB = 30f;
float exchangeRate10RUBToBYN = 0.25f;
float exchangeRateCNHToRUB = 9f;
float exchangeRate10RUBToCNH = 0.9f;
float balanceInRUB = 1000f;
float balanceInBYN = 100f;
float balanceInCNH = 0;
int per10RUB = 10;


while (isOpen)
{
  Console.WriteLine("Вас приветствует обменный пункт!\n");
  Console.WriteLine("Курс валют: (Покупка / Продажа)");
  Console.WriteLine($"RUB/BYN - {exchangeRate10RUBToBYN}(за 10 руб.) / {exchangeRateBYNToRUB}");
  Console.WriteLine($"RUB/CNH - {exchangeRate10RUBToCNH}(за 10 руб.) / {exchangeRateCNHToRUB}");
  Console.WriteLine("\n\nВозможные операции:");
  Console.WriteLine("1. Посмотреть текущий баланс");
  Console.WriteLine("2. Купить BYN");
  Console.WriteLine("3. Продать BYN");
  Console.WriteLine("4. Купить CNH");
  Console.WriteLine("5. Продать CNH");
  Console.WriteLine("6. Завершить работу");
  Console.Write("\nВведите команду: ");
  int userCommand = Convert.ToInt32(Console.ReadLine());
  float numberRUB;
  float numberBYN;
  float numberCNH;

  switch (userCommand)
  {
    case 1:
      Console.WriteLine($"\nВаш баланс составляет: RUB - {balanceInRUB}, BYN - {balanceInBYN}, CNH - {balanceInCNH}");
      break;
    case 2:
      Console.WriteLine("\nСколько вы желаете поменять: ");
      numberRUB = Convert.ToInt32(Console.ReadLine());
      if (numberRUB <= balanceInRUB)
      {
        balanceInRUB -= numberRUB;
        balanceInBYN += numberRUB / per10RUB * exchangeRate10RUBToBYN;
        Console.WriteLine($"\nВаш баланс составляет: RUB - {balanceInRUB}, BYN - {balanceInBYN}, CNH - {balanceInCNH}");
      }
      else
      {
        Console.WriteLine("\nНедостаточно стредств");
      }
      break;
    case 3:
      Console.WriteLine("\nСколько вы желаете продать: ");
      numberBYN = Convert.ToInt32(Console.ReadLine());
      if (numberBYN <= balanceInBYN)
      {
        balanceInBYN -= numberBYN;
        balanceInRUB += numberBYN * exchangeRateBYNToRUB;
        Console.WriteLine($"\nВаш баланс составляет: RUB - {balanceInRUB}, BYN - {balanceInBYN}, CNH - {balanceInCNH}");
      }
      else
      {
        Console.WriteLine("\nНедостаточно стредств");
      }
      break;
    case 4:
      Console.WriteLine("\nСколько вы желаете поменять: ");
      numberRUB = Convert.ToInt32(Console.ReadLine());
      if (numberRUB <= balanceInRUB)
      {
        balanceInRUB -= numberRUB;
        balanceInCNH += numberRUB / per10RUB * exchangeRate10RUBToCNH;
        Console.WriteLine($"\nВаш баланс составляет: RUB - {balanceInRUB}, BYN - {balanceInBYN}, CNH - {balanceInCNH}");
      }
      else
      {
        Console.WriteLine("\nНедостаточно стредств");
      }
      break;
    case 5:
      Console.WriteLine("\nСколько вы желаете продать: ");
      numberCNH = Convert.ToInt32(Console.ReadLine());
      if (numberCNH <= balanceInCNH)
      {
        balanceInCNH -= numberCNH;
        balanceInRUB += numberCNH * exchangeRateCNHToRUB;
        Console.WriteLine($"\nВаш баланс составляет: RUB - {balanceInRUB}, BYN - {balanceInBYN}, CNH - {balanceInCNH}");
      }
      else
      {
        Console.WriteLine("\nНедостаточно стредств");
      }
      break;
    case 6:
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
