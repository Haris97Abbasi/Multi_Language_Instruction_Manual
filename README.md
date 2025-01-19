# Multi-Language Instruction Manual Console App

Welcome to the GitHub repository for the Multi-Language Instruction Manual Console App, a robust C# .NET 9 application designed to deliver user instructions in multiple languages. This project is crafted to demonstrate advanced software engineering principles and modern C# development practices.

## Features

- **Multi-Language Support**: Users can access the instruction manual in multiple languages (English, German, French, Spanish, and Italian), making it accessible and user-friendly for a global audience.

- **Dependency Injection**: Utilizes built-in .NET Core dependency injection to manage dependencies throughout the application. This design promotes a clean, scalable, and testable codebase.

- **Modular Architecture**: Comprises three separate projects integrated into one solution:
  - **InstructionManualLibrary**: A class library that handles business logic and data deserialization.
  - **Console Application**: Serves as the user interface, allowing users to select their preferred language and view corresponding instructions.
  - **xUnit Testing Project**: Ensures the reliability and correctness of the application through comprehensive automated tests.

- **Exception Handling**: Implements robust exception handling to provide clear feedback and maintain application stability under various scenarios.

- **Logging**: Uses the `ILogger` interface for logging, aiding in debugging and ensuring that any issues can be tracked and resolved efficiently.

## Getting Started

To run this application on your local machine, follow these simple steps:

1. Clone the repository:
git clone https://github.com/Haris97Abbasi/multi-language-instruction-manual.git

2. Navigate to the solution folder and build the solution:
dotnet build

3. Run the console application:
dotnet run --project MultiLanguageInstructionManual


## Using the Application

Upon launching the application, you will be prompted to select a language. Enter the language code as per the instructions (e.g., 'en' for English) to view the instruction manual in your chosen language. If an unsupported language code is entered, the application defaults to English.

## Built With

- [.NET 9](https://dotnet.microsoft.com/en-us/download/dotnet/9) - The framework used
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) - Integrated development environment
- [xUnit](https://xunit.net/) - Testing framework for .NET

## Contributing

We welcome contributions from the community. If you wish to contribute to this project, please fork the repository and submit a pull request.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE) file for details.

## Acknowledgments

- Thanks to all contributors who have helped in shaping this project.
- Special thanks to .NET community for continuous support and guidance.
