using Radzen;
using System.Net.Http.Json;
using TechChallenge.Core.DTO;
using TechChallenge.Web.WebServices.Interfaces;

namespace TechChallenge.Web.WebServices
{
    public class ContactWebService : IContactWebService
    {
        private readonly HttpClient _httpClient;

        public ContactWebService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ContactDto?> AddContact(ContactDto contact)
        {
            var response = await _httpClient.PostAsJsonAsync("api/contact/register-contact", contact);

            if( response.IsSuccessStatusCode )
            {
                var content = await response.Content.ReadFromJsonAsync<ContactDto>();
                
                return content;
            }
            
            var message = response.Content.ReadAsStringAsync();

            return null;
        }

        public async Task<bool> Delete(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"api/contact/delete-contact/{id}");

            if( response.IsSuccessStatusCode )
            {
                if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return false;
                }

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<ContactDto>> GetAll()
        {
            var response = await _httpClient.GetAsync("api/contact/");

            if( response.IsSuccessStatusCode )
            {
                if(response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return new List<ContactDto>();
                }

                var content = await response.Content.ReadFromJsonAsync<ReturnApiDto<IEnumerable<ContactDto>>>();
                return content.Data;
            }

            var message = response.Content.ReadAsStringAsync();
            throw new Exception($"Error: {response.StatusCode} - {message.Result}");
        }

        public async Task<ContactDto?> GetById(Guid id)
        {
            var response = await _httpClient.GetAsync($"api/contact/{id}");

            if( response.IsSuccessStatusCode )
            {
                if(response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return null;
                }

                var content = await response.Content.ReadFromJsonAsync<ReturnApiDto<ContactDto>>();
                return content.Data;
            }

            var message = response.Content.ReadAsStringAsync();
            throw new Exception($"Error: {response.StatusCode} - {message.Result}");
        }

        public async Task<ReturnTableDto<ContactDto>> GetRadzenList(LoadDataArgs args)
        {
            var response = await _httpClient.PostAsJsonAsync("api/contact/radzen-list", args);

            if( response.IsSuccessStatusCode )
            {
                if(response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return new ReturnTableDto<ContactDto>();
                }

                var content = await response.Content.ReadFromJsonAsync<ReturnTableDto<ContactDto>>();
                return content;
            }

            var message = response.Content.ReadAsStringAsync();
            throw new Exception($"Error: {response.StatusCode} - message: {message.Result}");
        }

        public async Task<ContactDto?> Update(ContactDto contact)
        {
            var response = await _httpClient.PatchAsJsonAsync("api/contact/update-contact", contact);

            if( response.IsSuccessStatusCode )
            {
                var content = await response.Content.ReadFromJsonAsync<ReturnApiDto<ContactDto>>();
                return content.Data;
            }

            var message = response.Content.ReadAsStringAsync();
            throw new Exception($"Error: {response.StatusCode} - {message.Result}");
        }
    
    }
}
