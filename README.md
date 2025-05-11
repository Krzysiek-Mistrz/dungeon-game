# Dungeon Game

A top-down 2D dungeon crawler built in Unity as part of a Unity learning course. Explore procedurally generated rooms, battle enemies, level up your character, and face off against bosses.

---

## Table of Contents

1. [Features](#features)  
2. [Prerequisites](#prerequisites)  
3. [Installation & Setup](#installation--setup)  
4. [Gameplay & Controls](#gameplay--controls)  
5. [Scripts Overview](#scripts-overview)  
6. [Contributing](#contributing)  
7. [License](#license)  

---

## Features

- Player movement and attack mechanics  
- Enemy AI with chase and trigger ranges  
- Boss that orbits fireballs around itself  
- Experience and leveling system  
- Healing and hit-point display  
- Breakable crates as environmental objects  
- On-screen floating text for damage, healing, and XP  

---

## Prerequisites

- Unity 2019.4 LTS or later  
- .NET Framework support enabled  
- Windows/macOS/Linux build targets installed (as needed)  

---

## Installation & Setup

1. **Clone the repository**  
   ```bash
   git clone https://github.com/yourusername/dungeon-game.git
   cd dungeon-game
   ```

2. **Open in Unity**  
   - Launch Unity Hub  
   - Add the `dungeon-game` folder as a project  
   - Open the project in the Unity Editor

3. **Configure Build Settings**  
   - Go to **File > Build Settings**  
   - Select your target platform  
   - Add the main scene (e.g., `Assets/Scenes/Main.unity`) to the Scenes In Build list  

4. **Run the Game**  
   - Press the **Play** button in the Unity Editor  
   - Build a standalone executable via **File > Build and Run**  

---

## Gameplay & Controls

### Controls

- **Move**: `W`, `A`, `S`, `D` or Arrow Keys  
- **Attack**: Automatic on collision with enemies  
- **Heal**: Use consumable items (if implemented)  
- **Pause/Resume**: `Esc` (opens death menu on game over)  

### Mechanics

- **Health & Damage**  
  - Player and enemies inherit from `Fighter`.  
  - Floating text shows damage, healing, and XP gains.  
- **Experience & Leveling**  
  - Defeating enemies grants XP.  
  - On level up, max hit points increase.  
- **Boss Behavior**  
  - Fireballs orbit the boss at variable speeds.  
- **Crates**  
  - Can be broken to clear paths (no loot implemented by default).  

---

## Scripts Overview

- **Player.cs**  
  Handles input, sprite swapping, leveling, healing, damage, and death state.

- **Enemy.cs**  
  AI logic for patrolling, chasing, collision detection, and death (XP grant).

- **Boss.cs**  
  Inherits `Enemy`; adds circular motion of fireball game objects.

- **Crate.cs**  
  Simple `Fighter` subclass that destroys itself on "death."

- **GameManager.cs**  
  Central manager for player/enemy references, UI updates, text popups, and scene management.

---

## Contributing

1. Fork the repository.  
2. Create a feature branch:  
   ```bash
   git checkout -b feature/YourFeature
   ```  
3. Commit your changes:  
   ```bash
   git commit -m "Add YourFeature"
   ```  
4. Push to your fork:  
   ```bash
   git push origin feature/YourFeature
   ```  
5. Open a Pull Request detailing your enhancements.

Please follow existing coding patterns, naming conventions, and include relevant unit tests or editor tests where applicable.

---

## License

GNU GPL V3 @ Krzychu 2023