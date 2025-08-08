
using Model.DTOs;
using System.Net.Http.Json;
using ToDoMauiApp.Model.DTOs;
using ToDoMauiApp.Service.Interfaces;

namespace ToDoMauiApp.Service
{
    public class ToDoService : IToDoService
    {

        private readonly HttpClient _httpClient;

        private String BASE_URL => DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:7190" : "http://localhost:7190";

        public ToDoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetToDoItemDTO> AddAsync(CreateToDoItemDTO todo)
        {
            var res = await _httpClient.PostAsJsonAsync($"{BASE_URL}/api/todos", todo);
            GetToDoItemDTO? result = new();
            if (res.IsSuccessStatusCode)
            {
                result = await res.Content.ReadFromJsonAsync<GetToDoItemDTO>();
                if (result == null)
                {
                    return new();
                }
            }
            return result;
        }

        public async Task<DeleteResponseDTO> DeleteAsync(Guid id)
        {
            var res = await _httpClient.DeleteAsync($"{BASE_URL}/api/todos/{id}");
            DeleteResponseDTO? result = new(false);
            if (res.IsSuccessStatusCode)
            {
                result = await res.Content.ReadFromJsonAsync<DeleteResponseDTO>();
                if (result == null)
                {
                    return new(false);
                }
            }
            return result;
        }

        public async Task<List<GetToDoItemDTO>> GetAllToDosAsync()
        {
            
            var res = await _httpClient.GetAsync($"{BASE_URL}/api/todos");
            List<GetToDoItemDTO>? result = new();
            if (res.IsSuccessStatusCode)
            {
                result = await res.Content.ReadFromJsonAsync<List<GetToDoItemDTO>>();
                if (result == null)
                {
                    return new();
                }
            }
            return result;
        }

        public async Task<GetToDoItemDTO?> GetToDoByIdAsync(Guid id)
        {
            var res = await _httpClient.GetAsync($"{BASE_URL}/api/todos/{id}");
            GetToDoItemDTO? result = new();
            if (res.IsSuccessStatusCode)
            {
                result = await res.Content.ReadFromJsonAsync<GetToDoItemDTO>();
                if (result == null)
                {
                    return new();
                }
            }
            return result;
        }

        public async Task<UpdateResponseDTO> UpdateAsync(Guid id, UpdateToDoTitemDTO todo)
        {
            var res = await _httpClient.PatchAsJsonAsync($"{BASE_URL}/api/todos/{id}", todo);
            UpdateResponseDTO? result = new(false);
            if (res.IsSuccessStatusCode)
            {
                result = await res.Content.ReadFromJsonAsync<UpdateResponseDTO>();
                if (result == null)
                {
                    return new(false);
                }
            }
            return result;
        }
    }
    }
}
