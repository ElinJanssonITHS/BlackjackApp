using Blackjack.Enums;
using Blackjack.Records;
namespace Blackjack.Classes;



public class Player
{
    GameBlackJack Game {set; get;}
    public bool Stays { get; set; }
    public Card[] Cards { get; private set; } = new Card[0];
    public int Score { get; set; } = default;
    public PlayerTypes PlayerType { get; init; } = default;
    public Results Result { get; private set; } = Results.Unknown;

    public Player(PlayerTypes playerType, GameBlackJack game) =>
    (PlayerType, Game) = (playerType, game);


    public void AddCard(Card[] cards)
    {
        Cards = Cards.Concat(cards).ToArray();
        if (PlayerType.Equals(PlayerTypes.Player))
        {
            CalculateScore();
            if (Score == 21 && cards.Count().Equals(2))
            {
                Result = Results.Blackjack;
                Game.Stay();
            }
            if (Score > 21)
            {
                Result = Results.PlayerLost;
                Game.Stay();
            }
        }
        else
        {
            CalculateScore();
            if (Score > 21) Result = Results.DealerLost;
        }
    }


    void CalculateScore()
    {
        Score = Cards.Sum(c => c.Value);
        var aces = Cards.Where(c => c.Value.Equals(1) && !c.IsHidden);

        foreach (var ace in aces)
        {
            if (Score <= 11)
            {
                Score += 10;
            }
        }
    }

}
