﻿using Blackjack.Enums;
using Blackjack.Records;
namespace Blackjack.Classes;


public class GameBlackJack
{
    private Player player;
    private Player dealer;
    private Deck deck = new();

    public bool Stays { get => player.Stays; }
    public string Winner { get; private set; } = string.Empty;

    public GameBlackJack()
    {
        player = new(PlayerTypes.Player, this);
        dealer = new(PlayerTypes.Dealer, this);
    }
    
    public Card[] GetPlayerCards () => player.Cards;
    public int GetPlayerScore () => player.Score;
    public Card[] GetDealerCards () => dealer.Cards;
    public int GetDealerScore () => dealer.Score;



    public void DealPlayerCard(int takeCards = 1) => player.AddCard(deck.DealCard(takeCards));
    
    public void DealDealerCard(int takeCards = 1, bool firstCards = false)
    {
        Card[] cards = deck.DealCard(takeCards);
        if (firstCards)
        {
            cards[0].IsHidden = true;
        }
        dealer.AddCard(cards);
    }

    public void Stay()
    {
        player.Stays = true;
        dealer.Stays = true;
        dealer.Cards[0].IsHidden = false;

        if (!player.Result.Equals(Results.Blackjack) &&
            !player.Result.Equals(Results.PlayerLost))

        {
            while (dealer.Score < 17)
            {
                DealDealerCard();
            }
        }

        DetermineWinner();
    }

    void DetermineWinner()
    {
        if (player.Result.Equals(Results.Blackjack) || player.Result.Equals(Results.PlayerLost))
        {
            dealer.Cards[0].IsHidden = true;
            dealer.Score = dealer.Cards[1].Value;
        }

        if (player.Result.Equals(Results.Blackjack))
        {
            Winner = "Player wins with Blackjack";
        }
        else if (player.Result.Equals(Results.PlayerLost))
        {
            Winner = "Dealer wins";
        }
        else if (dealer.Result.Equals(Results.DealerLost))
        {
            Winner = "Player wins";
        }
        else if (dealer.Score > player.Score)
        {
            Winner = "Dealer wins";
        }
        else if (player.Score > dealer.Score)
        {
            Winner = "Player wins";
        }
        else
            Winner = "Draw";
    }
    public void NewGame()
    {
        Winner = string.Empty;
        deck.NewDeck();

        player = new(PlayerTypes.Player, this);
        dealer = new(PlayerTypes.Dealer, this);

        DealDealerCard(2, true);
        DealPlayerCard(2);
    }
}