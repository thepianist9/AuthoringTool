using System.Runtime.CompilerServices;
using UnityEngine;
namespace AuthoringTool.Blocks
{
    public enum Object3DType
    {
        Cube,
        Sphere,
        Cylinder,
    }
    public class SpawnBlock : BaseBlock
    {
        public Object3DType objectType;
        public Vector3 position;
        public Vector3 rotation;
        public Vector3 scale;

        public SpawnBlock(Object3DType objectType, Vector3 position, Vector3 rotation, Vector3 scale)
        {
            this.objectType = objectType;
            this.position = position;
            this.rotation = rotation;
            this.scale = scale;
        }
        public override void Execute(BlockData blockData)
        {
            GameObject spawnedObject = null;
            // Implementation for spawning a block
            switch (objectType)
            {
                case Object3DType.Cube:
                    spawnedObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    break;
                case Object3DType.Sphere:
                    spawnedObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    break;
                case Object3DType.Cylinder:
                    spawnedObject = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    break;
            }
            if (spawnedObject != null)
            {
                spawnedObject.transform.position = position;
                spawnedObject.transform.rotation = Quaternion.Euler(rotation);
                spawnedObject.transform.localScale = scale;
                spawnedObject.tag = "EditorOnly"; // Tag for cleanup
                blockData.CurrentGameObject = spawnedObject;
            }
                
        }
    }
}