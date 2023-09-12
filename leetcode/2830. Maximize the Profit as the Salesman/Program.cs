namespace MaximizetheProfitastheSalesman
{
    class Program
    {
        static void Main(string[] args)
        {
            // 테스트 케이스
            IList<IList<int>> offers1 = new List<IList<int>>
            {
                new List<int> {0, 0, 1},
                new List<int> {0, 2, 2},
                new List<int> {1, 3, 2}
            };
            Console.WriteLine(MaximizeTheProfit(5, offers1));

            IList<IList<int>> offers2 = new List<IList<int>>
            {
                new List<int> {0, 0, 1},
                new List<int> {0, 2, 10},
                new List<int> {1, 3, 2}
            };
            Console.WriteLine(MaximizeTheProfit(5, offers2));
        }
        public static int MaximizeTheProfit(int n, IList<IList<int>> purchaseOffers)
        {
            // 각 제안의 끝 지점과 그 지점까지의 최대 이익을 저장하는 리스트 초기화
            List<Tuple<int, int>> profitList = new List<Tuple<int, int>>();
            profitList.Add(new Tuple<int, int>(-1, 0));

            // 제안들을 끝 지점 기준으로 정렬
            var sortedOffers = purchaseOffers.OrderBy(offer => offer[1]).ToList();

            foreach (var offer in sortedOffers)
            {
                // 현재 제안의 시작 전 집 번호 계산
                int previousHouse = offer[0] - 1;
                int start = 0, end = profitList.Count - 1;
                int currentProfit = 0;

                // 이진 탐색을 사용하여 현재 제안의 시작 전까지의 최대 이익을 찾음
                while (start <= end)
                {
                    int mid = (start + end) / 2;
                    if (profitList[mid].Item1 <= previousHouse)
                    {
                        currentProfit = Math.Max(profitList[mid].Item2 + offer[2], currentProfit);
                        start = mid + 1;
                    }
                    else
                    {
                        end = mid - 1;
                    }
                }

                // 현재 제안의 이익과 이전 제안들의 최대 이익을 비교하여 최대값을 선택
                currentProfit = Math.Max(currentProfit, profitList.Last().Item2);
                profitList.Add(new Tuple<int, int>(offer[1], currentProfit));
            }

            // 계산된 최대 이익 반환
            return profitList.Last().Item2;
        }
    }
}