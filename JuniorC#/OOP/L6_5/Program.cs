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
            repository.ShowBooksByName();
            break;

          case CommandFindBooksByAuthor:
            repository.ShowBooksByAuthor();
            break;

          case CommandFindBooksByYear:
            repository.ShowBooksByYear();
            break;

          case CommandFindBooksByGenre:
            repository.ShowBooksByGenre();
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
    public Book(string name, string author, int yearIssue, string genre)
    {
      Name = name;
      Author = author;
      YearIssue = yearIssue;
      Genre = genre;
    }

    public string Name { get; private set; }
    public string Author { get; private set; }
    public int YearIssue { get; private set; }
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
      _books.Add(new Book("Зелёная миля", "Стивен Кинг", 1996, "фэнтезийная драма"));
      _books.Add(new Book("Оно", "Стивен Кинг", 1986, "ужасы"));
      _books.Add(new Book("Мгла", "Стивен Кинг", 1980, "ужасы"));
      _books.Add(new Book("Сияние", "Стивен Кинг", 1977, "ужасы"));
      _books.Add(new Book("Рита Хейуорт и спасение из Шоушенка", "Стивен Кинг", 1982, "драма"));
      _books.Add(new Book("Этюд в багровых тонах", "Артур Конан Дойл", 1887, "детектив"));
      _books.Add(new Book("Знак четырёх", "Артур Конан Дойл", 1890, "детектив"));
      _books.Add(new Book("Собака Баскервилей", "Артур Конан Дойл", 1901, "детектив"));
    }

    public void AddBook()
    {
      int yearIssue = 0;
      Console.Write("Введите название книги: ");
      string name = Console.ReadLine();
      Console.Write("Введите автора: ");
      string author = Console.ReadLine();
      Console.Write("Введите год: ");
      string userYearIssue = Console.ReadLine();
      Console.Write("Введите жанр книги: ");
      string genre = Console.ReadLine();
      bool isValid = name.Trim().Length > 0 && author.Trim().Length > 0 && genre.Trim().Length > 0 && int.TryParse(userYearIssue, out yearIssue);

      if (isValid)
      {
        _books.Add(new Book(name, author, yearIssue, genre));
        Console.WriteLine("Книга добавлена\n");
      }
      else
      {
        Console.WriteLine("Введите корректные данные\n");
      }
    }

    public void RemoveBook()
    {
      Console.Write("Укажите полное название книги которую хотите удалить: ");
      string bookName = Console.ReadLine();
      var book = _books.Find(book => book.Name == bookName);

      if (book != null)
      {
        _books.Remove(book);
        Console.WriteLine("Книга успешно удалена\n");
      }
      else
      {
        Console.WriteLine("Такой книги не существует\n");
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

    public void ShowBooksByName()
    {
      Console.Write("Введите название книги: ");
      string name = Console.ReadLine().ToLower();
      ShowBooks(_books.FindAll(book => book.Name.ToLower().Contains(name)));
    }

    public void ShowBooksByAuthor()
    {
      Console.Write("Введите автора: ");
      string author = Console.ReadLine().ToLower();
      ShowBooks(_books.FindAll(book => book.Author.ToLower().Contains(author)));
    }

    public void ShowBooksByYear()
    {
      int yearIssue = 0;
      Console.Write("Введите год: ");
      string userYearIssue = Console.ReadLine();
      bool isValid = int.TryParse(userYearIssue, out yearIssue);

      if (isValid)
      {
        ShowBooks(_books.FindAll(book => book.YearIssue == yearIssue));
      }
      else
      {
        Console.WriteLine("Невалидные данные");
      }
    }

    public void ShowBooksByGenre()
    {
      Console.Write("Введите жанр: ");
      string genre = Console.ReadLine().ToLower();
      ShowBooks(_books.FindAll(book => book.Genre.ToLower() = genre));
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

