using InstructionManualLibrary.Models;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace InstructionManualLibrary.BusinessLogic;

public class Messages : IMessages
{
    private readonly ILogger<Messages> _log;
    public Messages(ILogger<Messages> log)
    {
        _log = log;
    }

    public string Instructions(string language)
    {
        return LookUpCustomText("Instructions", language);
    }

    private string LookUpCustomText(string key, string language)
    {
        JsonSerializerOptions options = new()
        {
            PropertyNameCaseInsensitive = true,
        };

        try
        {
            List<CustomText>? messageText = JsonSerializer.Deserialize<List<CustomText>>
            (
                File.ReadAllText("CustomText.json"), options
            );
            CustomText? messages = messageText?.Where(x => x.Language == language).First();
            if (messages == null)
            {
                _log.LogWarning("Language not found in CustomText.json");
                return string.Empty;
            }
            return messages.Translations[key];
        }
        catch (Exception ex)
        {
            _log.LogError(ex, "Error reading CustomText.json");
            throw;
        }

    }
}
