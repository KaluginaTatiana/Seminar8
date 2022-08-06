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
void ChangeRowsColumns(int[,] array)
{
    int rows = array.GetLength(0);
    int columns = array.GetLength(1);
    if (rows == columns)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = i; j < columns; j++)
            {
                (array[i, j], array[j, i]) = (array[j, i], array[i, j]);
            }
        }
        PrintArray(array);
    }
    else
    {
        Console.WriteLine("Невозможно заменить строки на столбцы");
    }
    Console.WriteLine();
}

void Task53()
{
    // Задайте двумерный массив. Напишите программу, которая поменяет местами 
    // первую и последнюю строку массива.
    Random rand = new Random();
    int rows = rand.Next(3, 6);
    int columns = rand.Next(3, 6);
    int[,] matrix = new int[rows, columns];
    FillArray(matrix);
    PrintArray(matrix);
    int rowMax = rows - 1;
    for(int j = 0; j < rows; j++)
    {
        int bufer = matrix[0, j];
        matrix[0, j] = matrix[rowMax,j];
        matrix[rowMax, j] = bufer;
    }
    Console.WriteLine();
    PrintArray(matrix);
}
void Task55()
{
    // ЗЗадайте двумерный массив. Напишите программу, которая заменяет строки на столбцы. 
    // В случае, если это невозможно, программа должна вывести сообщение для пользователя.
    Console.WriteLine("Введите количество строк массива.");
    int rows = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введите количество столбцов массива.");
    int columns = Convert.ToInt32(Console.ReadLine());
    int[,] matrix = new int[rows, columns];
    Console.WriteLine();
    FillArray(matrix);
    PrintArray(matrix);
    Console.WriteLine();
    ChangeRowsColumns(matrix);
}
void Task57()
{
    // Составить частотный словарь элементов двумерного массива. Частотный словарь содержит
    //информацию о том, сколько раз встречается элемент входных данных.
    Random rand = new Random();
    int rows = rand.Next(2, 5);
    int columns = rand.Next(3, 5);
    int[,] matrix = new int[rows, columns];
    int[] dictionary = new int[10];
    FillArray(matrix);
    PrintArray(matrix);
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            dictionary[matrix[i, j]]++;
        }
    }
    Console.WriteLine();
    for (int i = 0; i < dictionary.Length; i++)
    {
        if (dictionary[i] != 0) Console.WriteLine($"Элемент {i} встречается {dictionary[i]} раз.");
    }

}
void Task59()
{
    //Задайтедвумерный массив из целых чисел. Напишите программу, 
    // которая удалит строку и столбец, на пересечении которых
    // расположен наименьший элемент массива.
    Random rand = new Random();
    int rows = rand.Next(2, 6);
    int columns = rand.Next(3, 6);
    int[,] matrix = new int[rows, columns];
    FillArray(matrix);
    PrintArray(matrix);
    Console.WriteLine();
    int min = matrix[0, 0];
    int iMin = 0;
    int jMin = 0;
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            if (matrix[i, j] < min) 
            {
                min = matrix[i, j];
                iMin = i;
                jMin = j;
            };
        }
    }
    Console.WriteLine($"Минимальный элемент находится на позиции ({iMin}, {jMin}) и равен {min}.");
    int[,] newMatrix = new int[rows -1, columns - 1];
    int iBias = 0;
    for (int i = 0; i < rows - 1; i++)
    {
        if (i == iMin) iBias++;
        int jBias = 0;
        for (int j = 0; j < columns - 1; j++)
        {
            if (j == jMin) jBias++;
            newMatrix[i, j] = matrix[i + iBias, j + jBias];
        }
    }
    Console.WriteLine("Вывод нового массива:");
    PrintArray(newMatrix);
}

void Task54()
{
    // Это разбор домашнего задания с использованием сортировки пузырьком.
    // Задайте двумерный массив. Напишите программу, которая упорядочит 
    // по убыванию элементы каждой строки двумерного массива.

    Random rand = new Random();
    int rows = rand.Next(2, 6);
    int columns = rand.Next(3, 6);
    int[,] matrix = new int[rows, columns];
    FillArray(matrix);
    PrintArray(matrix);
    Console.WriteLine();

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            for (int k = 0; k < columns - j - 1; k++)
            {
                if (matrix[i, k] < matrix[i, k + 1])
                {
                    int temp = matrix[i, k];
                    matrix[i, k] = matrix[i, k + 1];
                    matrix[i, k + 1] = temp;
                }
            }
        }
    }
    PrintArray(matrix);
}

void Task58()
{
    // Это разбор домашнего задания.
    // Заполните спирально массив 4 на 4.
    Random rand = new Random();
    int rows = rand.Next(4, 8);
    int columns = rand.Next(3, 7);
    int[,] matrix = new int[rows, columns];
    
    int indexI = 0;
    int indexJ = 0;

    int changeI = 0;
    int changeJ = 1;

    int steps = columns;
    int turnCount = 0;
    
    for (int i = 1; i <= matrix.Length; i++)
    {
        matrix[indexI, indexJ] = i;
        steps = steps - 1;
        if (steps == 0)
        {
            steps = columns * (turnCount % 2) + rows * ((turnCount + 1) % 2) - 1 - turnCount/2;
            int temp = changeI;
            changeI = changeJ;
            changeJ = -temp;
            turnCount= turnCount + 1;
        }

        indexI = indexI + changeI;
        indexJ = indexJ + changeJ;
    }
    PrintArray(matrix);
}

//Task53();
//Task55();
//Task57();
//Task59();
//Task54();
Task58();
