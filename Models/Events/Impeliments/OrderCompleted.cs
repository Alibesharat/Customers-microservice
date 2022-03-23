namespace Events
{
    public class OrderCompleted : IEvent
    {
        public string Email { get; set; }
    }
}
