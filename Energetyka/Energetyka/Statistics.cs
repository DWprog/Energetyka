

using System;

namespace Energetyka
{
    public class Statistics
    {
        public float Max { get; private set; }
        public float Min { get; private set; }
        public float Sum { get; private set; }
        public int Count { get; private set; }
        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }

        public Statistics()
        {
            Count = 0;
            Sum = 0f;
            Max = float.MinValue;
            Min = float.MaxValue;
        }

        public void AddValue(float value)
        {
            Count++;
            Sum += value;
            Max = Math.Max(value, Max);
            Min = Math.Min(value, Min);
        }

    }
}
