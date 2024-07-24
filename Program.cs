using static System.Console;
using System.ClientModel;
using Azure.AI.OpenAI.Assistants;
//using OpenAI.Assistants;


#region Suppress_Warnings
#pragma warning disable OPENAI001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
#pragma warning disable CS8604 // Possible null reference argument.
#endregion
ApiKeyCredential openAIKey = Environment.GetEnvironmentVariable("OPEN_AI_API_KEY");

var client = new AssistantsClient(openAIKey.ToString());
#region Restore_Warnings
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore OPENAI001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
#endregion


if (args.Length < 1)
{
    WriteLine("Please provide a file path as the first argument or drag and drop on the binary");
    return;
}

var assistantCreationOptions = new AssistantCreationOptions("gpt-4")
{
    Name = "Ebook Summarizer",
    Instructions = "Answer questions from the user about the provided file. " +
    "For PDF files, immediately use PyPDF2 to extract the text contents and answer quesions based on that.",
    Tools = { new CodeInterpreterToolDefinition() }
};

//var assistant = client.CreateAssistant("gpt-4", assistantCreationOptions);

var fileUploadResponse = await client.UploadFileAsync(args[0], OpenAIFilePurpose.Assistants);
//var fileUploadResponse = await assistant.UploadFileAsync();

WriteLine("Hello, World!");

WriteLine(openAIKey);
