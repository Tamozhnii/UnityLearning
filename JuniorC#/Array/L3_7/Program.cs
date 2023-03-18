string sentence = "Это программа по разделению строки на слова";
string[] words = sentence.Split(' ');

foreach (string word in words)
{
  Console.WriteLine(word);
}
