// Задача 58: Задайте две матрицы. Напишите программу, которая 
// будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

using static System.Console;
Clear();
Write("Введите размер 1 матрицы через пробел: ");
int[] parameters = GetArrayFromString(ReadLine()!);
int[,] matrix1 = GetMatrixArray(parameters[0], parameters[1]);
PrintMatrix(matrix1);
WriteLine();
Write("Введите размер 2 матрицы через пробел: ");
int[] parameters2 = GetArrayFromString(ReadLine()!);
int[,] matrix2 = GetMatrixArray(parameters2[0], parameters2[1]);
PrintMatrix(matrix2);
if (matrix1.GetLength(1) != matrix2.GetLength(0))
    {
        WriteLine("Произведение матриц невозможно.");
        return;
    }
WriteLine();
int[,] newMatrix = NewMatrixArray(matrix1, matrix2);
PrintMatrix(newMatrix);

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

int[,] NewMatrixArray(int [,] matrix1, int[,] matrix2)
{
    int[,] resultMatrix = new int[matrix1.GetLength(0),  matrix2.GetLength(1)];
        
    for (int i = 0; i < resultMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < resultMatrix.GetLength(1); j++)
        {   
            resultMatrix[i,j] = 0;
            for (int k = 0; k < matrix1.GetLength(1); k++)
            {
                resultMatrix[i, j] += matrix1[i, k] * matrix2[k, j];
            }
        }
    }
    return resultMatrix;
} 