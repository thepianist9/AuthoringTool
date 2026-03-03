using UnityEngine;

namespace AuthoringTool.Blocks
{
    [System.Serializable]
    public abstract class BaseBlock
    {
        public int Id { get; set; }
        public int NextBlockId { get; set; }
        public abstract void Execute(BlockData blockData);
    }
}
