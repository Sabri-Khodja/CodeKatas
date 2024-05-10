
namespace Range
{
    public class Range
    {
        public int LowerEnd { get; private set; }
        public bool LowerEndIncluded { get; private set; }
        public int UpperEnd { get; private set; }
        public bool UpperEndIncluded { get; private set; }

        public int GetLowerValue()
        {
            if (LowerEndIncluded)
            {
                return LowerEnd;
            }

            return LowerEnd + 1;
        }

        public int GetUpperValue()
        {
            if (UpperEndIncluded)
            {
                return UpperEnd;
            }

            return UpperEnd - 1;
        }

        public Range(int lowerEnd, bool lowerEndIncluded, int upperEnd, bool upperEndIncluded)
        {
            LowerEnd = lowerEnd;
            LowerEndIncluded = lowerEndIncluded;
            UpperEnd = upperEnd;
            UpperEndIncluded = upperEndIncluded;
        }
        
        public bool Contains(int valueToCheck)
        {
            if((valueToCheck < LowerEnd)
               || (valueToCheck > UpperEnd)
               || (valueToCheck == LowerEnd && !LowerEndIncluded)
               || (valueToCheck == UpperEnd && !UpperEndIncluded)
                )
            {
                return false;
            }

            return true;
        }

        public int[] GetAllPoints()
        {
            var lowerBound = LowerEndIncluded ? LowerEnd : LowerEnd + 1;
            var upperBound = UpperEndIncluded ? UpperEnd : UpperEnd - 1;

            var results = new int[upperBound - lowerBound + 1];
            for (int i = 0; i <= upperBound - lowerBound; i++)
            {
                results[i] = i + lowerBound;
            }

            return results;
        }

        public bool ContainsRange(Range range)
        {
            if (!Contains(range.GetLowerValue()))
            {
                return false;
            }

            if (!Contains(range.GetUpperValue()))
            {
                return false;
            }

            return true;
        }

        public int[] EndPoints()
        {
            var endPoints = new int[2];
            endPoints[0] = GetLowerValue();
            endPoints[1] = GetUpperValue();
            return endPoints;
        }

        public bool OverlapsRange(Range range)
        {
            if (Contains(range.GetLowerValue()) || Contains(range.GetUpperValue()) || range.ContainsRange(this))
            {
                return true;
            }

            return false;
        }

        public bool Equals(Range range)
        {
            return GetLowerValue() == range.GetLowerValue() && GetUpperValue() == range.GetUpperValue();
        }
    }
}
