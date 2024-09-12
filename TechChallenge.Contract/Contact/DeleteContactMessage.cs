namespace TechChallenge.Contract.Contact
{
    public record DeleteContactMessage
    {
        public long ContactId { get; init; }
    }
}