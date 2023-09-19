// https://school.programmers.co.kr/learn/courses/30/lessons/150370
namespace 개인정보수집유효기간
{
    class Program
    {
        static void Main(string[] args)
        {
            // 테스트 케이스 1
            string today1 = "2022.05.19";
            string[] terms1 = { "A 6", "B 12", "C 3" };
            string[] privacies1 = { "2021.05.02 A", "2021.07.01 B",
             "2022.02.19 C", "2022.02.20 C" };
            int[] result1 = solution(today1, terms1, privacies1);
            Console.WriteLine(string.Join(", ", result1));  // 출력: 1, 3

            // 테스트 케이스 2
            string today2 = "2020.01.01";
            string[] terms2 = { "Z 3", "D 5" };
            string[] privacies2 = { "2019.01.01 D", "2019.11.15 Z", "2019.08.02 D", "2019.07.01 D", "2018.12.28 Z" };
            int[] result2 = solution(today2, terms2, privacies2);
            Console.WriteLine(string.Join(", ", result2));  // 출력: 1, 4, 5
        }
        public static int[] solution(string today, string[] terms, string[] privacies)
        {
            Dictionary<string, int> termDictionary = new Dictionary<string, int>();
            List<int> result = new List<int>();

            foreach (var term in terms)
            {
                string[] splitTerm = term.Split(' ');
                termDictionary[splitTerm[0]] = int.Parse(splitTerm[1]);
            }

            DateTime todayDate = DateTime.ParseExact(today, "yyyy.MM.dd", null);

            for (int i = 0; i < privacies.Length; i++)
            {
                string[] splitPrivacy = privacies[i].Split(' ');
                DateTime privacyDate = DateTime.ParseExact(splitPrivacy[0], "yyyy.MM.dd", null);
                int monthsToAdd = termDictionary[splitPrivacy[1]];
                DateTime expiryDate = privacyDate.AddMonths(monthsToAdd);

                if (expiryDate <= todayDate)
                {
                    result.Add(i + 1);
                }
            }

            return result.ToArray();
        }
    }
}