using System.Collections.Generic;
using UnityEngine;

namespace AuthoringTool.Blocks
{
    [System.Serializable]
    public class BlockGraph
    {
        public int EntryBlockId { get; set; } = -1;
        public Dictionary<int, BaseBlock> Blocks { get; private set; }

        public BlockGraph()
        {
            Blocks = new Dictionary<int, BaseBlock>();
        }

        public void Execute()
        {
            if (Blocks.Count == 0 || EntryBlockId == -1)
            {
                Debug.Log("No blocks to execute.");
                return;
            }
            else
            {
                BlockData blockData = new BlockData();
                int currentBlockId = EntryBlockId;
                while (Blocks.ContainsKey(currentBlockId))
                {
                    BaseBlock currentBlock = Blocks[currentBlockId];
                    currentBlock.Execute(blockData);
                    currentBlockId = currentBlock.NextBlockId;
                }
            }
        }
    }
}
