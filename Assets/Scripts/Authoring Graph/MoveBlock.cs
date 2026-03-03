using UnityEngine;

namespace AuthoringTool.Blocks
{
    public class MoveBlock : BaseBlock
    {
        public Vector3 targetPosition;

        public MoveBlock(Vector3 targetPosition)
        {
            this.targetPosition = targetPosition;
        }
        public override void Execute(BlockData blockData)
        {
            if(blockData.CurrentGameObject != null)
            {
                blockData.CurrentGameObject.transform.position = targetPosition;
            }
        }
    }
}
