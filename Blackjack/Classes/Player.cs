using Blackjack.Enums;
using Blackjack.Records;

namespace Blackjack.Classes;
public class Player : PlayerBase
{
    GameBlackJack Game { set; get; }
    public Player(GameBlackJack game) => Game = game;
    public override void AddCard(List<Card> cards)
    {
        Cards.AddRange(cards);
        CalculateScore();
        if (Score == 21 && cards.Count().Equals(2))
        {
            ChangeResult(Results.Blackjack);
            Game.Stay();
        }
        if (Score > 21)
        {
            ChangeResult(Results.PlayerLost);
            Game.Stay();
        }
    }
}
