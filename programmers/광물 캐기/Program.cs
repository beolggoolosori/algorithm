// https://school.programmers.co.kr/learn/courses/30/lessons/172927
namespace 광물캐기
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] picks1 = { 1, 3, 2 };
            string[] minerals1 = { "diamond", "diamond", "diamond", "iron", "iron", "diamond", "iron", "stone" };
            Console.WriteLine($"Expected: 12, Result: {Solution(picks1, minerals1)}");

            int[] picks2 = { 0, 1, 1 };
            string[] minerals2 = { "diamond", "diamond", "diamond", "diamond", "diamond", "iron", "iron", "iron", "iron", "iron", "diamond" };
            Console.WriteLine($"Expected: 50, Result: {Solution(picks2, minerals2)}");
        }
        public static int Solution(int[] picks, string[] minerals)
        {

        }
    }
}