namespace Blackjack.Classes;
using Blackjack.Enums;

public class GameBlackJack
{
    private Player player = new Player(PlayerTypes.Player);
    private Player dealer = new Player(PlayerTypes.Dealer);

    private Deck deck = new Deck();

    public void NewGame ()
    {
        deck.NewDeck();

        deck.DealCard(dealer, 2);
        deck.DealCard(player,2);
    }

    public void GetPlayerScore(out int playerScore)
    {
        playerScore = player.playerScore;
    }

    public void GetDealerScore(out int dealerScore)
    {
        dealerScore = dealer.playerScore;
    }
    public void GetPlayerCards (out Card[] playerCards)
    {
        playerCards = player.cards;
    }

    public void GetDealerCards(out Card[] dealerCards)
    {
        dealerCards = player.cards;
    }
}
