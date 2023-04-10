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
      return $"{_value}{_suit}";
    }
  }

  class Deck
  {
    private List<Card> _cards;

    public Deck()
    {
      _cards = new List<Card>();
      Create();
      Shuffle();
    }

    public int CardsCount => _cards.Count;

    private void Create()
    {
      string[] cardValues = { "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
      string[] cardSuits = { "♠", "♣", "♦", "♥" };

      for (int i = 0; i < cardSuits.Length; i++)
      {
        for (int j = 0; j < cardValues.Length; j++)
        {
          _cards.Add(new Card(cardValues[j], cardSuits[i]));
        }
      }
    }

    private void Shuffle()
    {
      Random random = new Random();

      for (int i = 0; i < _cards.Count; i++)
      {
        int firstIndex = random.Next(0, _cards.Count - 1);
        int secondIndex = random.Next(firstIndex, _cards.Count);
        int count = secondIndex - firstIndex;
        List<Card> cards = _cards.GetRange(firstIndex, count);
        _cards.RemoveRange(firstIndex, count);
        _cards.AddRange(cards);
      }
    }

    public Card GetCard()
    {
      Card card = _cards.Last();
      _cards.Remove(card);
      return card;
    }
  }

  class Player
  {
    private List<Card> _hand;

    public Player()
    {
      _hand = new List<Card>();
    }

    public int HandCount => _hand.Count;

    public void TakeCard(Card card)
    {
      if (card != null)
      {
        _hand.Add(card);
      }
    }

    public void ShowHand()
    {
      Console.Write($"[ ");

      foreach (Card card in _hand)
      {
        Console.Write($"{card} ");
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
      bool isEnough = player.HandCount < _maxCardsForPlayer;

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