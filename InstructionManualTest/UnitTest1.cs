using System;
using System.IO;
using Xunit;
using InstructionManualLibrary.BusinessLogic;
using Microsoft.Extensions.Logging.Abstractions;

public class UnitTest1
{
    [Theory]
    [InlineData("en", "To use the web app, start by creating an account through the signup page, then log in with your credentials.")]
    [InlineData("de", "Um die Web-App zu verwenden, erstellen Sie zunächst ein Konto über die Anmeldeseite und loggen Sie sich dann mit Ihren Zugangsdaten ein.")]
    [InlineData("fr", "Pour utiliser l'application web, commencez par créer un compte via la page d'inscription, puis connectez-vous avec vos identifiants.")]
    [InlineData("es", "Para usar la aplicación web, comienza creando una cuenta a través de la página de registro, luego inicia sesión con tus credenciales.")]
    [InlineData("it", "Per utilizzare l'app web, inizia creando un account attraverso la pagina di registrazione, quindi accedi con le tue credenziali.")]
    [InlineData("invalid_lang", "Invalid language code. Defaulting to English.")]
    public void TestLanguageInstructions(string input, string expectedOutput)
    {
        // Arrange
        var writer = new StringWriter();
        var reader = new StringReader(input);
        Console.SetOut(writer);
        Console.SetIn(reader);

        var messages = new Messages(new NullLogger<Messages>());
        var app = new App(messages);

        // Act
        app.Run(new string[] { });

        // Assert
        var output = writer.ToString();
        Assert.Contains(expectedOutput, output);

        // Cleanup
        writer.Dispose();
        reader.Dispose();
    }
}
