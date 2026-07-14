# Tower Defense Template
<p align="center">
  An exercise where the modularity, reusabulity and scalability of game systems were explored.
  <br><br>
  <img src="Media/Tower_Defense_Template_Page.png" width="480">
</p>

## Overview
The Tower Defense Template is solely developed during the Industrial Training course. This project serves as a foundation for experimenting with scalable game systems that can be reused across different genres rather than developing a polished tower defense game.

During development, this project became a valuable learning platform for understanding software architecture, system decoupling and code reusability. Many of the concepts and design patterns explored in this project were later refined and expanded in <a href="https://github.com/YongKang03/versus-multiplayer-shooter">Versus Multiplayer Shooter</a> project, where they were adapted to support more complex gameplay mechanics and multiplayer networking.

## Objective
- **Apply object-oriented programming concepts in game development**
  - Use abstract classes to create a flexible stat system structure.
  - Apply interfaces to decouple gameplay interactions such as targeting and damage handling.
  - Utilize events and delegates to improve communication between independent systems, including weapon switching, UI updates and state behaviour interactions.
- **Develop reusable gameplay systems through modular architecture**
  - Design a generic stat management system that allows different gameplay attributes to be extended and managed consistently.
  - Build a state machine framework with reusable states and state behaviours to support flexible entity behaviours.
  - Improve separation of responsibilities by ensuring individual systems handle their own specific logic without unnecessary dependencies.
- **Explore Unity ScriptableObject-based architecture**
  - Utilize ScriptableObjects to create data-driven and configurable gameplay components.
  - Implement ScriptableObject-based states, behaviours and data structures to improve scalability and reduce hardcoded logic.
- **Understand software architecture principles for larger-scale projects**
  - Practice designing maintainable systems through abstraction, decoupling and modularity.

## Feature
### Stat
Create a reusable framework for managing gameplay attributes such as health, energy and cooldowns.

Developed a `StatManager` that stores different stat objects through a common interface. Individual stats (`HealthStat`, `EnergyStat`, `GunCooldownStat`) inherit from an abstract `Stat` class and own an unique `StatID` enum. Configuration values are stored separately using `StatData` ScriptableObject. EEach of stats can be paired with a `StatID` and `StatData`, and `StatManager` exposes these stats to other classes with encapsulation.

- Supports adding new stat types without modifying existing systems.
- Separates runtime values from configurable data.
- Allows UI and gameplay systems to access stats through a unified interface.

<p align="center">
  <br>
  <img src="Media/Tower_Defense_Template_Stat_Architecture.png" width="480">
  <br><br>
  The architecture of the <code>Stat</code>.
</p>

### State machine
Provide a reusable framework for controlling gameplay behaviours without hardcoding state transitions for individual game objects.

Implemented a `StateMachine` architecture that supports and scales with states. Individual states are created as `StateSO` ScriptableObject containing configurable enter, update and exit behaviours. Every enter, update and exit behaviours are defined as `StateBehaviourSO` ScriptableObject where they run a specific behaviour from a defined state manager. State transitions are evaluated through reusable `TransitionSO` objects during the update behaviours, which contains a `ConditionSO` that runs a boolean method, the desired boolean output and the new `StateSO` to switch to. `EventSO` ScriptableObject is used to represent an event that can be invoked later for others in the `StateSO` behaviours using `InvokeEventSO` (`EventSO` and `InvokeEventSO` are SO-driven concept, they can be expanded to handle different type of events such as void or interface-based events). Each behaviour can be configured directly in the Unity Inspector after the required methods are defined, allowing state logic to be adjusted without modifying source code.

- Generic implementation reusable across different entity types.
- ScriptableObject-driven workflow reduces duplicated code.
- Behaviours and transitions can be composed through the Unity Inspector.
- Encourages separation between state logic and gameplay objects.

<p align="center">
  <br>
  <img src="Media/Tower_Defense_Template_State_Architecture.png" width="480">
  <br><br>
  The architecture of the <code>State</code>.
</p>

## Technology
- **Unity** – Core game engine used for developing the game archtiecture and systems.
- **C#** – Primary programming language for gameplay mechanics and systems.
- **Microsoft Visual Studio** – IDE used for scripting and debugging.

## Reflection


## Media
