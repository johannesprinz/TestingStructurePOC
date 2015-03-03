using System.Collections.Generic;

namespace PayProcessor.App {
    public class HourlyPayType {
        public int HourlyRate { get; private set; }
        public List<TimeCard> TimeCards { get; private set; }

        public HourlyPayType(int hourlyRate) {
            HourlyRate = hourlyRate;
            TimeCards = new List<TimeCard>();
        }

        public void AddTimeCard(TimeCard timeCard) {
            TimeCards.Add(timeCard);
        }
    }
}