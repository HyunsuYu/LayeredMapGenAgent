# Forgotten Game Dev Project Org

## Abstract
This Organization's primary goal is to manage the code base related to the game project Forgotten. It also provides convenience features such as related documentation and other materials

## Usage
> [!IMPORTANT]\
> This project is for Forgotten project development in Unity. Informs that no other game engine supports it

## Common Dependency
```
UnityEngine.dll
Newtonsoft.Json.dll
```

Each repository may have additional unique dependencies

## Features
- Common Utils
- Resource Management
- Map Generation
- Tool
- In-Game Management
    - Map Streaming Management
    - PC/NPC Movement

## Module Tree
```
Fogotten
├── Common Util
│   └── <Repo> CommonUtilLib
├── Resource Management
│   ├── <Repo> ResourcePathManagementLib
│   └── <Repo> ResourceDataManagementLib
├── Map Generation
│   ├── <Repo> ChiefMapGenerationLib
│   └── <Repo> MapGenerationAgent
├── Tool
│   └── <Repo> MapGenerationInputTool
└── In-Game Management
    ├── Map Streaming Management
    │   └── <Repo> MapStreamingManagementLib
    └── PC/NPC Movement
        └── <Repo> PcNpcMovementLib
```

## Hands-On Manual