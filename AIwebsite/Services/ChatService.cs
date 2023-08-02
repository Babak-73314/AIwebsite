using Azure.AI.OpenAI;
using Azure;
using System;

namespace AIwebsite.Services
{
    public class ChatService
    {
        private OpenAIClient client;

        public ChatService()
        {
            var apiKey = Environment.GetEnvironmentVariable("AZURE_OPENAI_API_KEY");

            // If the environment variable is not found, fallback to the hardcoded value.
            if (string.IsNullOrEmpty(apiKey))
            {
                    apiKey = "1b262ef480aa4b338c5106460ff9ca29"; // Replace this with your actual API key.
            }

            //client = new OpenAIClient(
            //    new Uri("https://azureopenaibabak.openai.azure.com/openai/deployments/DeploymentBabak/chat/completions?api-version=2023-03-15-preview/"),
            //    new AzureKeyCredential(apiKey)
            //);
            client = new OpenAIClient(
    new Uri("https://azureopenaibabak.openai.azure.com/"),
    new AzureKeyCredential(apiKey)
            );

        }

        public async Task<ChatCompletions> GetChatCompletionsAsync(ChatMessage message)
        {
            Response<ChatCompletions> response = await client.GetChatCompletionsAsync(
                "DeploymentBabak",
                new ChatCompletionsOptions()
                {
                    Messages = { message },
                    Temperature = 1f,
                    MaxTokens = 400,
                    NucleusSamplingFactor = 0.95f,
                    FrequencyPenalty = 0,
                    PresencePenalty = 0,
                });

            return response.Value;
        }
    }

}
