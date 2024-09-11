namespace PresidentialPolls.Model
{
    public class CalendarEvent
    {
        public CalendarEvent(string name, Color color)
        {
            Name = name;
            Color = color;
        }

        public string Name { get; }
        public Color Color { get; }
    }
}
