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
    private string _cardValue;
    private string _cardSuit;

    public Card(string cardValue, string cardSuit)
    {
      _cardValue = cardValue;
      _cardSuit = cardSuit;
    }

    public override string ToString()
    {
      return $"{_cardValue} of {_cardSuit}";
    }
  }

  class Deck
  {
    private List<Card> _cards;

    public Deck()
    {
      _cards = new List<Card>();
      Initialize();
    }

    public int CardsCount => _cards.Count;

    private void Initialize()
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

    public Card GetCard()
    {
      Random random = new Random();
      int index = random.Next(0, _cards.Count);
      Card card = _cards[index];
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

    public bool CheckDeckCount => _deck.CardsCount > 0;

    private void JoiningPlayers(int playersCount)
    {
      for (int i = 0; i < playersCount; i++)
      {
        _players.Add(new Player());
      }
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

        if (CheckDeckCount)
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
                isTakingCards = ToCardIssuance(player);
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
          break;
        }
      }
    }

    private bool ToCardIssuance(Player player)
    {
      int remainingCards = _deck.CardsCount;
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