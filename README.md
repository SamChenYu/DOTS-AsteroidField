# Data Oriented Technology Stack

- Overview of DOTS

ECS:
- Entitiy: Unique ID representing an object in the game
- Component: pure data / attribute attached to entities
- System: Logic that processes entities with specific components
(Variables and functions of traditional OOP classes are detached in DOTS)

C# Job System:
- Allows you to schedule work across multiple CPU cores without writing threading code manually

Burst Compiler:
- Compiles C# jobs into optimized machine code 
- OOP classes are memory intensvie and not cache friendly. Splitting the data into ECS allows for contiguous memory that allows cache to remain warm.




Asteroids/Dots
- FindNearestDOTS is the MonoBehaviour object that pipelines GameObjects into DOTS/ECS
- NativeArrays are data structures used for safe parallelization
- Jobs are scheduled and picked up by the threads for multi-threading