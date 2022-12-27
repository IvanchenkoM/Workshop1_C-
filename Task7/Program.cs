// Написать функцию Shuffle, которая перемешивает эл-ты массива в случайном порядке.
// Нельзя использовать встроенные функции массивов.

int[] userArray = new int[] {5,6,7,8,9};

PrintArray(userArray);
Console.Write($"\r\nArray with randomly shuffled elements: ");
Shuffle(userArray);

void Shuffle(int[] array)
{
    int[] indexArray = new int[array.Length];
    for (int i=0; i<indexArray.Length; i++)
    {
        indexArray[i] = new Random().Next(0,indexArray.Length);
        int number = indexArray[i];
        if (i>=1)
        {
            for (int j=0; j<i; j++)
            {
                while (indexArray[i]==indexArray[j])
                {
                    indexArray[i] = new Random().Next(0,indexArray.Length);
                    number = indexArray[i];
                    j=0;
                }
            }
        }
    }
    int[] copyArray = new int[array.Length];
    for (int i=0; i<copyArray.Length; i++)
    {
        int temp = indexArray[i];
        copyArray[i] = array[temp];
    }
    PrintArray(copyArray);
}

void PrintArray(int[] array)
{
    Console.Write("[ ");
    foreach (var n in array)
    {
        Console.Write($"{n} ");
    }
    Console.Write("]");
}