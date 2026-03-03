using UnityEngine;

namespace AuthoringTool.Blocks
{
    public class RotateBlock : BaseBlock
    {
        public Vector3 targetRotation;

        public RotateBlock(Vector3 targetRotation)
        {
            this.targetRotation = targetRotation;
        }
        public override void Execute(BlockData blockData)
        {
            if (blockData.CurrentGameObject != null)
            {
                blockData.CurrentGameObject.transform.rotation = Quaternion.Euler(targetRotation);
            }
        }
    }
}