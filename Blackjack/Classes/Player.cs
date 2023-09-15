namespace Blackjack.Classes;
using Blackjack.Enums;


public class Player
{
    private PlayerTypes _player = default;
    public int playerScore { get; private set; }
    public Card[] cards { get; private set; }

    public Player (PlayerTypes player)
    {
        _player = player;
    }

    public void AddCards(Card[] dealingCards, int numberOfCArds)
    {
        cards = cards.Concat(dealingCards[0..numberOfCArds]).ToArray();


    }

    public void CalculateScore()
    {
        playerScore = cards.Sum(c => c.Value);
        var aces = cards.Where(c => c.Value.Equals(1) && !c.IsHidden);

        foreach (var ace in aces)
        {
            if (playerScore <= 11)
            {
                playerScore += 10;
            }
        }
    }

}
