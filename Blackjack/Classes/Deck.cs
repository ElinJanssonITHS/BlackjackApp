using Blackjack.Records;
namespace Blackjack.Classes;

public class Deck
{
    private const int numberOfCards = 52;
    private Card[] deck = new Card[numberOfCards]; 
    //private string[] unicodeCards = { "🂡", "🂢", "🂣", "🂤", "🂥", "🂦", "🂧", "🂨", "🂩", "🂪", "🂫", "🂭", "🂮" };
    private string[,] suits =  {{ "🂡", "🂢", "🂣", "🂤", "🂥", "🂦", "🂧", "🂨", "🂩", "🂪" , "🂫", "🂭", "🂮" },
                                { "🂱", "🂲", "🂳", "🂴", "🂵", "🂶", "🂷", "🂸", "🂹", "🂺", "🂻", "🂽", "🂾" },
                                { "🃁", "🃂", "🃃", "🃄", "🃅", "🃆", "🃇", "🃈", "🃉", "🃊", "🃋", "🃍", "🃎" },
                                { "🃑", "🃒", "🃓", "🃔", "🃕", "🃖", "🃗", "🃘", "🃙", "🃚", "🃛", "🃝", "🃞" }};



    public void NewDeck()
    {
        deck = CreateDeck();
        deck = ShuffleDeck(deck);
    }

    public Card[] DealCard (int takeCards = 1)
    {
        var cards = deck[0..takeCards];
        deck = deck[takeCards..];
        return cards;


    }

    private Card[] CreateDeck()
    {
        var cards = new Card[numberOfCards];
        int index = 0;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 13; j++)
            {
                int value = j > 9 ? 10 : j + 1;
                cards[index] = new Card(suits[i, j], value);
                index++;
            }
        }
        return cards;
    }

    Card[] ShuffleDeck(Card[] cards)
    {
        Random random = new();
        for (int i = 0; i < cards.Length; i++)
        {
            int swap = random.Next(cards.Length);
            Card temp = cards[i];
            cards[i] = cards[swap];
            cards[swap] = temp;
        }
        return cards;
    }
}
