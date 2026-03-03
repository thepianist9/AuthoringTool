# Editor Authoring Graph System

A visual graph-based scripting system for Unity that allows you to create complex object behaviors through node-based workflows. Execute sequences of blocks to spawn, transform, and manipulate 3D objects dynamically.

## Requirements
- Unity Version: 6000.3.2f1

# Quick Start

### 1. Setup
1. Create an empty GameObject in your scene
2. Add the `GraphRunner` component to it
3. Use the Inspector buttons to create test graphs

### 2. Create a Test Graph
In the Inspector under **Test Graphs** section:
- Click **Create Test Graph 1** - Basic spawn, rotate, and conditional branching
- Click **Create Test Graph 2** - Spawn multiple objects with transformations
- Click **Create Test Graph 3** - Complex branching with movement and scaling

### 3. Execute a Graph
1. Select a test graph or load a saved one
2. Click **Execute Graph** in the Inspector
3. Objects will be spawned and transformed according to the graph

### 4. Clean Up
Click **Clear Scene** to remove all spawned graph objects from the scene
