# Scripts Documentation

This folder contains all the C# scripts for the Dog Assistant project.

## API Key Setup

To run the project, you need to set up the following API keys in Unity Editor:

### TTSManager

1. Select the GameObject with TTSManager component
2. In the Inspector, find the `API Key` field
3. Enter your OpenAI API key
   - Get your API key from: https://platform.openai.com/api-keys

### ChatHandler

1. Select the GameObject with ChatHandler component
2. In the Inspector, find the `Open Router Key` field
3. Enter your OpenRouter API key
   - Get your API key from: https://openrouter.ai/keys

## Voice Command Features

### Math Game Mode

- Start: "let's play math game", "play math", etc.
- Ready: "are you ready"
- Start Game: "let's go"
- End Game: "take a break", "break time"

### Chat Mode

- Start: "let's talk", "let's chat"
- End: "stop talking", "end chat", "bye"

### Dog Commands

- Movement: "sit", "walk", "go forward", "go back", etc.
- Actions: "fetch", "eat", "follow me", etc.
- Emotions: "good boy", "bad boy", etc.

## File Structure

- `WitVoiceCommandHandler.cs`: Main voice command processing
- `TTSManager.cs`: Text-to-speech functionality
- `ChatHandler.cs`: ChatGPT integration
- `DogMovement.cs`: Dog animation and behavior control

## Development Notes

- All API keys are stored as placeholders in the code
- Actual API keys should be set in Unity Editor
- Never commit API keys to version control
