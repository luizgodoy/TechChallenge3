namespace TechChallenge.Contract.Contact
{
    public record DeleteContactMessage
    {
        public Guid ContactId { get; init; }
    }
}