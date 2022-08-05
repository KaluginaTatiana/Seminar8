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

//Task53();
Task55();
