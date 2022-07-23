/*Задача 73: Task73
Дополнительная задача 74*: Task74

Задача 73: Есть число N. Сколько групп M, можно получить при разбиении всех чисел на группы, 
так чтобы в одной группе все числа в группе друг на друга не делились? 
Найдите M при заданном N и получите одно из разбиений на группы N ≤ 10²⁰.

Например, для N = 50, M получается 6
Группа 1: 1
Группа 2: 2 3 11 13 17 19 23 29 31 37 41 43 47
Группа 3: 4 6 9 10 14 15 21 22 25 26 33 34 35 38 39 46 49
Группа 4: 8 12 18 20 27 28 30 42 44 45 50
Группа 5: 7 16 24 36 40
Группа 6: 5 32 48

Группа 1: 1
Группа 2: 2 3 5 7 11 13 17 19 23 29 31 37 41 43 47
Группа 3: 4 6 9 10 14 15 21 22 25 26 33 34 35 38 39 46 49
Группа 4: 8 12 18 20 27 28 30 42 44 45 50
Группа 5: 16 24 36 40
Группа 6: 32 48
*/

/*void PrintArray(int[] matrix)


{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        Console.Write($"{matrix[i]} ");
    }
    Console.WriteLine();


}

int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
int[] pointRaund = new int[array.Length];
string row = String.Empty;
int count = 0;
int point = 0;

bool CreateRow(int[] array, int number)
{

}*/


// Задача 73: Есть число N. Сколько групп M можно получить при разбиении всех чисел на группы
//            так, чтобы в одной группе все числа были взаимно просты (все числа в группе не делятся друг на друга)?
//            Найдите M при заданном N и получите одно из разбиений на группы (N <= 10^20). 


void PrintGroups(int[] numbers, int groupsCount)
{
  for (int i = 0; i < groupsCount; i++)
  {
    Console.Write($"Группа {i + 1}: [");
    for (int j = 1; j < numbers.Length; j++)
    {
      if (numbers[j] == i + 1)
      {
        Console.Write($" {j}");
      }
    }
    Console.WriteLine(" ]");
  }
}

void GetPrimes(int[] numbers, ref int groupCount, int startIdx = 3, bool hasNextGroup = true)
{
  if (!hasNextGroup)
  {
    groupCount--;
    return;
  };

  int nextGroupId = 0;
  bool isNewGroup = true;
  for (int i = startIdx; i < numbers.Length; i++)
  {
    bool isPrime = true;
    if (numbers[i] == groupCount)
    {
      for (int j = i - 1; j > startIdx - 2; j--)
      {
        if ((numbers[j] == groupCount) && (i % j == 0))
        {
          isPrime = false;
          break;
        }
      }
    }

    if (!isPrime)
    {
      numbers[i] = groupCount + 1;
      if (isNewGroup)
      {
        nextGroupId = i;
        isNewGroup = false;
      }
    }
  }

  groupCount++;

  GetPrimes(numbers, ref groupCount, startIdx = nextGroupId + 1, nextGroupId != 0);
}

Console.Write("Введите число N: ");
int n = Convert.ToInt32(Console.ReadLine());
int[] numbers = new int[n + 1];
numbers[1] = 1; 

int groupCount = 2;

for (int i = 2; i < n + 1; i++)
{
  numbers[i] = groupCount;
}


GetPrimes(numbers, ref groupCount);

Console.WriteLine($"Количество групп: {groupCount}");

PrintGroups(numbers, groupCount);






