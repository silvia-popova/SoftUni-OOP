using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem1.Card_Suit
{
    [Type("Enumeration", "Suit", "Provides suit constants for a Card class.")]
    public enum Suit
    {
        Clubs , Diamonds = 13, Hearts = 26, Spades = 39
    }

    [Type("Enumeration", "Rank", "Provides rank constants for a Card class.")]
    public enum Rank
    {
        Ace = 14, Two = 2, Three = 3, Four = 4, Five = 5, Six = 6, Seven = 7, Eight = 8, Nine = 9, Ten = 10, Jack = 11, Queen = 12, King = 13
    }

    public class Card : IComparable<Card>
    {
        public Suit suit;
        public Rank rank;

        public Card(Suit suit, Rank rank)
        {
            this.suit = suit;
            this.rank = rank;
        }

        public int Power => (int) suit + (int) rank;

        public int CompareTo(Card other)
        {
            int result = this.Power.CompareTo(other.Power);
            return result;
        }

        public bool Equal(Card other)
        {
            return this.Power == other.Power;
        }

        public static bool operator >(Card card1, Card card2)
        {
            if (card1.CompareTo(card2) > 0)
            {
                return true;
            }

            return false;
        }

        public static bool operator <(Card card1, Card card2)
        {
            if (card1.CompareTo(card2) > 0)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return $"{rank} of {suit}";
        }
    }

    public class CardComparer: IComparer<Card>
    {
        public int Compare(Card x, Card y)
        {
            return x.CompareTo(y);
        }
    }

    public class Player : IComparable<Player>
    {
        private string name;
        private SortedSet<Card> cards;

        public Player(string name)
        {
            this.name = name;
            this.cards = new SortedSet<Card>(new CardComparer());
        }

        public SortedSet<Card> Cards => new SortedSet<Card>(this.cards);

        public void AddCard(Card card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card is not in the deck.");
            }

            this.cards.Add(card);
        }

        public Card BiggestCard => this.GetBiggestCard();

        public static bool operator >(Player player1, Player player2)
        {
            if (player1.GetBiggestCard().CompareTo(player2.GetBiggestCard()) > 0)
            {
                return true;
            }

            return false;
        }

        public static bool operator <(Player player1, Player player2)
        {
            if (player2.GetBiggestCard().CompareTo(player1.GetBiggestCard()) > 0)
            {
                return true;
            }

            return false;
        }

        public Card GetBiggestCard()
        {
            Card bigestCard = cards.First();

            foreach (var card in cards)
            {
                if (bigestCard.CompareTo(card) < 0)
                {
                    bigestCard = card;
                }
            }

            return bigestCard;
        }

        public int CompareTo(Player other)
        {
            int result = this.GetBiggestCard().CompareTo(other.GetBiggestCard());
            return result;
        }

        public override string ToString()
        {
            return $"{this.name} wins with {this.cards.Last()}.";
        }
    }

    public class Deck
    {
        private HashSet<Card> cards;
        private HashSet<string> cardsNames;

        public Deck()
        {
            this.cards = new HashSet<Card>();
            this.cardsNames = new HashSet<string>();
        }

        public void FillDeckWithAllCards()
        {
            var ranks = Enum.GetValues(typeof(Rank));
            var suits = Enum.GetValues(typeof(Suit));

            foreach (Suit suit in suits)
            {
                foreach (Rank rank in ranks)
                {
                    var newCard = new Card(suit, rank);
                    cards.Add(newCard);
                    cardsNames.Add(newCard.ToString());
                }
            }
        }

        public Card GetCard(string cardName)
        {
            if (!cardsNames.Contains(cardName))
            {
                throw new ArgumentException("No such card exists.");
            }

            var card = cards.FirstOrDefault(c => c.ToString() == cardName);

            cards.Remove(card);

            return card;
        }
    }

    [AttributeUsage(AttributeTargets.Enum)]
    public class TypeAttribute : Attribute
    {
        public TypeAttribute(string type, string category, string description)
        {
            this.type = type;
            this.category = category;
            this.description = description;
        }

        public string type { get; set; }

        public string category { get; set; }

        public string description  { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var deck = new Deck();
            deck.FillDeckWithAllCards();

            string firstPlayerName = Console.ReadLine();
            string secondPlayerName = Console.ReadLine();

            var firstPlayer = new Player(firstPlayerName);
            var secondPlayer = new Player(secondPlayerName);

            GivePlayerCards(firstPlayer, deck);
            GivePlayerCards(secondPlayer, deck);

            if (firstPlayer.CompareTo(secondPlayer) > 0)
            {
                Console.WriteLine(firstPlayer.ToString());
            }
            else
            {
                Console.WriteLine(secondPlayer.ToString());
            }
        }

        private static void GivePlayerCards(Player player, Deck deck)
        {
            while (player.Cards.Count < 5)
            {
                try
                {
                    string cardName = Console.ReadLine();
                    var card = deck.GetCard(cardName);

                    player.AddCard(card);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
