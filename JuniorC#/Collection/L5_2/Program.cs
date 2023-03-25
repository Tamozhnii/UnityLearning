using System;

namespace L5_2
{
  class Program
  {
    static void Main(string[] args)
    {
      Queue<int> customers = new Queue<int>();
      InitializeQueue(customers);
      ServeCustomer(customers);
    }

    static void InitializeQueue(Queue<int> queue)
    {
      Random random = new Random();
      int customersCount = 5;
      int maxPurchase = 100;

      for (int i = 0; i < customersCount; i++)
      {
        queue.Enqueue(random.Next(maxPurchase));
      }
    }

    static void ServeCustomer(Queue<int> customers)
    {
      int balance = 0;

      while (customers.Count > 0)
      {
        int customerBuying = customers.Dequeue();
        balance += customerBuying;
        Console.WriteLine($"На ваш баланс поступило {customerBuying}$\nТекущий баланс составляет {balance}$\n");
        Console.ReadKey();
        Console.Clear();
      }
    }
  }
}