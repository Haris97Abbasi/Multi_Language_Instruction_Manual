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
            var jsonContent = File.ReadAllText("CustomText.json");
            List<CustomText>? messageText = JsonSerializer.Deserialize<List<CustomText>>(jsonContent, options);
            if (messageText == null)
            {
                _log.LogWarning("Deserialization of CustomText.json returned null");
                return string.Empty;
            }

            var messages = messageText.FirstOrDefault(x => x.Language == language);
            if (messages == null)
            {
                _log.LogWarning("Language not found in CustomText.json");
                return string.Empty;
            }

            if (messages.Translations != null && messages.Translations.ContainsKey(key))
            {
                return messages.Translations[key];
            }
            else
            {
                _log.LogWarning($"Key '{key}' not found for language '{language}'");
                return string.Empty;
            }
        }
        catch (Exception ex)
        {
            _log.LogError(ex, "Error reading CustomText.json");
            throw;
        }
    }

}
