using System;
using System.Collections.Generic;
using System.Linq;

namespace DIS_Assignment_2_Fall_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question1

            Console.WriteLine("Question 1");
            int[] heights = { -5, 1, 5, 0, -7 };
            int max_height = LargestAltitude(heights);
            Console.WriteLine("Maximum altitude gained is {0}", max_height);
            Console.WriteLine();

            //Question 2:
            Console.WriteLine("Question 2:");
            int[] nums = { 1, 3, 5, 6 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question3:
            Console.WriteLine("Question 3");
            string[] words1 = { "bella", "label", "roller" };
            List<string> commonWords = CommonChars(words1);
            Console.WriteLine("Common characters in all the strigs are:");
            for (int i = 0; i < commonWords.Count; i++)
            {
                Console.Write(commonWords[i] + "\t");
            }
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            int[] arr1 = { 1, 2, 2, 1, 1, 3 };
            bool unq = UniqueOccurrences(arr1);
            if (unq)
                Console.WriteLine("Number of Occurences of each element are unique");
            else
                Console.WriteLine("Number of Occurrences of each element are not unique");

            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Question 5");
            List<List<string>> items = new List<List<string>>();
            items.Add(new List<string>() { "phone", "blue", "pixel" });
            items.Add(new List<string>() { "computer", "silver", "phone" });
            items.Add(new List<string>() { "phone", "gold", "iphone" });

            string ruleKey = "type";
            string ruleValue = "phone";

            int matches = CountMatches(items, ruleKey, ruleValue);
            Console.WriteLine("Number of matches for the given rule :{0}", matches);

            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] Nums = { 2, 7, 11, 15 };
            int target_sum = 9;
            targetSum(Nums, target_sum);
            Console.WriteLine();

            //Question 7:

            Console.WriteLine("Question 7:");
            string allowed = "abc";
            string[] words = { "a", "b", "c", "ab", "ac", "bc", "abc" };
            int count = CountConsistentStrings(allowed, words);
            Console.WriteLine("Number of Consistent strings are : {0}", count);
            Console.WriteLine(" ");

            //Question 8:
            Console.WriteLine("Question 8");
            int[] num1 = { 12, 28, 46, 32, 50 };
            int[] num2 = { 50, 12, 32, 46, 28 };
            int[] indexes = AnagramMappings(num1, num2);
            Console.WriteLine("Mapping of the elements are");
            for (int i = 0; i < indexes.Length; i++)
            {
                Console.Write(indexes[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Question 9:
            Console.WriteLine("Question 9");
            int[] arr9 = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            int Ms = MaximumSum(arr9);
            Console.WriteLine("Maximun Sum contiguous subarray {0}", Ms);
            Console.WriteLine();

            //Question 10:
            Console.WriteLine("Question 10");
            int[] arr10 = { 2, 3, 1, 2, 4, 3 };
            int target_subarray_sum = 7;
            int minLen = minSubArrayLen(target_subarray_sum, arr10);
            Console.WriteLine("Minimum length subarray with given sum is {0}", minLen);
            Console.WriteLine();
        }


        /*
        Question 1:
        There is a biker going on a road trip. The road trip consists of n + 1 points at different altitudes. The biker starts his trip on point 0 with altitude equal 0.
        You are given an integer array gain of length n where gain[i] is the net gain in altitude between points i and i + 1  for all (0 <= i < n). Return the highest altitude of a point.
        Example 1:
        Input: gain = [-5,1,5,0,-7]
        Output: 1
        Explanation: The altitudes are [0,-5,-4,1,1,-6]. The highest is 1.
        */

        public static int LargestAltitude(int[] gain)
        {
            try
            {
                //write your code here.
                int max = 0;// intializing an integer value of 0 
                int[] high = new int[gain.Length + 1]; //setting an array of int data type equal to paramater 
                                                        // length plus 1 
                high[0] = 0; // array named high set equal to element 0 
                for (int i = 0; i < gain.Length; i++) // starting the for loop , and incrementing until reaches 
                                                        // parameter gain length 
                {
                    high[i + 1] = high[i] + gain[i]; // adding high array of current loop iteration to gain array of current iteration 
                                                    // setting the next elemeent of high array equal to the addition two arrays above 
                }
                for (int g = 0; g < high.Length; g++) // nested for loop iteration through the high array length 
                {
                    if (max < high[g]) // if max 0 is lessthan the current element of array high 
                    {
                        max = high[g]; // set max equal to the current element of array high 
                    }
                }
               return max; // returning the max alt value to the method as int value

            //   return 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
        
        Question 2:
        Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
        Note: The algorithm should have run time complexity of O (log n).
        Hint: Use binary search
        Example 1:
        Input: nums = [1,3,5,6], target = 5
        Output: 2
        Example 2:
        Input: nums = [1,3,5,6], target = 2
        Output: 1
        Example 3:
        Input: nums = [1,3,5,6], target = 7
        Output: 4
        */

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                //Write your Code here.
                int i = 0, j = nums.Length - 1; // setting variables i and j . j is equal to nums parameter array minus 1 
                while (i <= j)                  // initizaling for while loop , continues until i 0 is less than or equal to array length minus 1
                {
                    int mid = i + (j - i) / 2; // setting new int value equal to i minus J (array length minus 1) divided by 2
                    if (target == nums[mid]) // boolean if statement , if target parameter is equal to element mids of array nums 
                    {
                        return mid;          // then returning mid 
                    }
                    else if (target > nums[mid])  // if target int is greater than nums array element equal to mid variable , then set i
                                                   //then set I equal to mid plus 1
                    {
                        i = mid + 1;
                    }
                    else
                    { j = mid - 1; }          // else j is set equal to mid variable minus 1
                }
                return i;    // returning I variable to method
              //  return -1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         
        Question 3
       
        Given an array words of strings made only from lowercase letters, return a list of all characters that show up in all strings in words (including duplicates).  For example, if a character occurs 3 times in all strings but not 4 times, you need to include that character three times in the final answer.
        You may return the answer in any order.
        Example 1:
        Input: ["bella","label","roller"]
        Output: ["e","l","l"]
        Example 2:
        Input: ["cool","lock","cook"]
        Output: ["c","o"]
        
        */

        public static List<string> CommonChars(string[] words)
        {
            try
            {
                List<string> commonwords = new List<string>();  // initializing string called commonwords
                //write your code here.
                var x = words[0].ToCharArray().ToList(); //x is intersection  , setting x equal to words parameter , convert to list 
                for (int i = 1; i < words.Length; i++) //setting for loop , runs until i is equal to words array length 
                    for (int k = 0; k < x.Count; k++)// nested for loop , runs until k variable is equal or greater than count of x 
                    {
                        int index = words[i].IndexOf(x[k]); // setting int variable named index equal to current I iteration of words I of array x of K
                        if (index >= 0)                     // if index variable above is greater than or equal to = 
                            words[i] = words[i].Remove(index, 1); // set words array equal to current iteration , removing index 1
                        else
                        {
                            x.RemoveAt(k);              // else x , remove at k values 
                            k--;                        // reduce k 
                        }
                    }

                commonwords = x.Select(ch => ch.ToString()).ToList(); // setting commonwords to list
                 

                return commonwords;    // returning commonwords to method
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
        Question 4:
        Given an array of integers arr, write a function that returns true if and only if the number of occurrences of each value in the array is unique.
        Example 1:
        Input: arr = [1,2,2,1,1,3]
        Output: true
        Explanation: The value 1 has 3 occurrences, 2 has 2 and 3 has 1. No two values have the same number of occurrences.
        Example 2:
        Input: arr = [1,2]
        Output: false
       
         */

        public static bool UniqueOccurrences(int[] arr)
        {
            try
            {
                //write your code here.
                Dictionary<int, int> map = new Dictionary<int, int>();  // initializing dictionary , key and values are both int data type 
                foreach (int a in arr)    // for each loop, looping through each integer in the array 
                {
                    if (map.ContainsKey(a)) //if the map dictionary contains key value of the iteration of the loop
                        map[a] += 1;        // add one to the map  dictionary key
                    else
                        map[a] = 1;         // esle set dictionary key to 1
                }


                foreach (int v in map.Values) // for each value in dictionary 
                {
                    if (map.Values.Where(val => val == v).Count() > 1) // if there are multiple values found return true
                        return true;
                }
                return false ;
            


               //  return false;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /*
        
        Question 5:
        You are given an array items, where each items[i] = [type, color, name]  describes the type, color, and name of the ith item. You are also given a rule represented by two strings, ruleKey and ruleValue.
        The ith item is said to match the rule if one of the following is true:
        •	ruleKey == "type" and ruleValue == type.
        •	ruleKey == "color" and ruleValue == color.
        •	ruleKey == "name" and ruleValue == name.
        Return the number of items that match the given rule.
        Example 1:
        Input:  items = [["phone","blue","pixel"],["computer","silver","lenovo"],["phone","gold","iphone"]],  ruleKey = "color",  ruleValue = "silver".
        Output: 1
        Explanation: There is only one item matching the given rule, which is ["computer","silver","lenovo"].
        Example 2:
        Input: items = [["phone","blue","pixel"],["computer","silver","phone"],["phone","gold","iphone"]], ruleKey = "type",  ruleValue = "phone"
        Output: 2
        Explanation: There are only two items matching the given rule, which are ["phone","blue","pixel"]  and ["phone","gold","iphone"]. 
        Note that the item ["computer","silver","phone"] does not match.
        */

        public static int CountMatches(List<List<string>> items, string ruleKey, string ruleValue)
        {
            try
            {
                //write your code here.
                int index = 2; // setting int named index to 2 
                if (ruleKey.Equals("type")) // if rule key equals type set index to 0
                {
                    index = 0;
                }
                else if (ruleKey.Equals("color")) // if key equals color then set index to 1
                {
                    index = 1;
                }
                int count = 0;       // initializing count variable of int data type
                for (int i = 0; i < items.Count; i++) // starting for loop , ends when the i variable is equal or greater than the count of elements in the items string
                {
                    if (items[i][index].Equals(ruleValue)) // if the item array element equal to the current iteration of the loop and rulevalue , then increment the count plus 1
                    {
                        count++;
                    }
                }
                return count;   // returning the count of the loop
              //  return 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
        
        Question 6:
        
        Given an array of integers numbers that is already sorted in non-decreasing order, find two numbers such that they add up to a specific target number.
        Print the indices of the two numbers (1-indexed) as an integer array answer of size 2, where 1 <= answer[0] < answer[1] <= numbers. Length.
        You may not use the same element twice, there will be only one solution for a given array.
        Note: Solve it in O(n) and O(1) space complexity.
        Hint: Use the fact that array is sorted in ascending order and there exists only one solution.
        Typically, in these cases it’s useful to use pointers tracking the two ends of the array.
        Example 1:
        Input: numbers = [2,7,11,15], target = 9
        Output: [1,2]
        Explanation: The sum of 2 and 7 is 9. Therefore index1 = 1, index2 = 2.
        Example 2:
        Input: numbers = [2,3,4], target = 6
        Output: [1,3]
        Example 3:
        Input: numbers = [-1,0], target = -1
        Output: [1,2]
        */

        public static void targetSum(int[] nums, int target)
        {
            try
            {
                //write your code here.
                Dictionary<int, int> dict = new Dictionary<int, int>(); // initializing the dictionary 

                int i = 0;
                int j = nums.Length - 1;                        // setting j variable equal to the number length minus 1
                int sum = nums[i] + nums[j];                    // creating a sum variable and setting it equal to nums array of I plus nums array of J 
                while (sum != target)                           // creating a while loop , runs only while the sum variable is not equal to the target variable 
                {
                    if (sum < target)                           // if sum is less than target , increment i by 1 
                        i++;
                    else
                        j--;                                    // else decrease J by i 

                    sum = nums[i] + nums[j];                    // setting the sum equal to the nums array of I and J 
                }

                var x =  new int[] { i + 1, j + 1 };            // setting var x equal to a new int array to print
                Console.WriteLine(("" + string.Join(" ", x)));      //printing array as string 
                

            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
         
        Question 7:
        You are given a string allowed consisting of distinct characters and an array of strings words. A string is consistent if every character in words[i] appears in the string allowed.
        Return the number of consistent strings in the array words.
        Note: The algorithm should have run time complexity of O(n).
        Hint: Use Dictionaries. 
        Example 1:
        Input: allowed = "ab", words = ["ad","bd","aaab","baa","badab"]
        Output: 2
        Explanation: Strings "aaab" and "baa" are consistent since they only contain characters 'a' and 'b'. string “bd” is not consistent since ‘d’ is not in string allowed.
        Example 2:
        Input: allowed = "abc", words = ["a","b","c","ab","ac","bc","abc"]
        Output: 7
        Explanation: All strings are consistent.
        */

        public static int CountConsistentStrings(string allowed, string[] words)
        {
            try
            {
                int result = 0;
                int temp = 0;
                foreach (var word in words)             // starting a foreach loop searching the words string array 
                {
                    foreach (var c in word)         // nested foreach loop searching word variable 
                    {
                        if (!allowed.Contains(c))         // if not string allowed contains c break the loop 
                        {
                            break;
                        }
                        else
                        {
                            temp++;                 // else increment the temp variable 
                        }
                    }
                    result += temp / word.Length;       // updating the result variable plus temp variable divided by the length of word 
                    temp = 0;                               // setting temp back to 2
                }

                return result;                      // returning result variable to method
                // return 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
        Question 8:
        You are given two integer arrays nums1 and nums2 where nums2 is an anagram of nums1. Both arrays may contain duplicates.
        Return an index mapping array mapping from nums1 to nums2 where mapping[i] = j indicates that  the ith element in nums1 appears in nums2 at index j. If there are multiple answers, return any of them.
        An array a is an anagram of array b if b is made by randomizing the order of the elements in a.
 
        Example 1:
        Input: nums1 = [12,28,46,32,50], nums2 = [50,12,32,46,28]
        Output: [1,4,3,2,0]
        Explanation: As mapping[0] = 1 because the 0th element of nums1 appears at nums2[1], and mapping[1] = 4 because the 1st element of nums1 appears at nums2[4], and so on.
        */

        public static int[] AnagramMappings(int[] nums1, int[] nums2)
        {
            try
            {
                //write your code here.


                int[] ans = new int[nums1.Length]; // setting array to nums1 length parameter
                                                   // 

                for ( int i = 0; i<nums1.Length; i++) // looping until i is equal or greater than nums1 array length
                {
                    ans[i] = Array.IndexOf(nums2, nums1[i]);            //setting the array of I equal to the array index first occurance of nums1 of i



                }

                return ans;                                                 // returning the int array values 
            }
            catch (Exception)
            {
                throw;
            }
        }
        /*
        
        Question 9:
        Given an integer array nums, find the contiguous subarray (containing at least one number)
        which has the largest sum and return its sum.
        Note: Time Complexity should be O(n).
        Hint: Keep track of maximum sum as you move forward.
        Example 1:
        Input: nums = [-2,1,-3,4,-1,2,1,-5,4]
        Output: 6
        Explanation: [4,-1,2,1] has the largest sum = 6.
        Example 2:
        Input: nums = [1]
        Output: 1
        */

        public static int MaximumSum(int[] arr)
        {
            try
            {
                int max = 0;            
                int sum = 0;
                int n = arr.Length;             // creating int variable n and setting to arr length 

                for (int i = 0; i < n; i++)         // starting for loop , runs until current iteration is equal or greater than arr length
                {
                    sum = sum + arr[i];         // setting sum equal to 0 plus arr of the current iteration 
                    if (sum < 0)                // IF sum is less than sum , then set sum equal to 0 
                        sum = 0;
                    if (max < sum)                  // if max is less than sum then set max equal to sum 
                        max = sum;
                }
                return max;                     // returning max 
             //   return 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
         
        Question 10:
        Given an array of positive integers nums and a positive integer target, return the minimal 
        length of a contiguous subarray [nums[l], nums[l+1], ..., nums[r-1], nums[r]] 
        of which the sum is greater than or
        equal to target. If there is no such subarray, return 0 instead.
        Note: Try to solve it in O(n) time.
        Hint: Try to create a window and track the sum you have in the window.
        Example 1:
        Input: target = 7, nums = [2,3,1,2,4,3]
        Output: 2
        Explanation: The subarray [4,3] has the minimal length under the problem constraint.
        Example 2:
        Input: target = 4, nums = [1,4,4]
        Output: 1
        */

        public static int minSubArrayLen(int target_subarray_sum, int[] arr10)
        {
            try
            {
                //write your code here.
                var sum = 0;
                var len = int.MaxValue;         // setting len to int max value 
                var j = 0;

                for (var i = 0; i < arr10.Length; i++)      // starting for loop and runs until i is equal or greater than the array10 length 
                {   
                    sum += arr10[i];                        // adding sum to the array10 current loop iteration 

                    while (sum >= target_subarray_sum)      // while loop executing only while sum is greater than or eqaul to target sub array 
                    {
                        len = Math.Min(len, i - j + 1); //returning the min value.  Len variable or I minus J plus 1    
                        sum -= arr10[j++];                  // sum minus arr10 of j increment by 1
                    }
                }

                return len == int.MaxValue ? 0 : len;           //  returning the len where it is equal to the int maxvalue variable 
               // return 0;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}