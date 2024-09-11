namespace PresidentialPolls.Model
{
    public class PartyData
    {
        public PartyData(Color color, SortedDictionary<DateTime, double> rawData, SortedDictionary<DateTime, double> smoothedData, float? max, float? min)
        {
            Color = color;
            RawData = rawData;
            SmoothedData = smoothedData;
            Max = max;
            Min = min;
        }

        public Color Color { get; }
        public SortedDictionary<DateTime, double> RawData { get; }
        public SortedDictionary<DateTime, double> SmoothedData { get; }
        public float? Max { get; }
        public float? Min { get; }
    }


    public class PlotData(PartyData demPartyData, PartyData repPartyData)
    {
        public PartyData DemPartyData { get; } = demPartyData;
        public PartyData RepPartyData { get; } = repPartyData;
        public PartyData OtherPartyData
        {
            get
            {
                SortedDictionary<DateTime, double> rawData = [];
                SortedDictionary<DateTime, double> smoothedData = [];
                double repValue;
                double demValue;
                foreach( var item in DemPartyData.RawData )
                {
                    demValue = DemPartyData.RawData[item.Key];
                    repValue = RepPartyData.RawData[item.Key];

                    rawData.Add(item.Key, 100 - demValue - repValue);
                }

                foreach( var item in DemPartyData.SmoothedData )
                {
                    demValue = DemPartyData.SmoothedData[item.Key];
                    repValue = RepPartyData.SmoothedData[item.Key];

                    smoothedData.Add(item.Key, 100 - demValue - repValue);

                }

                PartyData partyData = new(Color.LightGray, rawData, smoothedData, 0, 0);
                return partyData;
            }
        }
    }

}


