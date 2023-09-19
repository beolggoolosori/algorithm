using System;

namespace 문자열압축
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();

            Console.WriteLine("결과: " + program.solution("aabbaccc") + " // 예상결과 : 7");
            Console.WriteLine("결과: " + program.solution("ababcdcdababcdcd") + " // 예상결과 : 9"); 
            Console.WriteLine("결과: " + program.solution("abcabcdede") + " // 예상결과 : 8");
            Console.WriteLine("결과: " + program.solution("abcabcabcabcdededededede") + " // 예상결과 : 14");
            Console.WriteLine("결과: " + program.solution("xababcdcdababcdcd") + " // 예상결과 : 17"); 
        }

        public int solution(string s)
        {
            int answer = s.Length;

            for (int step = 1; step <= s.Length / 2; step++)
            {
                string compressed = "";
                string prev = s.Substring(0, step);
                int count = 1;

                for (int j = step; j < s.Length; j += step)
                {
                    if (j + step > s.Length)
                    {
                        compressed += s.Substring(j);
                        break;
                    }

                    string sub = s.Substring(j, step);

                    if (prev == sub)
                    {
                        count++;
                    }
                    else
                    {
                        compressed += (count > 1 ? count.ToString() : "") + prev;
                        prev = sub;
                        count = 1;
                    }
                }

                compressed += (count > 1 ? count.ToString() : "") + prev;
                answer = Math.Min(answer, compressed.Length);
            }

            return answer;
        }
    }
}
