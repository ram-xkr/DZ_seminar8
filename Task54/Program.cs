// Задача 54: Задайте двумерный массив. Напишите программу,
// которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

using static System.Console;
Clear();
Write("Введите размер матрицы через пробел: ");
int[] parameters = GetArrayFromString(ReadLine()!);
int[,] matrix = GetMatrixArray(parameters[0], parameters[1]);
PrintMatrix(matrix);
CreateNewMatrix(matrix);
WriteLine();
PrintMatrix(matrix);

int[] GetArrayFromString(string parameters)
{
    string[] parames = parameters.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    int[] parameterNum = new int[parames.Length];
    for (int i = 0; i < parameterNum.Length; i++)
    {
        parameterNum[i] = int.Parse(parames[i]);
    }
    return parameterNum;
}

int[,] GetMatrixArray(int rows, int columns)
{
    int[,] resultMatrix = new int[rows, columns];
    Random rnd = new Random();
    for (int i = 0; i < resultMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < resultMatrix.GetLength(1); j++)
        {
            resultMatrix[i, j] = rnd.Next(0, 10);
        }
    }
    return resultMatrix;
}

void PrintMatrix(int[,] inMatrix)
{
    for (int i = 0; i < inMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < inMatrix.GetLength(1); j++)
        {
            Write($"{inMatrix[i, j]}\t");
        }
        WriteLine();
    }
}

int[,] CreateNewMatrix(int[,] inMatrix)
{
    for (int i = 0; i < inMatrix.GetLength(0); i++)
    {
        for (int j = 1; j < inMatrix.GetLength(1); j++)
        {
            if (inMatrix[i, j] > inMatrix[i, j - 1])
            {
                int temp = inMatrix[i, j];
                inMatrix[i, j] = inMatrix[i, j - 1];
                inMatrix[i,j - 1] = temp;
                j = 0;
            }
        }
    }

    // for (int i = 0; i < inMatrix.GetLength(0); i++)
    // {
    //     for (int j = 0; j < inMatrix.GetLength(1) - 1; j++)
    //     {
    //         if (inMatrix[i, j] > inMatrix[i, j + 1])
    //         {
    //             int temp = inMatrix[i, j];
    //             inMatrix[i, j] = inMatrix[i, j + 1];
    //             inMatrix[i, j + 1] = temp;
    //             j = 0;
    //         }
    //     }
    // }

    return inMatrix;
}