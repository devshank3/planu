### Technology Stack

- .NET 10
- Blazor Server side rendering 
- SignalR


- The created project template currently is a simple .NET 10 Blazor web app with server side rendering. Blazor Web App (Unified template in .NET 10)

- Use SignalR for real-time communication between the clients and the server, enabling features like card revelation and game state updates.

- Blazor Server (Interactive Server) + SignalR (under the hood)

- Use SignalR hub to manage the game state and facilitate communication between the clients and the server. The hub will handle actions such as creating rooms, joining rooms, revealing cards, and resetting the game.

- Use group to manage the rooms and ensure that messages are sent only to the relevant clients in each room.

- No authentication or authorization is required for this application, as it is designed for internal team use and prototype.

---

Blazor Render Mode Choice (Critical)

Use:

```@rendermode InteractiveServer```

Why:

- Keeps logic on server
- No heavy client-side sync issues
- Perfect for real-time apps

---

Blazor UI (Components)
        ↓
Application Services (Game logic)
        ↓
Room State Manager (in-memory state management)
        ↓
SignalR Hub (real-time sync)


---

Key UX States (Map to Components)

1. Lobby
- Create Room
- Join Room

2. Room Waiting State
- Show players
- Moderator controls

3. Voting State
- Card selection (hidden)

4. Reveal State
- Show all cards
- Average / discussion

5. Reset
- Clear votes
- Back to voting

---
Single project only for simplicity and ease of development, as this is a prototype application. 

---

### Hosting

- Azure App Service for hosting the application 