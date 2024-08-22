using TechChallenge.Data.Context;
using TechChallenge.Data.Repository;
using TechChallenge.Domain.Models;
using TechChallenge.Domain.Services;
using Xunit.Abstractions;

namespace TechChallenge.Domain.IntegrationTest;
[Collection(nameof(ContextCollection))]

public class ContactAdd
{
    private readonly techchallengeDbContext _context;

    public ContactAdd(ITestOutputHelper output, ContextFixture fixture)
    {
        _context = fixture._context;
        output.WriteLine(_context.GetHashCode().ToString());
    }    

    [Theory]
    [InlineData("F3763F34-1A52-47BD-4FFE-08DC79FBC12B", "Test 1", "test1@server.com", "31987654321", "B82BB752-0FB4-43F2-BA47-775579312EA8")]
    [InlineData("542B8709-4A74-433C-16CC-08DC7AC6277E", "Test 2", "teste2@server.com", "14012365478", "24F07EA5-9A36-46E2-AE6C-7F7D273BB7AA")]
    [InlineData("3FA85F64-5717-4562-B3FC-2C963F66AFA6", "Test 3", "teste3@server.com", "21012365478", "914DE0B0-209C-4AD9-8D8A-8723B72A2C79")]
    public async void ShouldAddNewContact(string id, string name, string email, string phone, string stateId)
    {
        //arrange
        var contact = new Contact { Id = new Guid(id), Name = name, Email = email, Phone = phone, StateId = new Guid(stateId) };
        
        var contactRepository = new ContactRepository(_context);
        var service = new ContactService(contactRepository);

        //act
        await service.Create(contact);

        //assert
        var contactResult = await service.GetById(contact.Id);
        Assert.NotNull(contactResult);

        _context.ChangeTracker.Clear();
    }
}