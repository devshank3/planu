# Planning Poker Tool - Functional Specification

## Overview

Planning poker is a Scrum story point estimation game-based tool. It is a card game used by Scrum teams to estimate the effort or relative size of user stories or features during sprint planning. Team members estimate by playing numbered cards face-down on the table. The cards are then revealed, and the estimates are discussed. The main value of planning poker lies in the discussion, as team members share why their estimates differ from the consensus.

## Features

### Landing Page
- Option to create a room
- Option to join a room with a code

### Room Creation
- The moderator (who creates the room) can choose the card series type:
  - Fibonacci
  - Normal numerical series
  - Other series
- The person who creates the room is by default the moderator
- The moderator can choose to spectate or join the game
- The moderator can share the room code or link for others to join


### Room settings 
- The moderator can set or change few options 
- The moderator can choose to allow players to reveal cards or only the moderator can reveal cards
- The story points series can be changed by the moderator at any time during the game

### Joining a Room
- Players joining the room are asked to enter a display name
- After entering the name, they can join the room

## Sharing the room 
- The moderator can share the room code or a link to invite others to join the room

### Roles
- **Moderator**: The Scrum Master or maintainer who manages the room and game
- **Players**: Other team members participating in the estimation

### Game Flow
- After all members join the room, the moderator can start the game by setting a backlog item or user story as the topic of estimation or issue

### Timer 
- The moderator can set a timer for the estimation process, which can be adjusted as needed
- By default, the timer is not set and players can take as much time as needed for estimation

### Display average estimation
- After the cards are revealed, the average estimation is calculated and displayed to all players

#### Estimation Process
- **Initial State**: Clean state where players can pick a card based on their story point estimation
- Cards are hidden initially
- The moderator (or players, if granted access) can reveal all cards
- Players can change their cards even after revelation and re-reveal to see updated estimates
- A reset button allows resetting the game state for a new round
- Players can start a new round by setting a new topic

#### Additional Features
- The lowest and highest estimated numbers are highlighted with different colors


---

### UI 
- The UI will be simple and intuitive, designed to facilitate quick and easy estimation
- The design will be responsive to accommodate different screen sizes and devices
- The UI will include visual indicators for the moderator and players, as well as clear buttons for actions like revealing cards and resetting the game
- The average estimation will be prominently displayed after card revelation, along with the lowest and highest estimates highlighted for easy identification
- The players will have a clear view of their selected cards and the overall game state, ensuring an engaging and interactive experience during the estimation process.

