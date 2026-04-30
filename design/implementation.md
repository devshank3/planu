# Planning Poker Tool Implementation

Implement a Planning Poker tool as an interactive Blazor Server application using .NET 10 and SignalR. The tool will enable Scrum teams to estimate story points in real-time.

## User Review Required

> [!IMPORTANT]  
> The Blazor unified template uses static SSR by default for components. We will enforce `@rendermode InteractiveServer` at the page/component level to allow for real-time interactions and SignalR use.

> [!IMPORTANT]  
> I will be using in-memory state management (`RoomStateManager`) for storing the rooms and players. Since this is a prototype, if the app service restarts, the active rooms will be cleared. This matches the specification of a simple prototype.

## Proposed Changes

### Models & State Management
- Create data structures to handle the game state:
  - `Models/Player.cs`
  - `Models/Room.cs`
  - `Models/CardSeries.cs`
- Create an in-memory service to keep track of active rooms in a thread-safe manner (e.g. `ConcurrentDictionary`).
  - `Services/RoomStateManager.cs`

### SignalR Hub
- Implement the game logic and broadcasting via SignalR.
  - `Hubs/PokerHub.cs`
  - Handling connections and group messages for `CreateRoom`, `JoinRoom`, `SelectCard`, `RevealCards`, `ResetGame`, `UpdateTopic`, `ChangeSettings`.

### UI Components
- Develop Blazor UI components matching the defined UX states and UI Theme colors.
  - `Components/Pages/Lobby.razor` (Landing Page to Create/Join rooms)
  - `Components/Pages/RoomView.razor` (The main game board, rendered as `/room/{roomId}`)
  - `Components/App.razor` (Include custom stylesheets)
  - `wwwroot/css/poker.css` (Apply the provided color theme: Ash Grey, Chocolate Plum, Terracotta Clay, Golden Sand)

### Configuration
- Add SignalR and register `RoomStateManager`.
  - `Program.cs`
  - `builder.Services.AddSignalR();`
  - `builder.Services.AddSingleton<RoomStateManager>();`
  - `app.MapHub<PokerHub>("/pokerhub");`

## Verification Plan

### Manual Verification
- Run the Blazor Server app locally.
- Open multiple browser tabs (simulating different users).
- Create a room as a Moderator in Tab 1.
- Join the room as Player A in Tab 2 and Player B in Tab 3 using the room code.
- Verify real-time updates when players join, select cards, and when the moderator reveals cards or resets the game.
- Verify average score is calculated when cards are revealed and highlights min/max estimates.
- Verify UI theme correctly applies the custom palette (Ash Grey, Terracotta Clay, etc.).
