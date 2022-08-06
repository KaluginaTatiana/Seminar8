void SelectionSortMax(int[] array)
{
    for (int i = 0; i < array.Length - 1; i++)
    {
        int maxPosition = i;
        for (int k = i + 1; k < array.Length; k++)
        {
            if (array[k] > array[maxPosition])
                maxPosition = k;
        }
        int temp = array[i];
        array[i] = array[maxPosition];
        array[maxPosition] = temp;
    }
}

void FillArray(int[,] array)
{
    Random rand = new Random();
    int rows = array.GetLength(0);
    int columns = array.GetLength(1);
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            array[i, j] = rand.Next(0, 10);
        }
    }
}

void PrintArray(int[,] array)
{
    int rows = array.GetLength(0);
    int columns = array.GetLength(1);
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            Console.Write(array[i, j] + " ");
        }
        Console.WriteLine();
    }
}

void FillArrayRow(int[] arrayRow, int[,] array, int iNum)
{
    for (int j = 0; j < arrayRow.Length; j++)
    {
        array[iNum, j] = arrayRow[j];
    }
}

void FillArraySqrSpiral(int[,] array)
{
    int rows = array.GetLength(0);
    int min = 0;
    int max = rows - 1;
    int num = 1;
    while (num <= array.Length)
    {
        for (int j = min; j <= max; j++)
        {
            array[min, j] = num;
            num = num + 1;
        }
        for (int i = min + 1; i <= max; i++)
        {
            array[i, max] = num;
            num = num + 1;
        }
        for (int j = max - 1; j >= min; j--)
        {
            array[max, j] = num;
            num = num + 1;
        }
        for (int i = max - 1; i > min; i--)
        {
            array[i, min] = num;
            num = num + 1;
        }
        min = min + 1;
        max = max - 1;
    }
}

void Task54()
{
    // Задайте двумерный массив. Напишите программу, которая упорядочит 
    // по убыванию элементы каждой строки двумерного массива.
    Random rand = new Random();
    int rows = rand.Next(2, 6);
    int columns = rand.Next(3, 6);
    int[,] matrix = new int[rows, columns];
    FillArray(matrix);
    PrintArray(matrix);
    Console.WriteLine();
    int[] matrixRow = new int[columns];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            matrixRow[j] = matrix[i, j];
        }
        SelectionSortMax(matrixRow);
        FillArrayRow(matrixRow, matrix, i);
    }
    PrintArray(matrix);
}

void Task56()
{
    // Задайте прямоугольный двумерный массив. Напишите программу, которая будет 
    // находить строку с наименьшей суммой элементов.
    Random rand = new Random();
    int rows = rand.Next(2, 5);
    int columns = rand.Next(3, 5);
    int[,] matrix = new int[rows, columns];
    FillArray(matrix);
    PrintArray(matrix);
    Console.WriteLine();
    int rowSumm = 0;
    int minSumm = 0;
    int iMin = 0;
    for (int k = 0; k < columns; k++)
    {
        minSumm = minSumm + matrix[0, k];
    }
    for (int i = 1; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            rowSumm = rowSumm + matrix[i, j];
        }
        if (minSumm > rowSumm)
        {
            minSumm = rowSumm;
            iMin = i;
        }
    }
    Console.WriteLine($"Строка с наименьшей суммой элементов: {iMin + 1} строка.");
}

void Task58()
{
    // Заполните спирально массив 4 на 4. 
    int rows = 4;
    int columns = 4;
    int[,] matrix = new int[rows, columns];
    FillArraySqrSpiral(matrix);
    PrintArray(matrix);
}
Task54();
Task56();
Task58();