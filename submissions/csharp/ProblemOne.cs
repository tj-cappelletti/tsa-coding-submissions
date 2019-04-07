using System.Collections.Generic;
using System.Linq;

namespace ProblemDriver
{
    public class ProblemOne
    {
        public int FirstDuplicate(int[] array)
        {
            var duplicates = new List<int>();
            var smallestOccurance = new Dictionary<int, int>();

            for (var index = 0; index < array.Length; index++)
                if (duplicates.Contains(array[index]))
                {
                    if (!smallestOccurance.ContainsKey(array[index])) smallestOccurance.Add(array[index], index);
                }
                else
                {
                    duplicates.Add(array[index]);
                }

            return smallestOccurance.Count > 0
                ? smallestOccurance.OrderBy(o => o.Value).First().Key
                : -1;
        }
    }
}