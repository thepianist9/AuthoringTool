namespace AuthoringTool.Blocks
{
    public class CompareBlock : BaseBlock
    {
        public float targetValue;
        public ComparisonType comparisonType;
        public enum ComparisonType { GreaterThan, LessThan, EqualTo }
        public int TrueNextBlockId {  get; set; }
        public int FalseNextBlockId {  get; set; }

        public CompareBlock()
        {
            targetValue = 0f;
            comparisonType = ComparisonType.EqualTo;
            TrueNextBlockId = -1;
            FalseNextBlockId = -1;
        }

        public CompareBlock(float targetValue, ComparisonType comparisonType, int trueNextBlockId = -1, int falseNextBlockId = -1)
        {
            this.targetValue = targetValue;
            this.comparisonType = comparisonType;
            TrueNextBlockId = trueNextBlockId;
            FalseNextBlockId = falseNextBlockId;
        }
        public override void Execute(BlockData blockData)
        {
            if (blockData != null)
            {
                bool result = false;
                switch (comparisonType)
                {
                    case ComparisonType.GreaterThan:
                        result = blockData.CurrentValue > targetValue;
                        break;
                    case ComparisonType.LessThan:
                        result = blockData.CurrentValue < targetValue;
                        break;
                    case ComparisonType.EqualTo:
                        result = blockData.CurrentValue == targetValue;
                        break;
                }
                if (result)
                {
                    NextBlockId = TrueNextBlockId;
                }
                else
                {
                    NextBlockId = FalseNextBlockId;
                }
            }
        }
    }
}