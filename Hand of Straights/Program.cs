using System;
using System.Collections.Generic;
using System.Linq;

namespace Hand_of_Straights
{
  class Program
  {
    static void Main(string[] args)
    {
      var hand = new int[] { 1, 1, 2, 2, 3, 3 }; //1, 2, 3, 6, 2, 3, 4, 7, 8
      int groupSize = 2;
      Solution s = new Solution();
      var resut = s.IsNStraightHand(hand, groupSize);
      Console.WriteLine(resut);
    }
  }

  public class Solution
  {
    public bool IsNStraightHand(int[] hand, int groupSize)
    {
      // if total elements can not divisible by group size we can not make groups
      if (hand.Length % groupSize != 0) return false;
      SortedDictionary<int, int> frequency = new SortedDictionary<int, int>();
      // calculate the frequency ds
      foreach (int i in hand)
      {
        if (!frequency.ContainsKey(i))
          frequency.Add(i, 0);

        frequency[i] += 1;
      }

      while (frequency.Count > 0)
      {
        var keys = frequency.Keys.ToArray();
        // if no of elements present in the frequency lesser than groupSize, we can not proceed
        if (keys.Length < groupSize) return false;
        // take the first element of the group
        var start = keys[0];
        // reduce frequency by 1
        frequency[start] -= 1;
        // after reducing if it has become 0, we have utilized all so remove this key
        if (frequency[start] == 0) frequency.Remove(start);
        // your next no in the group
        int next = start + 1;
        // start from the second no 
        for (int i = 1; i < groupSize; i++)
        {
          // if the group next no present on the frequency
          if (keys[i] == next)
          {
            // reduce its frequency count
            frequency[next] -= 1;
            // after reducing if it has became 0 remove it
            if (frequency[next] == 0) frequency.Remove(next);
            // get the next no in the group
            next += 1;
          }
          else return false;
        }
      }

      return true;
    }
  }
}
