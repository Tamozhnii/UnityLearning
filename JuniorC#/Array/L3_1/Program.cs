int[,] array = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
int sumOfSecondLine = 0;
int secondLineIndex = 1;
int multiplicationOfFirstColumn = 0;
int firstColumnIndex = 0;

for (int i = 0; i < array.GetLength(1); i++)
{
  sumOfSecondLine += array[secondLineIndex, i];
}

for (int j = 0; j < array.GetLength(0); j++)
{
  multiplicationOfFirstColumn += array[j, firstColumnIndex];
}

Console.WriteLine($"Сумма второй строки = {sumOfSecondLine}, произведение первого столбца = {multiplicationOfFirstColumn}");
