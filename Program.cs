// See https://aka.ms/new-console-template for more information

namespace LeetCode{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] flightsArr =  new int[5][];
            flightsArr[0] = new [] {0,1,100};
            flightsArr[1] = new [] {1,2,100};
            flightsArr[2] = new [] {2,0,100};
            flightsArr[3] = new [] {1,3,600};
            flightsArr[4] = new [] {2,3,200};
            Solution.FindCheapestPrice(4,flightsArr,0,3,1);
            Console.WriteLine("I'm here");
        }
    }
    class Solution {
        public static int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
            var total = 0;
            if(k == 0){
                var route = flights.FirstOrDefault(x => x[1] == dst); 
                if(route!=null){
                    total += route[2];
                }
            }
            else{
                var route = flights.FirstOrDefault(x => x[0] == src); 
                var followUps = flights.Where(x => x[0] == route[1]).ToArray();
                total += route[2];
                FindCheapestPrice(followUps.Count(), followUps, route[0], dst, k--);
            }
            return total;
        }
    };

}