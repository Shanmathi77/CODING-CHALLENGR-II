
namespace PETPALS_II.Repository
{
    public class AdoptionEvent
    {
        public string? Location { get; internal set; }
        public int EventId { get; internal set; }
        public object Status { get; internal set; }
        public DateTime EventDate { get; internal set; }
    }
}