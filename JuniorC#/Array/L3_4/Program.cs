const string CommandSum = "sum";
const string CommandExit = "exit";
bool isProgramRun = true;

int[] numbers = { };
string userCommand = "";
Console.WriteLine("Введите числа для подсчета суммы:");

while (isProgramRun)
{
  userCommand = Console.ReadLine();

  switch (userCommand)
  {
    case CommandSum:
      int sum = 0;

      foreach (int num in numbers)
      {
        sum += num;
      }

      Console.WriteLine($"Сумма = {sum}");
      break;

    case CommandExit:
      isProgramRun = false;
      break;

    default:
      int[] tempArray = new int[numbers.Length + 1];

      for (int i = 0; i < numbers.Length; i++)
      {
        tempArray[i] = numbers[i];
      }

      tempArray[tempArray.Length - 1] = Convert.ToInt32(userCommand);
      numbers = tempArray;
      break;
  }
}
