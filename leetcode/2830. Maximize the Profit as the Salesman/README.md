
# 요약

1. `profitList` 초기화

```csharp
List<Tuple<int, int>> profitList = new List<Tuple<int, int>>();
profitList.Add(new Tuple<int, int>(-1, 0));
```

`profitList`는 각 제안의 끝 지점과 그 지점까지의 최대 이익을 저장하는 리스트.
초기값 `(-1, 0)`은 아직 어떤 집도 팔리지 않았을 때의 상태를 나타낸다.

2. 제안들 정렬

```csharp
var sortedOffers = purchaseOffers.OrderBy(offer => offer[1]).ToList();
```

**제안들을 end 기준으로 정렬하는 이유**

- 순차적인 판매 고려
- 중복 제외
  - 끝지점으로 정렬하면, 현재 제안의 시작 지점 이전에 팔린 집들에 대한 정보를 얻을 수 있다. 이를 통해 현재 제안과 중복되지 않게 할 수 있다.
- 이진 탐색을 통해 현재 제안의 시작 지점 이전의 최대 이익을 빠르게 찾을 수 있게 한다.
- 이전 제안들과 현재 제안을 비교해서 선택 할 수 있다.

3. 각 제안 처리

```csharp
foreach (var offer in sortedOffers)
{

}
```

정렬된 제안들을 순차적으로 처리.

4. 현재 제안의 시작 전 집 번호 계산

```csharp
int previousHouse = offer[0] - 1;
```

현재 제안의 시작 지점 바로 이전 집의 번호를 계산. 이 번호를 사용하여 현재 제안의 시작 전까지의 최대 이익을 찾는다.

5. 이진 탐색

```csharp
int start = 0, end = profitList.Count - 1;
int currentProfit = 0;
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
```

이진 탐색을 사용하여 현재 제안의 시작 전까지의 최대 이익을 `profitList`에서 찾는다. 여기서 현재 제안의 시작 전까지 팔린 집들을 알 수 있다.

6. 최대 이익 계산 및 저장

```csharp
currentProfit = Math.Max(currentProfit, profitList.Last().Item2);
profitList.Add(new Tuple<int, int>(offer[1], currentProfit));
```

현재 제안의 이익과 이전 제안들의 최대 이익을 비교하여 최대값을 선택. 그리고 이 최대 이익을 `profitList`에 저장한다.

7. 최대 이익 리턴

```csharp
return profitList.Last().Item2;
```

## 테스트케이스 예시

```csharp
n = 4, offers = [[0,0,6],[1,2,8],[0,3,7],[2,2,5],[0,1,5],[2,3,2]
```

1. **초기화**:
`profitList`는 각 제안의 끝 지점과 그 지점까지의 최대 이익을 저장한다. 초기값은 `(-1, 0)`
2. **제안들 정렬**:
제안들을 끝지점 기준으로 정렬

```csharp
    [[0,0,6],[0,1,5],[1,2,8],[2,2,5],[0,3,7],[2,3,2]]
```

3. **첫 번째 [0,0,6]**
    - 현재 제안의 시작 전 집 번호는 -1
    - 이익은 0 + 6 = 6
    - `profitList`에 (0, 6)을 추가.
4. **두 번째 [0,1,5]**
    - 현재 제안의 시작 전 집 번호는 -1
    - 현재 제안으로 얻을 수 있는 이익은 0 + 5 = 5
    - 이전 제안의 최대 이익 6이 더 크므로 `profitList`에 추가 X
5. **세 번째 [1,2,8]**
    - 현재 제안의 시작 전 집 번호는 0
    - `profitList`에서 0 이하의 최대 이익은 6
    - 현재 제안으로 얻을 수 있는 이익은 6 + 8 = 14
    - `profitList`에 (2, 14)를 추가
6. **네 번째 [2,2,5]**
    - 현재 제안의 시작 전 집 번호는 1
    - `profitList`에서 1 이하의 최대 이익은 6
    - 현재 제안으로 얻을 수 있는 이익은 6 + 5 = 11
    - 이전 제안의 최대 이익 14가 더 크기 때문에 `profitList`에 추가 X
7. **다섯 번째  [0,3,7]**
    - 현재 제안의 시작 전 집 번호는 -1
    - `profitList`에서 -1 이하의 최대 이익은 0
    - 현재 제안으로 얻을 수 있는 이익은 0 + 7 = 7
    - 하지만 이전 제안의 최대 이익 14가 더 크므로 `profitList`에 추가 X
8. **여섯 번째 [2,3,2]**
    - 현재 제안의 시작 전 집 번호는 1
    - `profitList`에서 1 이하의 최대 이익은 6
    - 현재 제안으로 얻을 수 있는 이익은 6 + 2 = 8
    - 하지만 이전 제안의 최대 이익 14가 더 크므로 `profitList`에 추가 X

`profitList`의 마지막 값은 (2, 14)이므로 최대 이익은 14
