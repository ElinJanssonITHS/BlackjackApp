using Blackjack.Enums;
using Blackjack.Records;
namespace Blackjack.Interfaces
{
    public interface IPlayer
    {
        bool Stays { get; set; }
        List<Card> Cards { get; }
        int Score { get; set; }
        Results Result { get; }
        void AddCard(List<Card> cards);
        void CalculateScore();
    }
}
