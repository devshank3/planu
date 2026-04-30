# Planning Poker Tool - Implementation Walkthrough

The Planning Poker tool has been successfully implemented using Blazor Server and SignalR, adhering to the provided functional, technical, and UI Theme specifications. As requested, we used `PokerHub` as the hub name.

## What Was Built

### 1. Game State Models & Management
- **Models**: Created data structures (`Room` and `Player`) to track the estimation session state, connected users, card selections, and current topic.
- **RoomStateManager**: Implemented an in-memory concurrent dictionary service to manage active rooms, matching the prototype requirements.

### 2. Real-Time Communication (`PokerHub.cs`)
- Added SignalR to manage real-time game flows: joining a room, setting topics, selecting cards, revealing votes, and resetting the game.
- Managed SignalR `Groups` under the hood to ensure messages are isolated to specific rooms.

### 3. User Interface (UI)
- **`Lobby.razor` (Home page)**: Allows users to easily create a room as a Moderator or join an existing room via a room code.
- **`RoomView.razor`**: The primary game interface featuring:
  - **Moderator Controls**: Set the backlog item/topic, reveal the cards, and reset the board for a new round.
  - **Card Deck**: Shows cards based on the selected series (Fibonacci, Normal, or Custom).
  - **Results Area**: Automatically calculates and prominently displays the average estimate, highlighting the lowest and highest estimates when the cards are revealed.
  - **Player List**: Visually indicates who is thinking, who has cast their vote, and finally, their actual vote post-revelation.

### 4. Custom Styling (`poker.css`)
- Integrated your specified color palette into the application:
  - Background panels: Light variations of `Ash Grey`
  - Headers, text, and active cards: `Chocolate Plum`
  - Primary Buttons & Highest Estimate: `Terracotta Clay`
  - Highlights, Lowest Estimate, & Accents: `Golden Sand`
- The styles are injected into `App.razor` and apply globally to the components.

## Verification
- Verified and fixed the missing `Microsoft.AspNetCore.SignalR.Client` NuGet package dependency.
- Successfully built the application with `dotnet build` yielding 0 errors.

## Running the Application
You can now navigate into the root application directory and run it locally to see the results:
```bash
cd c:\Users\shank\Projects\AZ204\planu\src\planu\planuApp
dotnet run
```
Open multiple tabs and navigate to `localhost` to experience the real-time syncing between tabs!
