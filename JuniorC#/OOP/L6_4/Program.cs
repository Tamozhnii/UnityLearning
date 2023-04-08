using System;

namespace L6_4
{
  class Program
  {
    static void Main(string[] args)
    {
      int playersCount;
      int maxPlayersCount = 5;
      Console.WriteLine("Введите количество игроков:");
      string userInput = Console.ReadLine();
      bool isValid = int.TryParse(userInput, out playersCount);

      if (isValid && playersCount > 0 && playersCount <= maxPlayersCount)
      {
        Table table = new Table(playersCount);
        table.Play();
      }
      else
      {
        Console.WriteLine($"Может быть от 1 до {maxPlayersCount} игрока");
      }
    }
  }

  class Card
  {
    private string _value;
    private string _suit;

    public Card(string value, string suit)
    {
      _value = value;
      _suit = suit;
    }

    public override string ToString()
    {
      return $"{_value} of {_suit}";
    }
  }

  class Deck
  {
    private List<Card> _cards;

    public int CardsCount => _cards.Count;

    public Deck()
    {
      _cards = new List<Card>();
      Create();
    }

    public Card GetCard()
    {
      Random random = new Random();
      int index = random.Next(0, _cards.Count);
      Card card = _cards[index];
      _cards.Remove(card);
      return card;
    }

    private void Create()
    {
      string[] cardValues = { "Six", "Seven", "Eight", "Nine", "Ten", "Jacks", "Queen", "King", "Ace" };
      string[] cardSuits = { "Spades", "Clubs", "Diamonds", "Hearts" };

      for (int i = 0; i < cardSuits.Length; i++)
      {
        for (int j = 0; j < cardValues.Length; j++)
        {
          _cards.Add(new Card(cardValues[j], cardSuits[i]));
        }
      }
    }
  }

  class Player
  {
    private List<Card> _hand;

    public Player()
    {
      _hand = new List<Card>();
    }

    public void TakeCard(Card card)
    {
      _hand.Add(card);
    }

    public int GetHandCount()
    {
      return _hand.Count;
    }

    public void ShowHand()
    {
      Console.Write($"[ ");

      foreach (Card card in _hand)
      {
        Console.Write($"|{card}| ");
      }

      Console.Write($"]\n");
    }

  }

  class Table
  {
    private Deck _deck;
    private List<Player> _players;
    private int _maxCardsForPlayer;

    public Table(int playersCount)
    {
      _deck = new Deck();
      _players = new List<Player>();
      _maxCardsForPlayer = _deck.CardsCount / playersCount;
      JoiningPlayers(playersCount);
    }

    public void Play()
    {
      const string CommandTakeCard = "1";
      const string CommandFinish = "2";

      for (int i = 0; i < _players.Count; i++)
      {
        Console.WriteLine($"\nХод игрока - {i}");
        Player player = _players[i];
        bool isTakingCards = true;

        if (_deck.CardsCount > 0)
        {
          while (isTakingCards)
          {
            player.ShowHand();
            Console.WriteLine($"{CommandTakeCard} - взять карту; {CommandFinish} - закончить");
            Console.Write("Введите команду: ");
            string playerInput = Console.ReadLine();

            switch (playerInput)
            {
              case CommandTakeCard:
                isTakingCards = GiveCard(player);
                break;

              case CommandFinish:
                isTakingCards = false;
                break;

              default:
                Console.WriteLine("Введите корректную команду");
                break;
            }
          }
        }
        else
        {
          Console.WriteLine("Карты в колоде закончились");
          break;
        }
      }
    }

    private void JoiningPlayers(int playersCount)
    {
      for (int i = 0; i < playersCount; i++)
      {
        _players.Add(new Player());
      }
    }

    private bool GiveCard(Player player)
    {
      bool isEnough = player.GetHandCount() < _maxCardsForPlayer;

      if (isEnough)
      {
        player.TakeCard(_deck.GetCard());
      }
      else
      {
        Console.WriteLine("Больше нельзя");
      }

      return isEnough;
    }
  }
}