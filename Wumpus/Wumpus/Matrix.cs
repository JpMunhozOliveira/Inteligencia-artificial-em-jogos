using System;

static class Matrix
{
    public static int[,] matrix = new int[1, 1];
    public static int numRoomPit = 3;
    public static int numGold = 1;

    public static void CreateMatrix()
    {
        //Adiciona o valor de zero para as casas da matrix
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = 0;
            }
        }

        //Adiciona salas com Ouro
        for (int i = 0; i < numGold; i++)
        {
            Random r = new Random();
            bool roomCheck = false;

            while (!roomCheck)
            {
                int x = r.Next(matrix.GetLength(0));
                int y = r.Next(matrix.GetLength(1));

                if (matrix[x, y] == 0)
                {
                    matrix[x, y] = 1;
                    GetPath(x, y);
                    roomCheck = true;
                }
            }
        }

        //Adiciona salas com buraco
        for (int i = 0; i < numRoomPit; i++)
        {
            Random r = new Random();
            bool roomCheck = false;

            while (!roomCheck)
            {
                int x = r.Next(matrix.GetLength(0));
                int y = r.Next(matrix.GetLength(1));

                if (matrix[x, y] != 1 && matrix[x, y] != 9)
                {
                    matrix[x, y] = 9;
                    roomCheck = true;
                }
            }
        }
    }

    public static void GetPath(int posX, int posY)
    {
        int num = 1;

        while (num < matrix.GetLength(0) || num < matrix.GetLength(1))
        {
            for (int i = num; i >= -num; i--)
            {
                for (int j = num; j >= -num; j--)
                {
                    if (matrix.GetLength(0) > posX + i && 0 <= posX + i &&
                        matrix.GetLength(1) > posY + j && 0 <= posY + j)
                    {
                        if(matrix[posX + i, posY + j] == 0)
                        {
                            matrix[posX + i, posY + j] = matrix[posX, posY] + num;
                        }
                    }
                }
            }
            num++;
        }
    }
    public static void DrawMatrix()
    {

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int k = 0; k < matrix.GetLength(1); k++)
            {
                Console.Write("|---");
            }

            Console.WriteLine("|");

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write("| {0} ", matrix[i, j]);
            }
            Console.WriteLine("|");
        }

        for (int k = 0; k < matrix.GetLength(1); k++)
        {
            Console.Write("|---");
        }

        Console.WriteLine("|");
    }

}