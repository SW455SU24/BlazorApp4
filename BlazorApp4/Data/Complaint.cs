namespace BlazorApp4.Data
{
    public class Complaint
    {
        public int Id { get; set; }
        public string? Body { get; set; }
        public ApplicationUser? Sender { get; set; }
    }
}
