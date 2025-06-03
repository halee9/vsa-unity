using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Text;
using System;

[System.Serializable]
public class ChatMessage
{
    public string role;
    public string content;
}

[System.Serializable]
public class ChatRequest
{
    public string model;
    public ChatMessage[] messages;
    public float temperature;
}

[System.Serializable]
public class ChatResponse
{
    public ChatChoice[] choices;
}

[System.Serializable]
public class ChatChoice
{
    public ChatMessage message;
}

public class ChatHandler : MonoBehaviour
{
    [SerializeField] private string openRouterKey = "YOUR_API_KEY_HERE"; // Replace with your API key
    [SerializeField] private string apiEndpoint = "https://openrouter.ai/api/v1/chat/completions";
    [SerializeField] private string model = "mistralai/mistral-7b-instruct";
    
    private ChatMessage[] conversationHistory = new ChatMessage[0];

    public IEnumerator SendChatRequest(string userMessage, Action<string> onResponse)
    {
        // Add user message to history
        Array.Resize(ref conversationHistory, conversationHistory.Length + 1);
        conversationHistory[conversationHistory.Length - 1] = new ChatMessage
        {
            role = "user",
            content = userMessage
        };

        // Create request body
        var requestBody = new ChatRequest
        {
            model = model,
            messages = conversationHistory,
            temperature = 0.7f
        };

        string jsonBody = JsonUtility.ToJson(requestBody);

        using (UnityWebRequest request = new UnityWebRequest(apiEndpoint, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonBody);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", $"Bearer {openRouterKey}");
            request.SetRequestHeader("HTTP-Referer", "https://github.com/yourusername/your-repo");
            request.SetRequestHeader("X-Title", "Dog Assistant");

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                var response = JsonUtility.FromJson<ChatResponse>(request.downloadHandler.text);
                if (response.choices != null && response.choices.Length > 0)
                {
                    string assistantMessage = response.choices[0].message.content;
                    
                    // Add assistant response to history
                    Array.Resize(ref conversationHistory, conversationHistory.Length + 1);
                    conversationHistory[conversationHistory.Length - 1] = new ChatMessage
                    {
                        role = "assistant",
                        content = assistantMessage
                    };

                    onResponse?.Invoke(assistantMessage);
                }
            }
            else
            {
                Debug.LogError($"Error: {request.error}");
                onResponse?.Invoke("Sorry, I encountered an error. Please try again.");
            }
        }
    }

    public void ClearConversation()
    {
        conversationHistory = new ChatMessage[0];
    }
} 