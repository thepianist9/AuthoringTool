using UnityEngine;

namespace AuthoringTool.Blocks
{
    public class ValueBlock : BaseBlock
    {
        public float Value;

        public ValueBlock(float value)
        {
            Value = value;
        }

        public override void Execute(BlockData blockData)
        {
            if (blockData != null)
            {
                blockData.CurrentValue = Value;
            }
        }
    }
}