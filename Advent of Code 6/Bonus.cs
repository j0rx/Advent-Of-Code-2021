using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_6
{
    class Bonus
    {
        int CountFishRecursive(int days, byte[] inputs, int toDays)
        {
            if (days == toDays)
                return inputs.Length;
            var birthCount = 0;
            for (int i = 0; i < inputs.Length; i++)
            {
                if (inputs[i] == 0)
                {
                    birthCount += 1;
                    inputs[i] = 6;
                }
                else
                    inputs[i] -= 1;
            }
            byte[] newInputs = new byte[birthCount];
            for (int i = 0; i < birthCount; i++)
            {
                newInputs[i] = 8;
            }
            return CountFishRecursive(days + 1, inputs.Concat(newInputs).ToArray(), toDays);
        }
        int CountFishObject(int days, byte[] inputs)
        {
            var fishList = new List<LanternFish>();
            for (int i = 0; i < inputs.Length; i++)
            {
                fishList.Add(new LanternFish(inputs[i]));
            }
            for (int i = 0; i < days; i++)
            {
                var currentFishCount = fishList.Count;
                for (int j = 0; j < currentFishCount; j++)
                {
                    if (fishList[j].GiveBirth())
                    {
                        fishList.Add(new LanternFish(8));
                    }
                }
            }
            return fishList.Count;
        }
    }
    class LanternFish
    {
        public int DaysUntilBirth { get; set; }
        public LanternFish(int daysUntilBirth)
        {
            DaysUntilBirth = daysUntilBirth;
        }
        public bool GiveBirth()
        {
            if (DaysUntilBirth == 0)
            {
                DaysUntilBirth = 6;
                return true;
            }
            else
                DaysUntilBirth -= 1;
            return false;
        }
    }
}
