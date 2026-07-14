# Tower Defense Template
<p align="center">
  An exercise where explores the modularity, reusabulity and scalability of game systems.
  <br><br>
  <img src="Media/Tower_Defense_Template_Page.png" width="480">
</p>

## Overview
The Tower Defense Template serves as a foundation for experimenting with scalable game systems that can be reused across different genres rather than developing a polished tower defense game.

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

## Technology
- **Unity** – Core game engine used for developing the game archtiecture and systems.
- **C#** – Primary programming language for gameplay mechanics and systems.
- **Microsoft Visual Studio** – IDE used for scripting and debugging.

## Media
