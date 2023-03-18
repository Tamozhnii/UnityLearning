const string CommandSum = "sum";
const string CommandExit = "exit";

int[] array = new int[1];
string userCommand = "";
Console.WriteLine("Введите числа для подсчета суммы:");

while (userCommand != CommandExit)
{
  if (userCommand == CommandSum)
  {
    array = new int[1];
  }

  userCommand = Console.ReadLine();

  switch (userCommand)
  {
    case CommandSum:
      int sum = 0;

      foreach (int num in array)
      {
        sum += num;
      }

      Console.WriteLine($"{sum}\n");
      break;

    case CommandExit:
      break;

    default:
      int[] tempArray = new int[array.Length + 1];

      for (int i = 0; i < array.Length; i++)
      {
        tempArray[i] = array[i];
      }

      tempArray[tempArray.Length - 1] = Convert.ToInt32(userCommand);
      array = tempArray;
      break;
  }
}
