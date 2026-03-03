using AuthoringTool.Blocks;
using UnityEngine;

namespace AuthoringTool.Graphs
{
    public static class TestGraphFactory
    {
        //Example test Configurations for testing the BlockGraph execution logic
        public static BlockGraph CreateTestGraph1()
        {
            BlockGraph testGraph = new BlockGraph();

            SpawnBlock spawnBlock = new SpawnBlock(Object3DType.Cube, Vector3.zero, Vector3.zero, Vector3.one);
            RotateBlock rotateBlock = new RotateBlock(Vector3.zero);
            ValueBlock valueBlock = new ValueBlock(2);
            CompareBlock compareBlock = new CompareBlock(1f, CompareBlock.ComparisonType.GreaterThan, 5, -1);
            SpawnBlock spawnBlock2 = new SpawnBlock(Object3DType.Sphere, Vector3.right * 2, Vector3.zero, Vector3.one * 2);

            spawnBlock.Id = 1;
            rotateBlock.Id = 2;
            valueBlock.Id = 3;
            compareBlock.Id = 4;
            spawnBlock2.Id = 5;

            spawnBlock.NextBlockId = 2;
            rotateBlock.NextBlockId = 3;
            valueBlock.NextBlockId = 4;
            spawnBlock2.NextBlockId = -1;

            testGraph.Blocks.Add(spawnBlock.Id, spawnBlock);
            testGraph.Blocks.Add(rotateBlock.Id, rotateBlock);
            testGraph.Blocks.Add(valueBlock.Id, valueBlock);
            testGraph.Blocks.Add(compareBlock.Id, compareBlock);
            testGraph.Blocks.Add(spawnBlock2.Id, spawnBlock2);

            testGraph.EntryBlockId = 1;
            return testGraph;
        }

        public static BlockGraph CreateTestGraph2()
        {
            BlockGraph testGraph = new BlockGraph();

            SpawnBlock spawnCube = new SpawnBlock(Object3DType.Cube, Vector3.zero, Vector3.zero, Vector3.one);
            ScaleBlock scaleBlock = new ScaleBlock(Vector3.one * 2);
            SpawnBlock spawnSphere = new SpawnBlock(Object3DType.Sphere, Vector3.right * 3, Vector3.zero, Vector3.one);
            RotateBlock rotateBlock = new RotateBlock(new Vector3(45, 45, 0));

            spawnCube.Id = 1;
            scaleBlock.Id = 2;
            spawnSphere.Id = 3;
            rotateBlock.Id = 4;

            spawnCube.NextBlockId = 2;
            scaleBlock.NextBlockId = 3;
            spawnSphere.NextBlockId = 4;
            rotateBlock.NextBlockId = -1;

            testGraph.Blocks.Add(spawnCube.Id, spawnCube);
            testGraph.Blocks.Add(scaleBlock.Id, scaleBlock);
            testGraph.Blocks.Add(spawnSphere.Id, spawnSphere);
            testGraph.Blocks.Add(rotateBlock.Id, rotateBlock);

            testGraph.EntryBlockId = 1;
            return testGraph;
        }

        public static BlockGraph CreateTestGraph3()
        {
            BlockGraph testGraph = new BlockGraph();

            SpawnBlock spawnSphere = new SpawnBlock(Object3DType.Sphere, Vector3.zero, Vector3.zero, Vector3.one);
            MoveBlock moveBlock = new MoveBlock(Vector3.up * 3);
            SpawnBlock spawnCylinder = new SpawnBlock(Object3DType.Cylinder, Vector3.left * 2, Vector3.zero, Vector3.one);
            ValueBlock valueBlock = new ValueBlock(3f);
            CompareBlock compareBlock = new CompareBlock(2f, CompareBlock.ComparisonType.GreaterThan, 6, 7);
            ScaleBlock scaleUpBlock = new ScaleBlock(Vector3.one * 1.5f);
            ScaleBlock scaleDownBlock = new ScaleBlock(Vector3.one * 0.5f);

            spawnSphere.Id = 1;
            moveBlock.Id = 2;
            spawnCylinder.Id = 3;
            valueBlock.Id = 4;
            compareBlock.Id = 5;
            scaleUpBlock.Id = 6;
            scaleDownBlock.Id = 7;

            spawnSphere.NextBlockId = 2;
            moveBlock.NextBlockId = 3;
            spawnCylinder.NextBlockId = 4;
            valueBlock.NextBlockId = 5;
            scaleUpBlock.NextBlockId = -1;
            scaleDownBlock.NextBlockId = -1;

            testGraph.Blocks.Add(spawnSphere.Id, spawnSphere);
            testGraph.Blocks.Add(moveBlock.Id, moveBlock);
            testGraph.Blocks.Add(spawnCylinder.Id, spawnCylinder);
            testGraph.Blocks.Add(valueBlock.Id, valueBlock);
            testGraph.Blocks.Add(compareBlock.Id, compareBlock);
            testGraph.Blocks.Add(scaleUpBlock.Id, scaleUpBlock);
            testGraph.Blocks.Add(scaleDownBlock.Id, scaleDownBlock);

            testGraph.EntryBlockId = 1;
            return testGraph;
        }
    }
}
