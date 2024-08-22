using TechChallenge.Data.Context;
using TechChallenge.Data.Repository;
using TechChallenge.Domain.Models;
using TechChallenge.Domain.Services;
using Xunit.Abstractions;

namespace TechChallenge.Domain.IntegrationTest;
[Collection(nameof(ContextCollection))]

public class ContactEdit
{
    private readonly techchallengeDbContext _context;

    public ContactEdit(ITestOutputHelper output, ContextFixture fixture)
    {
        _context = fixture._context;
        output.WriteLine(_context.GetHashCode().ToString());
    }

    [Theory]
    [InlineData("F3763F34-1A52-47BD-4FFE-08DC79FBC12B", "UpdatedName1", "updated.test1@server.com", "61789456123")]
    [InlineData("542B8709-4A74-433C-16CC-08DC7AC6277E", "UpdatedName2", "updated.teste2@server.com", "51321654987")]
    [InlineData("3FA85F64-5717-4562-B3FC-2C963F66AFA6", "UpdatedName3", "updated.teste3@server.com", "41987654321")]
    public async void ShouldEditNewContact(Guid id, string updatedName, string updatedEmail, string updatedPhone)
    {
        //arrange
        var contactRepository = new ContactRepository(_context);
        var service = new ContactService(contactRepository);

        var contact = await service.GetById(id);
        contact.Name = updatedName;
        contact.Email = updatedEmail;
        contact.Phone = updatedPhone;

        //act
        await service.Update(contact);
        
        //assert
        var updatedContact = await service.GetById(contact.Id);        
        Assert.NotNull(updatedContact);
        Assert.Equal(contact.Name, updatedContact.Name);
        Assert.Equal(contact.Email, updatedContact.Email);
        Assert.Equal(contact.Phone, updatedContact.Phone);

        _context.ChangeTracker.Clear();
    }
}