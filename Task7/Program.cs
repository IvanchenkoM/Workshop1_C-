// Написать функцию Shuffle, которая перемешивает эл-ты массива в случайном порядке.
// Нельзя использовать встроенные функции массивов.

int[] userArray = new int[] {1,2,3,4,5,6};

PrintArray(userArray);
Console.Write($"\r\nAdded element '{number}' to the array at index '{searchIndex}'. Get array: ");
AddToArray(userArray, searchIndex, number);
Console.Write($"\r\nRemoved element at index '{searchIndex}' from the array. Get array: ");
RemoveFromArray(userArray,searchIndex);

void Shuffle(int[] array)
{
    int[] copyArray = new int[array.Length];
    for (int i=0; i<array.Length; i++)
    {
        copyArray[i] = array[i];
    }
    for (int i=0; i<array.Length; i++)
    {
        
    }
}

void AddToArray(int[] array, int index, int value)
{
    int[] newArray = new int[array.Length+1];
    for(int i=0; i<newArray.Length; i++)
    {
        if (i<index)
            newArray[i] = array[i];
        else if (i == index)
            newArray[i] = value;
        else if (i>index)
            newArray[i] = array[i-1];
    }
    PrintArray(newArray);
}

void RemoveFromArray(int[] array, int index)
{
    int[] newArray = new int[array.Length-1];
    for(int i=0; i<array.Length; i++)
    {
        if (i<index)
            newArray[i] = array[i];
        else if (i>index)
            newArray[i-1] = array[i];
    }
    PrintArray(newArray);
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