using Internal;
using System;

namespace L6_5
{
  class Program
  {
    static void Main(string[] args)
    {
      const string CommandShowAllBooks = "-all";
      const string CommandAddBook = "-add";
      const string CommandRemoveBook = "-r";
      const string CommandFindBooksByName = "-f";
      const string CommandFindBooksByAuthor = "-fa";
      const string CommandFindBooksByYear = "-fy";
      const string CommandFindBooksByGenre = "-fg";
      const string CommandExit = "-e";

      bool isOpen = true;
      Repository repository = new Repository();
      repository.Initialize();
      Console.WriteLine("Доступные команды:");
      Console.WriteLine($"Посмотреть все книги: {CommandShowAllBooks}");
      Console.WriteLine($"Добавить книгу: {CommandAddBook}");
      Console.WriteLine($"Удалить книгу: {CommandRemoveBook}");
      Console.WriteLine($"Поиск по названию: {CommandFindBooksByName}");
      Console.WriteLine($"Поиск по автору: {CommandFindBooksByAuthor}");
      Console.WriteLine($"Поиск по году: {CommandFindBooksByYear}");
      Console.WriteLine($"Поиск по жанру: {CommandFindBooksByGenre}");
      Console.WriteLine($"Завершить: {CommandExit}\n");

      while (isOpen)
      {
        string userInput = Console.ReadLine();

        switch (userInput)
        {
          case CommandShowAllBooks:
            repository.ShowAllBooks();
            break;

          case CommandAddBook:
            repository.AddBook();
            break;

          case CommandRemoveBook:
            repository.RemoveBook();
            break;

          case CommandFindBooksByName:
            repository.FindBookByName();
            break;

          case CommandFindBooksByAuthor:
            repository.FindBookByAuthor();
            break;

          case CommandFindBooksByYear:
            repository.FindBookByYear();
            break;

          case CommandFindBooksByGenre:
            repository.FindBookByGenre();
            break;

          case CommandExit:
            isOpen = false;
            break;

          default:
            Console.WriteLine("Введите корректную команду");
            break;
        }
      }
    }
  }

  class Book
  {
    public Book(string name, string author, string yearIssue, string genre)
    {
      Name = name;
      Author = author;
      YearIssue = yearIssue;
      Genre = genre;
    }

    public string Name { get; private set; }
    public string Author { get; private set; }
    public string YearIssue { get; private set; }
    public string Genre { get; private set; }

    public override string ToString()
    {
      return $"{Name}, автор - {Author}, {YearIssue} год, жанр - {Genre}";
    }
  }

  class Repository
  {
    private List<Book> _books;

    public Repository()
    {
      _books = new List<Book>();
    }

    public void Initialize()
    {
      _books.Add(new Book("Зелёная миля", "Стивен Кинг", "1996", "фэнтезийная драма"));
      _books.Add(new Book("Оно", "Стивен Кинг", "1986", "ужасы"));
      _books.Add(new Book("Мгла", "Стивен Кинг", "1980", "ужасы"));
      _books.Add(new Book("Сияние", "Стивен Кинг", "1977", "ужасы"));
      _books.Add(new Book("Рита Хейуорт и спасение из Шоушенка", "Стивен Кинг", "1982", "драма"));
      _books.Add(new Book("Этюд в багровых тонах", "Артур Конан Дойл", "1887", "детектив"));
      _books.Add(new Book("Знак четырёх", "Артур Конан Дойл", "1890", "детектив"));
      _books.Add(new Book("Собака Баскервилей", "Артур Конан Дойл", "1901", "детектив"));
    }

    public void AddBook()
    {
      Console.Write("Введите название книги: ");
      string name = Console.ReadLine();
      Console.Write("Введите автора: ");
      string author = Console.ReadLine();
      Console.Write("Введите год: ");
      string yearIssue = Console.ReadLine();
      Console.Write("Введите жанр книги: ");
      string genre = Console.ReadLine();
      _books.Add(new Book(name, author, yearIssue, genre));
      Console.WriteLine("Книга добавлена\n");
    }

    public void RemoveBook()
    {
      Console.Write("Укажите id книги которую хотите удалить: ");
      string bookId = Console.ReadLine();
      bool isValid = int.TryParse(bookId, out int id);

      if (isValid)
      {
        _books.RemoveAt(id);
        Console.WriteLine("Операция прошла успешно\n");
      }
      else
      {
        Console.WriteLine("Неверные данные\n");
      }
    }

    public void ShowAllBooks()
    {
      for (int i = 0; i < _books.Count; i++)
      {
        Console.WriteLine($"{i}. {_books[i].ToString()}");
      }

      Console.WriteLine();
    }

    public void FindBookByName()
    {
      Console.Write("Введите название книги: ");
      string name = Console.ReadLine();
      ShowBooks(_books.FindAll(b => b.Name == name));
    }

    public void FindBookByAuthor()
    {
      Console.Write("Введите автора: ");
      string author = Console.ReadLine();
      ShowBooks(_books.FindAll(b => b.Author == author));
    }

    public void FindBookByYear()
    {
      Console.Write("Введите год: ");
      string yearIssue = Console.ReadLine();
      ShowBooks(_books.FindAll(b => b.YearIssue == yearIssue));
    }

    public void FindBookByGenre()
    {
      Console.Write("Введите жанр: ");
      string genre = Console.ReadLine();
      ShowBooks(_books.FindAll(b => b.Genre == genre));
    }

    private void ShowBooks(List<Book> books)
    {
      for (int i = 0; i < books.Count; i++)
      {
        Console.WriteLine(books[i].ToString());
      }

      Console.WriteLine();
    }
  }
}

