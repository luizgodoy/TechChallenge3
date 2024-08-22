using TechChallenge.Data.Context;
using TechChallenge.Data.Repository;
using TechChallenge.Domain.Services;
using Xunit.Abstractions;

namespace TechChallenge.Domain.IntegrationTest;
[Collection(nameof(ContextCollection))]
public class ContactRemove
{
    private readonly techchallengeDbContext _context;
    public ContactRemove(ITestOutputHelper output, ContextFixture fixture)
    {
        _context = fixture._context;
        output.WriteLine(_context.GetHashCode().ToString());
    }

    [Theory]
    [InlineData("F3763F34-1A52-47BD-4FFE-08DC79FBC12B")]
    [InlineData("542B8709-4A74-433C-16CC-08DC7AC6277E")]
    [InlineData("3FA85F64-5717-4562-B3FC-2C963F66AFA6")]
    public async void ShouldRemoveContact(string id)
    {
        //arrange
        var contactId = new Guid(id);
        var contactRepository = new ContactRepository(_context);
        var service = new ContactService(contactRepository);

        //act
        await service.Delete(contactId);        

        //assert
        var deletedContact = await service.GetById(contactId);
        Assert.Null(deletedContact);
    }
}