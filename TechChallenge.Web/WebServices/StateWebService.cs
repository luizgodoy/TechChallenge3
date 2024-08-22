using System.Net.Http.Json;
using TechChallenge.Core.DTO;
using TechChallenge.Web.WebServices.Interfaces;

namespace TechChallenge.Web.WebServices;

public class StateWebService : IStateWebService
{
    private readonly HttpClient _httpClient;

    public StateWebService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<StateDto>> GetAllStates()
    {
        var response = await _httpClient.GetAsync("api/state");

        if (response.IsSuccessStatusCode)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return new List<StateDto>();
            }

            var content = await response.Content.ReadFromJsonAsync<ReturnApiDto<IEnumerable<StateDto>>>();
            return content.Data;
        }

        var message = response.Content.ReadAsStringAsync();
        throw new Exception($"Error: {response.StatusCode} - {message.Result}");
    }

    public async Task<StateDto?> GetStateByDDD(int ddd)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/state/{ddd}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
            else if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadFromJsonAsync<StateDto>();
                return content;
            }
            var message = response.Content.ReadAsStringAsync();
            throw new Exception($"Error: {response.StatusCode} - {message.Result}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw e;
        }
    }

    public async Task<StateDto?> GetStateById(Guid id)
    {
        var response = await _httpClient.GetAsync($"api/state/{id}");

        if (response.IsSuccessStatusCode)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return null;
            }

            var content = await response.Content.ReadFromJsonAsync<ReturnApiDto<StateDto>>();
            return content.Data;
        }

        var message = response.Content.ReadAsStringAsync();
        throw new Exception($"Error: {response.StatusCode} - {message.Result}");
    }
}
