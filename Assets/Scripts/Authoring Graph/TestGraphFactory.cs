using AuthoringTool.Blocks;
using UnityEngine;

namespace AuthoringTool.Graphs
{
    public static class TestGraphFactory
    {
        public static BlockGraph CreateTestGraph1()
        {
            // A graph to spawn a cube, rotate it, set a value, and then conditionally spawn a sphere based on that value. This tests basic flow and conditional branching.
            BlockGraph testGraph = new BlockGraph();

            // Create blocks
            SpawnBlock spawnBlock = new SpawnBlock(Object3DType.Cube, Vector3.zero, Vector3.zero, Vector3.one);
            RotateBlock rotateBlock = new RotateBlock(Vector3.zero);
            ValueBlock valueBlock = new ValueBlock(2);
            // Compare block will check if CurrentValue > 1. If true it will spawn another object (id 5), otherwise end.
            CompareBlock compareBlock = new CompareBlock(1f, CompareBlock.ComparisonType.GreaterThan, 5, -1);
            SpawnBlock spawnBlock2 = new SpawnBlock(Object3DType.Sphere, Vector3.right * 2, Vector3.zero, Vector3.one * 2);

            // Assign ids
            spawnBlock.Id = 1;
            rotateBlock.Id = 2;
            valueBlock.Id = 3;
            compareBlock.Id = 4;
            spawnBlock2.Id = 5;

            // Link blocks
            spawnBlock.NextBlockId = 2; // after spawn -> rotate
            rotateBlock.NextBlockId = 3; // after rotate -> set value
            valueBlock.NextBlockId = 4; // after value -> compare
            // compareBlock will set NextBlockId during Execute based on comparison
            spawnBlock2.NextBlockId = -1; // end

            // Add blocks to graph
            testGraph.Blocks.Add(spawnBlock.Id, spawnBlock);
            testGraph.Blocks.Add(rotateBlock.Id, rotateBlock);
            testGraph.Blocks.Add(valueBlock.Id, valueBlock);
            testGraph.Blocks.Add(compareBlock.Id, compareBlock);
            testGraph.Blocks.Add(spawnBlock2.Id, spawnBlock2);

            // Set entry
            testGraph.EntryBlockId = 1;

            return testGraph;
        }

        public static BlockGraph CreateTestGraph2()
        {
            // Spawn a cube, scale it, then spawn a sphere and rotate it, testing both sequential and parallel flows.
            BlockGraph testGraph = new BlockGraph();

            // Create blocks
            SpawnBlock spawnCube = new SpawnBlock(Object3DType.Cube, Vector3.zero, Vector3.zero, Vector3.one);
            ScaleBlock scaleBlock = new ScaleBlock(Vector3.one * 2); // Scale cube to 2x
            SpawnBlock spawnSphere = new SpawnBlock(Object3DType.Sphere, Vector3.right * 3, Vector3.zero, Vector3.one);
            RotateBlock rotateBlock = new RotateBlock(new Vector3(45, 45, 0)); // Rotate sphere

            // Assign ids
            spawnCube.Id = 1;
            scaleBlock.Id = 2;
            spawnSphere.Id = 3;
            rotateBlock.Id = 4;

            // Link blocks: spawn cube -> scale -> spawn sphere -> rotate
            spawnCube.NextBlockId = 2;
            scaleBlock.NextBlockId = 3;
            spawnSphere.NextBlockId = 4;
            rotateBlock.NextBlockId = -1; // end

            // Add blocks to graph
            testGraph.Blocks.Add(spawnCube.Id, spawnCube);
            testGraph.Blocks.Add(scaleBlock.Id, scaleBlock);
            testGraph.Blocks.Add(spawnSphere.Id, spawnSphere);
            testGraph.Blocks.Add(rotateBlock.Id, rotateBlock);

            // Set entry
            testGraph.EntryBlockId = 1;

            return testGraph;
        }

        public static BlockGraph CreateTestGraph3()
        {
            // Spawn multiple objects and apply different transformations: spawn sphere, move it, spawn cylinder, then conditionally apply scale based on value comparison.
            BlockGraph testGraph = new BlockGraph();

            // Create blocks
            SpawnBlock spawnSphere = new SpawnBlock(Object3DType.Sphere, Vector3.zero, Vector3.zero, Vector3.one);
            MoveBlock moveBlock = new MoveBlock(Vector3.up * 3); // Move sphere up
            SpawnBlock spawnCylinder = new SpawnBlock(Object3DType.Cylinder, Vector3.left * 2, Vector3.zero, Vector3.one);
            ValueBlock valueBlock = new ValueBlock(3f);
            CompareBlock compareBlock = new CompareBlock(2f, CompareBlock.ComparisonType.GreaterThan, 6, 7);
            ScaleBlock scaleUpBlock = new ScaleBlock(Vector3.one * 1.5f); // Scale if value > 2
            ScaleBlock scaleDownBlock = new ScaleBlock(Vector3.one * 0.5f); // Scale if value <= 2

            // Assign ids
            spawnSphere.Id = 1;
            moveBlock.Id = 2;
            spawnCylinder.Id = 3;
            valueBlock.Id = 4;
            compareBlock.Id = 5;
            scaleUpBlock.Id = 6;
            scaleDownBlock.Id = 7;

            // Link blocks
            spawnSphere.NextBlockId = 2;
            moveBlock.NextBlockId = 3;
            spawnCylinder.NextBlockId = 4;
            valueBlock.NextBlockId = 5;
            // compareBlock will branch: true -> 6 (scale up), false -> 7 (scale down)
            scaleUpBlock.NextBlockId = -1; // end
            scaleDownBlock.NextBlockId = -1; // end

            // Add blocks to graph
            testGraph.Blocks.Add(spawnSphere.Id, spawnSphere);
            testGraph.Blocks.Add(moveBlock.Id, moveBlock);
            testGraph.Blocks.Add(spawnCylinder.Id, spawnCylinder);
            testGraph.Blocks.Add(valueBlock.Id, valueBlock);
            testGraph.Blocks.Add(compareBlock.Id, compareBlock);
            testGraph.Blocks.Add(scaleUpBlock.Id, scaleUpBlock);
            testGraph.Blocks.Add(scaleDownBlock.Id, scaleDownBlock);

            // Set entry
            testGraph.EntryBlockId = 1;

            return testGraph;
        }
    }
}
