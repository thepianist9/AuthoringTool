using UnityEngine;

namespace AuthoringTool.Blocks
{
    public class ScaleBlock : BaseBlock
    {
        public Vector3 targetScale;
        public ScaleBlock(Vector3 targetScale)
        {
            this.targetScale = targetScale;
        }
        public override void Execute(BlockData blockData)
        {
            if (blockData.CurrentGameObject != null)
            {
                blockData.CurrentGameObject.transform.localScale = targetScale;
            }
        }
    }
}