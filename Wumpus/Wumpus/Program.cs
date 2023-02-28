using System;

class Program
{
    static void Main(string[] args)
    {
        Matrix.matrix = new int[4, 4];
        Matrix.numRoomPit = 3;
        Matrix.numGold = 1;

        Matrix.CreateMatrix();

        Console.WriteLine("Wumpus Game\n");
        Console.WriteLine("9 - Pit Room");
        Console.WriteLine("1 - Gold\n");

        Matrix.DrawMatrix();
    }
}