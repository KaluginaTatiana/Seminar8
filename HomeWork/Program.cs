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

void Task54()
{
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
    for (int i = 0; i < 1; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            minSumm = minSumm + matrix[i, j];
        }
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
// Task54();
Task56();