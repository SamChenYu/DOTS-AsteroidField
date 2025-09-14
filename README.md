# Data Oriented Technology Stack

## Overview of DOTS

ECS:
- Entity: Unique ID representing an object in the game
- Component: Pure data / attribute attached to entities
- System: Logic that processes entities with specific components  
(Variables and functions of traditional OOP classes are detached in DOTS)

C# Job System:
- Allows you to schedule work across multiple CPU cores without writing threading code manually

Burst Compiler:
- Compiles C# jobs into optimized machine code 
- OOP classes are memory intensvie and not cache friendly. Splitting the data into ECS allows for contiguous memory that allows cache to remain warm.

## Scenes

SingleThread
- Traditional GameObject based (very slow!!)

DOTS - 1,000x Seekers & Targets
- FindNearestDOTS is the MonoBehaviour object that pipelines GameObjects into DOTS/ECS
- NativeArrays are data structures used for safe parallelization
- Jobs are scheduled and picked up by the threads for multi-threading

DOTS Parallel - 10,000x Seekers & Targets
- FindNearestedJobParallel: Converted from IJob to IJobParallelFor
- Split the SeekerPosition array indicies between threads E.g. thread 1 - [0,49], thread 2 - [50,99], thread 3 - [100,149]