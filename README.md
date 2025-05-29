# AnimalRealityProjectFinal

This Unity project is part of a Capstone team project focused on building a **Virtual Service Animal** experience using voice commands and hand tracking in XR.

## 🐶 Features

- Voice command interaction via **Wit.ai**
- Dog character responds to:
  - Movement commands: sit, walk, stop, fetch, etc.
  - Emotional reactions: comfort, anger
  - Math mini-games and fetch mini-games
- Hand tracking input using XR Toolkit
- Unity XR Hands + Meta XR SDK integration
- Optional integration with backend AI server for:
  - Intent analysis
  - GPT-generated dialogue
  - Text-to-Speech (TTS) playback

## 🎧 Requirements

- Unity **2022.3.59f1**
- Meta Quest 2 (for full testing)
- Microphone for voice command input
- Wit.ai account & access token (if running standalone)

## 🛠 Setup

1. Open the project in Unity `2022.3.59f1`
2. In Unity: go to `Edit > Preferences > External Tools`, and set **Visual Studio Code** as external script editor.
3. Replace `witAccessToken` in code with your own from [https://wit.ai](https://wit.ai)
4. Press `Play` in Unity and speak commands such as:
   - `"sit down"`, `"come here"`, `"go left"`, `"fetch the ball"`

## 🧠 Backend Integration (Optional)

If you want to connect to the AI-enhanced backend server (Node.js):

- Clone the server repo and run `npm install && node server.js`
- Update Unity's `ServerVoiceCommandHandler.cs` with your server URL

## 📂 Project Structure

## ✍️ Team Members

- Ha Lee – Backend / AI Integration
-

---

## 📄 License

This project is for academic and demo purposes only.
