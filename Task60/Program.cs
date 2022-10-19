// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся 
// двузначных чисел. Напишите программу, которая будет построчно
// выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

using static System.Console;
Clear();
Write("Введите размер массива через пробел(X Y Z): ");
int[] parameters = GetArrayFromString(ReadLine()!);
if (parameters[0] * parameters[1] * parameters[2] > 90)
{
    WriteLine("Превышены допустимые размеры массива!");
    return;
}
int[,,] matrix3D = GetMatrixArray(parameters[0], parameters[1], parameters[2]);
PrintMatrix(matrix3D);

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

int[,,] GetMatrixArray(int x, int y, int z)
{
    int[] array = new int[x * y * z];
    for (int element = 0; element < array.Length; element++)
    {
        Random rnd = new Random();
        int num = rnd.Next(10, 99 + 1);
        if (array.Contains(num))
        {
            element--;
        }
        else
        {
            array[element] = num;
        }
    }
    int[,,] resultMatrix = new int[x, y, z];
    int count = 0;
    for (int i = 0; i < resultMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < resultMatrix.GetLength(1); j++)
        {
            for (int k = 0; k < resultMatrix.GetLength(2); k++)
            {
                resultMatrix[i, j, k] = array[count];
                count++;
            }
        }
    }
    return resultMatrix;
}

void PrintMatrix(int[,,] inMatrix)
{
    for (int i = 0; i < inMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < inMatrix.GetLength(1); j++)
        {
            for (int k = 0; k < inMatrix.GetLength(2); k++)
            {
                Write($"{inMatrix[i, j, k]}({i},{j},{k}) ");
            }
            WriteLine();
        }
    }
}