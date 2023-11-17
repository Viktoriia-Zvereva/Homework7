static void Main(string[] args)
{

    void FillArray(int[,] array, int minValue = -9, int maxValue = 9)
    {
        maxValue++;
        int rows = array.GetLength(0);
        int columns = array.GetLength(1);
        Random random = new Random();
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                array[i, j] = random.Next(minValue, maxValue);
            }
        }
    }

    void FillArrayDouble(double[,] array, int minValue = -9, int maxValue = 9)
    {
        int rows = array.GetLength(0);
        int columns = array.GetLength(1);
        Random random = new Random();
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                array[i, j] = Math.Round(random.NextDouble() * (maxValue - minValue) + minValue, 2);
            }
        }
    }

    void PrintArray(int[,] array)
    {
        int rows = array.GetLength(0);
        int columns = array.GetLength(1);
        Console.WriteLine("Вывод массива");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write($"{array[i, j]}\t");
            }
            Console.WriteLine();
        }
    }

    void PrintArrayDouble(double[,] array)
    {
        int rows = array.GetLength(0);
        int columns = array.GetLength(1);
        Console.WriteLine("Вывод массива");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write($"{array[i, j]}\t");
            }
            Console.WriteLine();
        }
    }

    void Task53()
    {
        //Задача 53: Задайте двумерный массив. Напишите программу,
        //которая поменяет местами первую и последнюю строку массива.

        int rows = 5;
        int columns = 4;

        int[,] matrix = new int[rows, columns];

        FillArray(matrix, 0, 9);
        PrintArray(matrix);

        // 5 7 3 0 1       i = 0
        // ...
        // 9 1 4 3 8       iMax = matrix.GetLength(0) - 1

        Console.WriteLine();
        Console.WriteLine("Меняем строки массива");

        int firstIndex = 0;
        int lastIndex = matrix.GetLength(0) - 1;
        for (int j = 0; j < columns; j++)
        {
            int temp = matrix[firstIndex, j];
            matrix[firstIndex, j] = matrix[lastIndex, j];
            matrix[lastIndex, j] = temp;
        }

        PrintArray(matrix);
    }
}
void Task55()
{
    //Задача 55: Задайте двумерный массив. Напишите программу, которая заменяет строки на столбцы.
    //В случае, если это невозможно, программа должна вывести сообщение для пользователя.

    int rows = 5;
    int columns = rows;

    int[,] matrix = new int[rows, columns];

    FillArray(matrix, 0, 9);
    PrintArray(matrix);

    for (int i = 0; i < rows; i++)
    {
        for (int j = i; j < columns; j++)
        {
            (matrix[i, j], matrix[j, i]) = (matrix[j, i], matrix[i, j]);
        }
        Console.WriteLine();
    }

    //Console.WriteLine();
    Console.WriteLine("Переворачиваем массив");
    PrintArray(matrix);

}

void Task57()
{
    //Задача 57: Составить частотный словарь элементов двумерного массива.
    //Частотный словарь содержит информацию о том, сколько раз встречается элемент входных данных.

    int rows = 2;
    int columns = 3;

    int[,] matrix = new int[rows, columns];
    int minValue = -100;
    int maxValue = -95;
    FillArray(matrix, minValue, maxValue);
    PrintArray(matrix);

    int[] dictionary = new int[maxValue - minValue + 1];

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            dictionary[matrix[i, j] - minValue]++;
        }
    }

    for (int i = 0; i < dictionary.Length; i++)
    {
        if (dictionary[i] != 0) Console.WriteLine($"{i + minValue} встречается {dictionary[i]} раз(-а)");
    }

}


void Task59()
{
    //Задача 59: Задайте двумерный массив из целых чисел. Напишите программу,
    //которая удалит строку и столбец, на пересечении которых расположен наименьший элемент массива.

    int rows = 4;
    int columns = 5;

    int[,] matrix = new int[rows, columns];
    int[,] result = new int[rows - 1, columns - 1];

    int minValue = -100;
    int maxValue = 100;
    FillArray(matrix, minValue, maxValue);
    PrintArray(matrix);

    int min = matrix[0, 0];
    int i_min = 0;
    int j_min = 0;
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            if (matrix[i, j] < min)
            {
                min = matrix[i, j];
                i_min = i;
                j_min = j;
            }
        }
    }

    Console.WriteLine($"Минимум matrix[{i_min}, {j_min}] = {min}");
    int bias_i = 0;
    int bias_j = 0;
    for (int i = 0; i < result.GetLength(0); i++)
    {
        if (i == i_min) bias_i++;
        for (int j = 0; j < result.GetLength(1); j++)
        {
            if (j == j_min) bias_j++;
            result[i, j] = matrix[i + bias_i, j + bias_j];
        }
        bias_j = 0;
    }
    Console.WriteLine("Печать результата");
    PrintArray(result);
}


//Домашняя работа

void Task47()
{
    int rows = 3;
    int columns = 4;

    double[,] matrix = new double[rows, columns];

    int minValue = -5;
    int maxValue = 20;
    FillArrayDouble(matrix, minValue, maxValue);
    PrintArrayDouble(matrix);
}

void Task50()
{
    int rows = 3;
    int columns = 4;

    double[,] matrix = new double[rows, columns];

    int minValue = -5;
    int maxValue = 20;
    FillArrayDouble(matrix, minValue, maxValue);
    PrintArrayDouble(matrix);

    Console.WriteLine("Введи номер строки:");
    int inputRow = Convert.ToInt32(Console.ReadLine()) - 1;

    Console.WriteLine("Введи номер столбца:");
    int inputColunm = Convert.ToInt32(Console.ReadLine()) - 1;

    if (inputRow >= 0 &&
        inputRow < matrix.GetLength(0) &&
        inputColunm >= 0 &&
        inputColunm < matrix.GetLength(1))
    {
        Console.WriteLine($"Искомый элемент равен {matrix[inputRow, inputColunm]}");
    }
    else
    {
        Console.WriteLine("Введены неверные индексы");
    }
}

void Task52()
{
    int rows = 3;
    int columns = 4;

    int[,] matrix = new int[rows, columns];

    FillArray(matrix, 0, 9);
    PrintArray(matrix);

    Console.Write("\n");
    for (int j = 0; j < columns; j++)
    {
        double mean = 0;
        for (int i = 0; i < rows; i++)
        {
            mean += matrix[i, j];
        }
        mean /= rows;
        Console.Write($"{Math.Round(mean, 2)}\t");
    }
}


Console.Clear();
Task52();