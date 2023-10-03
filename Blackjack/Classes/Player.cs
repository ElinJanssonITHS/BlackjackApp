﻿using Blackjack.Enums;
using Blackjack.Interfaces;
using Blackjack.Records;

namespace Blackjack.Classes;
public class Player : IPlayer
{
    GameBlackJack Game { set; get; }
    public bool Stays { get; set; }
    public List<Card> Cards { get; private set; } = new();
    public int Score { get; set; } = default;
    public Results Result { get; private set; } = Results.Unknown;
    public Player(GameBlackJack game) => Game = game;
    public void AddCard(List<Card> cards)
    {
        Cards.AddRange(cards);
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
    public void CalculateScore()
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
