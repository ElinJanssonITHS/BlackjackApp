namespace Blackjack.Classes;

public class Deck
{
    private Card[] _cards;
    private string[] unicodeCards = { "🂡", "🂢", "🂣", "🂤", "🂥", "🂦", "🂧", "🂨", "🂩", "🂪", "🂫", "🂭", "🂮" };
    private const int numberOfCards = 52;

    public Deck() { }

    public void NewDeck()
    {
        CreateDeck();
        ShuffleDeck(_cards);
    }

    public void DealCard (Player player, int takeCards = 1)
    {
        Card[] dealingCards = new Card[takeCards];
        dealingCards = dealingCards.Concat(_cards[0..takeCards]).ToArray();

        player.AddCards(dealingCards, dealingCards.Length);

        _cards = _cards[takeCards..];

    }

    private void CreateDeck()
    {
        _cards = new Card[numberOfCards];
        int index = 0;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < unicodeCards.Length; j++)
            {
                int value = j > 9 ? 10 : j + 1;
                _cards[index] = new Card(unicodeCards[j], value);
                index++;
            }
        }
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
