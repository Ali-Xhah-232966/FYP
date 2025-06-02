using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using FYP.BLL.Interfaces;

public class HuggingFaceFreeService : IChatService
{
    private readonly HttpClient _httpClient;
    private const string ApiUrl = "https://api-inference.huggingface.co/models/HuggingFaceH4/zephyr-7b-beta";
    private const string ApiToken = ""; // Get from huggingface.co/settings/tokens

    public HuggingFaceFreeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiToken);
        _httpClient.Timeout = TimeSpan.FromSeconds(60); // Longer timeout
    }

    public async Task<string> GetResponseAsync(string input)
    {
        try
        {
            // Format input for the model
            var formattedInput = $"<|user|>\n{input}</s>\n<|assistant|>";

            var request = new
            {
                inputs = formattedInput,
                parameters = new
                {
                    max_new_tokens = 200,
                    return_full_text = false
                }
            };

            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(ApiUrl, content);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return $"API Error: {response.StatusCode} - {responseContent}";
            }

            using var jsonDoc = JsonDocument.Parse(responseContent);
            return jsonDoc.RootElement[0].GetProperty("generated_text").GetString() ?? "I didn't understand that";
        }
        catch (Exception ex)
        {
            return $"Service Error: {ex.Message}";
        }
    }
}