int crystalCount = 0;
int pricePerCrystal = 7;

Console.Write("Введите сколько у вас в наличии золота: ");
int goldAmount = Convert.ToInt32(Console.ReadLine());
Console.Clear();

Console.WriteLine("\nДобро пожаловать в лавку!\n");
Console.WriteLine($"Здраствуйте, стоимость 1 кристалла составляет {pricePerCrystal} золотых.");
Console.WriteLine("Сколько кристаллов вы желаете приобрести?");
int desiredAmount = Convert.ToInt32(Console.ReadLine());

goldAmount -= desiredAmount * pricePerCrystal;
crystalCount = desiredAmount;

Console.WriteLine($"\nПоздравляем за покупку, вы получили {crystalCount} кристаллов и у вас осталось {goldAmount} золота.");
Console.ReadKey();
