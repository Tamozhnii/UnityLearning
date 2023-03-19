string sentence = "Это программа по разделению строки на слова";
char splitValue = ' ';
string[] words = sentence.Split(splitValue);

foreach (string word in words)
{
  Console.WriteLine(word);
}
