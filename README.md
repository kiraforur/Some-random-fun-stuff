# Unity & C# Game Development Prototypes

Welcome to my portfolio repository containing two distinct game projects built with Unity and C#. These projects demonstrate my progression in implementing structured architecture, event-driven systems, and responsive gameplay mechanics.

---

## Project 1: Collaborative Prototype (In Progress)
*Developed in collaboration with a fellow developer.*

A shared project focusing on gameplay mechanics, collaborative version control workflows via Git, and modular team development. 
* **Key Focus:** Component-based design, scene management, and code reusability across a shared pipeline.

---

## Project 2: Beat’em-Up Prototype (Vertical Slice)
*Individual personal project in active development.*

A playable prototype demonstrating a vertical slice of a classic beat’em-up game. This project serves as my main architectural playground, focusing strictly on avoiding "Spaghetti Code" and ensuring high performance within the Unity lifecycle.

### Architectural Highlights & Design Patterns*
* **Separation of Concerns:** Core systems like health logic are strictly separated into pure C# classes, decoupling the underlying gameplay data from Unity's `MonoBehaviour` and rendering loop.
* **State Pattern:** Used to handle the character's lifecycle states (Idle, Running, Jumping, Attacking, Hurt, Dead). This keeps animation transitions and input logic locked into a manageable finite state machine, preventing bugged overlapping states.
* **Command Pattern:** Currently being structured to handle user inputs. This will allow the game to encapsulate action requests (like attacks and movements) into object commands, paving the way for a clean input buffering system.

  
### Active Work
* Implemented core physics-based movement, double-tap running, and gravity-tuned jumping.
* **Current Focus:** I am currently setting up the `ComboString` and non-looping animation string transitions in the Unity Animator to properly link users input. After that part is complited - going to work on implementing Hitboxes and Hurtboxes along with active-frames.

---

## Technical Stack Summary
* **Engine:** Unity
* **Language:** C#
* **Architecture:** Event-Driven Programming, Object-Oriented Design (OOP), MVP Pattern, Interface Segregation.
