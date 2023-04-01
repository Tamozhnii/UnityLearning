using System.Collections.Generic;
using System;

namespace L6_3
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

        for (int i = 0; i < playersCount; i++)
        {
          if (table.CheckDeckCount())
          {
            table.ToPlay(i);
          }
          else
          {
            break;
          }
        }
      }
      else
      {
        Console.WriteLine($"Может быть от 1 до {maxPlayersCount} игрока");
      }
    }
  }

  class Card
  {
    private string _nominal;
    private string _suit;

    public Card(string nominal, string suit)
    {
      _nominal = nominal;
      _suit = suit;
    }

    public override string ToString()
    {
      return $"{_nominal} of {_suit}";
    }
  }

  class Deck
  {
    private string[] nominals = new string[9] { "Six", "Seven", "Eight", "Nine", "Ten", "Jacks", "Queen", "King", "Ace" };
    private string[] suits = new string[4] { "Spades", "Clubs", "Diamonds", "Hearts" };
    private List<Card> _decks;

    public Deck()
    {
      _decks = new List<Card>();

      for (int i = 0; i < suits.Length; i++)
      {
        for (int j = 0; j < nominals.Length; j++)
        {
          _decks.Add(new Card(nominals[j], suits[i]));
        }
      }
    }

    public Card GetCard()
    {
      Random random = new Random();
      int index = random.Next(0, _decks.Count);
      Card card = _decks[index];
      _decks.RemoveAt(index);
      return card;
    }

    public int GetRemainigCardsCount()
    {
      return _decks.Count;
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
      _maxCardsForPlayer = _deck.GetRemainigCardsCount() / playersCount;

      for (int i = 0; i < playersCount; i++)
      {
        _players.Add(new Player());
      }
    }

    const string CommandTakeCard = "1";
    const string CommandFinish = "2";

    public bool CheckDeckCount()
    {
      return _deck.GetRemainigCardsCount() > 0;
    }

    public void ToPlay(int playerIndex)
    {
      Console.WriteLine($"\nХод игрока - {playerIndex}");
      Player player = _players[playerIndex];
      bool isTakingCards = true;

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

    private bool ToCardIssuance(Player player)
    {
      int remainingCards = _deck.GetRemainigCardsCount();
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