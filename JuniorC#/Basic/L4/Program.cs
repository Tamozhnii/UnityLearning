//С использованием 3-ей переменной
string firstName = "Tarantino";
string surname = "Quentin";

Console.WriteLine($"Имя - {firstName} и фамилия - {surname}");

string swapBuffer = firstName;
firstName = surname;
surname = swapBuffer;

Console.WriteLine($"Имя - {firstName} и фамилия - {surname}\n");

//Без использования 3-ей переменной
firstName = "Ritchie";
surname = "Guy";

Console.WriteLine($"Имя - {firstName} и фамилия - {surname}");

firstName += surname;
surname = firstName.Replace(surname, "");
firstName = firstName.Replace(surname, "");

Console.WriteLine($"Имя - {firstName} и фамилия - {surname}");
